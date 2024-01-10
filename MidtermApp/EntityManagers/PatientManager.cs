using Newtonsoft.Json;
using MidtermApp.Entities;

namespace MidtermApp.EntityManagers
{
    public class PatientManager : GenericManager<Patient>
    {
        protected override string GetUrl()
        {
            return "http://api:3001/api/Patient/";
        }

        public Patient CreatePatient(RegisterModel data)
        {
            Patient patient = new Patient();

            patient.FullName = data.FullName;
            patient.Username = data.Username;
            patient.Email = data.Email;
            patient.Password = data.Password;
            patient.IsActive = true;

            return patient;
        }

        public async Task<Patient> GetByEmail(string email)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetUrl());

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"GetByEmail/{email}");

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<Patient>(data);
                    }

                    else
                    {
                        return null;
                    }
                }

                catch (Exception ex)
                {
                    return null;
                }
                
            }
        }
    }
}