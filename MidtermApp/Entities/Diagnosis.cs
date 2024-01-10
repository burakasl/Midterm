using System.ComponentModel.DataAnnotations;

namespace MidtermApp.Entities
{
    public class Diagnosis
    {
        [Key] 
        public int DiagnosisId { get; set; }
        public string Description { get; set; }
        public DateOnly ResultDate { get; set; }
    }
}
