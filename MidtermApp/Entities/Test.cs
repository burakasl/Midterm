using System.ComponentModel.DataAnnotations;

namespace MidtermApp.Entities
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public DateOnly ResultDate { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
