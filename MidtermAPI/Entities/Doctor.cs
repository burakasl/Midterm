using System.ComponentModel.DataAnnotations;

namespace MidtermAPI.Entities
{
    public class Doctor : User
    {
        [Key]
        public int DoctorId { get; set; }
    }
}
