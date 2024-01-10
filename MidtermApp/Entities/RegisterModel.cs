using System;
namespace MidtermApp.Entities
{
    public enum Role
    {
        Doctor, Patient
    }

	public class RegisterModel
	{
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PersonnelNumber { get; set; }
        public string IsDoctor { get; set; }
        public bool IsActive { get; set; }
    }
}

