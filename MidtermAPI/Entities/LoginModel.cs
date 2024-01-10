using System;

namespace MidtermAPI.Entities
{
    public enum LoginResult
    {
        Doctor, Patient, NotFound
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginResult result { get; set; }
    }
}

