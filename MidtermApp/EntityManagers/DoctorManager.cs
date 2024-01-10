using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MidtermApp.Entities;

namespace MidtermApp.EntityManagers
{
    public class DoctorManager : GenericManager<Doctor>
    {
        protected override string GetUrl()
        {
            return "http://api:3001/api/Doctor/";
        }

        public Doctor CreateDoctor(RegisterModel data)
        {
            Doctor doctor = new Doctor();

            doctor.FullName = data.FullName;
            doctor.Username = data.Username;
            doctor.Email = data.Email;
            doctor.Password = data.Password;
            doctor.IsActive = true;

            return doctor;
        }

        public async Task<Doctor> GetByEmail(string email)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetUrl());

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"GetByEmail/{email}");

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("test");

                        string data = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<Doctor>(data);
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

        public async Task<List<Patient>> GetAllPatients(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetUrl());

                HttpResponseMessage response = await client.GetAsync($"GetAllPatients/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<Patient>>(data);
                }

                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> CheckPersonnel(string number)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetUrl());

                HttpResponseMessage response = await client.GetAsync($"CheckPersonnel/{number}");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<bool>(data);
                }

                else
                {
                    return false;
                }
            }
        }
    }
}
