using Microsoft.AspNetCore.Mvc;
using MidtermAPI.Entities;
using MidtermAPI.DataAccess;
using MidtermAPI.Context;

namespace MidtermAPI.Controllers
{
    
    public class DoctorController : GenericController<Doctor>
    {
        public DoctorController()
        {
            repository = new DoctorRepository();
        }

        [HttpGet("GetByEmail/{email}")]
        public ActionResult GetByEmail(string email)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Doctor? result = context.Doctors.FirstOrDefault(x => x.Email == email);

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

        [HttpGet("GetAllPatients/{id}")]
        public ActionResult GetAllPatients(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                List<Patient> patients = context.Treatments
                    .Where(x => x.DoctorId == id)
                    .Select(x => x.Patient)
                    .Distinct().ToList();

                return Ok(patients);
            }
        }

        [HttpGet("CheckPersonnel/{number}")]
        public ActionResult CheckPersonnel(string number)
        {
            using (AppDbContext context = new AppDbContext())
            {
                bool doesExist = context.PersonnelNumbers.Any(x => x.Number == number);

                return Ok(doesExist);
            }
        }
    }
}
