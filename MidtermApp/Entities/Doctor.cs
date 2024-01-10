using System.ComponentModel.DataAnnotations;

namespace MidtermApp.Entities
{
    public class Doctor : User
    {
        [Key]
        public int DoctorId { get; set; }
    }
}
