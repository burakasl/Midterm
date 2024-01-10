using Newtonsoft.Json;
using MidtermApp.Entities;

namespace MidtermApp.EntityManagers
{
    public class MedicationManager : GenericManager<Medication>
    {
        protected override string GetUrl()
        {
            return "http://api:3001/api/Medication/";
        }
    }
}