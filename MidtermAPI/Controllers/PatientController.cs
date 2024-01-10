using System;
using Microsoft.AspNetCore.Mvc;
using MidtermAPI.Context;
using MidtermAPI.DataAccess;
using MidtermAPI.Entities;

namespace MidtermAPI.Controllers
{
	public class PatientController : GenericController<Patient>
	{
		public PatientController()
		{
			repository = new PatientRepository();
		}

        [HttpGet("GetByEmail/{email}")]
        public ActionResult GetByEmail(string email)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Patient? result = context.Patients.FirstOrDefault(x => x.Email == email);

                if (result == null)
                {
                    return NotFound();
                }

                else
                {
                    return Ok(result);
                }


            }
        }
    }
}

