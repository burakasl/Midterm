using MidtermAPI.Entities;

namespace MidtermAPI.DataAccess
{
    public class TreatmentRepository : GenericRepository<Treatment>
    {
        public override List<Treatment> GetAll(int id)
        {
            return dbContext.Treatments.Where(x => x.PatientId == id).ToList();
        }
    }
}
