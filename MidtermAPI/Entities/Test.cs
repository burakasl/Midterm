using System.ComponentModel.DataAnnotations;

namespace MidtermAPI.Entities
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime? ResultDate { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
