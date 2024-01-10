using Newtonsoft.Json;
using MidtermApp.Entities;

namespace MidtermApp.EntityManagers
{
    public class DiagnosisManager : GenericManager<Diagnosis>
    {
        protected override string GetUrl()
        {
            return "http://api:3001/api/Diagnosis/";
        }
    }
}

