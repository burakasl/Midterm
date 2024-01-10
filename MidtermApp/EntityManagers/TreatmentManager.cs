using Newtonsoft.Json;
using MidtermApp.Entities;

namespace MidtermApp.EntityManagers
{
    public class TreatmentManager : GenericManager<Treatment>
    {
        protected override string GetUrl()
        {
            return "http://api:3001/api/Treatment/";
        }
    }
}