﻿using System;
namespace MidtermApp.Entities
{
	public class User
	{
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}

