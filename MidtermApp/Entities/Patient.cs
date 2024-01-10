using System.ComponentModel.DataAnnotations;

namespace MidtermApp.Entities
{
    public class Patient : User
    {
        [Key]
        public int PatientId { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }

        public List<Medication>? ChronicMedications { get; set; }
    }
}
