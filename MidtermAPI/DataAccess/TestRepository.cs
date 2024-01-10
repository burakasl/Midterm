using MidtermAPI.Entities;

namespace MidtermAPI.DataAccess
{
    public class TestRepository : GenericRepository<Test>
    {
        public override List<Test> GetAll(int id)
        {
            return dbContext.Treatments.Where(x => x.PatientId == id)
                .Select(x => x.Test)
                .Distinct().ToList();
        }
    }
}
