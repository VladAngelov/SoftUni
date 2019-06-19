﻿namespace SoftJail.DataProcessor
{
    using Data;
    using ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisonersToExport = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => new
                        {
                            OfficerName = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers
                        .Select(po => po.Officer.Salary)
                        .Sum()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(prisonersToExport, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(',');

            var prisonersToExport = context
                .Prisoners
                .Where(p => names.Contains(p.FullName))
                .Select(p => new PrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate
                        .ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails
                        .Select(m => new MailDto
                        {
                            Description = ReverseString(m.Description)
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var serializer = new XmlSerializer(
                typeof(PrisonerDto[]),
                new XmlRootAttribute("Prisoners"));

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(
                new StringWriter(sb), 
                prisonersToExport,
                new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty}));

            string result = sb.ToString().TrimEnd();
            return result;
        }

        private static string ReverseString(string text)
        {
            return string.Join("", text.Reverse());
        }
    }
}