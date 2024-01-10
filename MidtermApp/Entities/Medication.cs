using System.ComponentModel.DataAnnotations;

namespace MidtermApp.Entities
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }
        public string MedicationName { get; set; }
        public string Prospectus { get; set; }
        public string Notes { get; set; }
        public DateOnly CommencementDate { get; set; }
        public DateOnly CompletionDate { get; set; }
        public bool IsActive { get; set; }
    }
}
