using System;
using System.ComponentModel.DataAnnotations;

namespace MidtermAPI.Entities
{
	public class PersonnelNumber
	{
		[Key]
		public int Id { get; set; }
		public string Number { get; set; }
	}
}

