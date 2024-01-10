using System.ComponentModel.DataAnnotations;

namespace MidtermAPI.Entities
{
    public class Treatment
    {
        [Key]
        public int TreatmentId { get; set; }
        public bool IsActive { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string Diagnosis { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }

        public int? MedicationId { get; set; }
        public Medication Medication { get; set; }

        public int? TestId { get; set; }
        public Test Test { get; set; }

    }
}
