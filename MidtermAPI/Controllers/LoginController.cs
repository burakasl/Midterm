using System;
using Microsoft.AspNetCore.Mvc;
using MidtermAPI.Context;
using MidtermAPI.DataAccess;
using MidtermAPI.Entities;

namespace MidtermAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class LoginController : ControllerBase
	{
        [HttpPost("CheckLogin")]
        public ActionResult CheckLogin([FromBody] LoginModel formData)
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.GetAsLogin(formData.Email, formData.Password);

            if (patient != null)
            {
                formData.result = LoginResult.Patient;

                return Ok(formData);
            }

            else
            {
                DoctorRepository doctorRepository = new DoctorRepository();

                Doctor doctor = doctorRepository.GetAsLogin(formData.Email, formData.Password);

                if (doctor != null)
                {
                    formData.result = LoginResult.Doctor;

                    return Ok(formData);
                }

                else
                {
                    formData.result = LoginResult.NotFound;

                    return Ok(formData);
                }
            }
        }
    }
}

