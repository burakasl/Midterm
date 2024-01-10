using System.ComponentModel.DataAnnotations;

namespace MidtermAPI.Entities
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }
        public string MedicationName { get; set; }
        public string Prospectus { get; set; }
        public string? Notes { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool IsActive { get; set; }
    }
}
