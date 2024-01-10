using MidtermAPI.Entities;

namespace MidtermAPI.DataAccess
{
    public class MedicationRepository : GenericRepository<Medication>
    {
        public override List<Medication> GetAll(int id)
        {
            return dbContext.Treatments.Where(x => x.PatientId == id)
                .Select(x => x.Medication)
                .Distinct().ToList();
        }
    }
}
