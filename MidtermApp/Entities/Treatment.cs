using System.ComponentModel.DataAnnotations;

namespace MidtermApp.Entities
{
    public class Treatment
    {
        [Key]
        public int TreatmentId { get; set; }
        public bool IsActive { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }

        public int? MedicationId { get; set; }
        public Medication Medication { get; set; }
    }
}
