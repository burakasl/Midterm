using Newtonsoft.Json;
using MidtermApp.Entities;

namespace MidtermApp.EntityManagers
{
    public class TestManager : GenericManager<Test>
    {
        protected override string GetUrl()
        {
            return "http://api:3001/api/Test/";
        }
    }
}
