namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Medicament
    {
        public int MedicalId { get; set; }
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}