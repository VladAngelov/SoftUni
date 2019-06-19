namespace SoftJail.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            Department[] allDepartments = JsonConvert.DeserializeObject<Department[]>(jsonString);

            List<Department> validDepartments = new List<Department>();
            StringBuilder sb = new StringBuilder();

            foreach (var department in allDepartments)
            {
                var isValid = IsValid(department) &&
                              department.Cells.All(IsValid);

                if (isValid)
                {
                    validDepartments.Add(department);
                    sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            PrisonerDto[] prisonersDto = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);

            List<Prisoner> validPrisoners = new List<Prisoner>();
            StringBuilder sb = new StringBuilder();

            foreach (var prisonerDto in prisonersDto)
            {
                bool isValid = IsValid(prisonerDto)
                               && prisonerDto.Mails.All(IsValid);

                if (isValid)
                {
                    DateTime? releaseDate = prisonerDto.ReleaseDate == null
                        ? (DateTime?)null
                        : DateTime.ParseExact(
                            prisonerDto.ReleaseDate,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture);

                    Prisoner prisoner = new Prisoner
                    {
                        FullName = prisonerDto.FullName,
                        Nickname = prisonerDto.Nickname,
                        Age = prisonerDto.Age,
                        IncarcerationDate = DateTime.ParseExact(
                                prisonerDto.IncarcerationDate,
                                "dd/MM/yyyy",
                                CultureInfo.InvariantCulture),
                        ReleaseDate = releaseDate,
                        Bail = prisonerDto.Bail,
                        CellId = prisonerDto.CellId,
                        Mails = prisonerDto.Mails
                            .Select(m => new Mail
                            {
                                Description = m.Description,
                                Sender = m.Sender,
                                Address = m.Address
                            })
                            .ToArray()
                    };

                    validPrisoners.Add(prisoner);
                    sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                    continue; // TODO FIX BUG ???
                }
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(OfficerDto[]),
                new XmlRootAttribute("Officers"));

            OfficerDto[] allOfficers = (OfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Officer> validOfficers = new List<Officer>();
            StringBuilder sb = new StringBuilder();

            foreach (var officerDto in allOfficers)
            {
                bool isWeaponValid = Enum.TryParse(officerDto.Weapon, out Weapon weapon);
                bool isPositionValid = Enum.TryParse(officerDto.Position, out Position position);

                bool isValid = IsValid(officerDto) &&
                               isWeaponValid &&
                               isPositionValid;

                if (isValid)
                {
                    Officer officer = new Officer
                    {
                        FullName = officerDto.Name,
                        Salary = officerDto.Money,
                        Position = position,
                        Weapon = weapon,
                        DepartmentId = officerDto.DepartmentId,
                        OfficerPrisoners = officerDto.Prisoners
                            .Select(p => new OfficerPrisoner
                            {
                                PrisonerId = p.Id
                            })
                            .ToArray()
                    };

                    validOfficers.Add(officer);
                    sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);

            var validationResult = new List<ValidationResult>();

            bool isValid = Validator
                    .TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}