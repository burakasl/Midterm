using MidtermAPI.Entities;

namespace MidtermAPI.DataAccess
{
    public class DoctorRepository : GenericRepository<Doctor>
    {
        public override List<Doctor> GetAll(int id)
        {
            return dbContext.Treatments.Where(x => x.PatientId == id)
                .Select(x => x.Doctor)
                .Distinct().ToList();
        }

        public Doctor GetAsLogin(string email, string password)
        {
            return dbContext.Doctors.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
