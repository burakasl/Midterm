using MidtermAPI.Entities;

namespace MidtermAPI.DataAccess
{
    public class PatientRepository : GenericRepository<Patient>
    {
        public override List<Patient> GetAll(int id)
        {
            return dbContext.Treatments.Where(x => x.DoctorId == id)
                .Select(x => x.Patient)
                .Distinct().ToList();
        }

        public Patient GetAsLogin(string email, string password)
        {
            return dbContext.Patients.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
