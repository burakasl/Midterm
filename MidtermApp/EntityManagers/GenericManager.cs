using Newtonsoft.Json;
using MidtermApp.Entities;

namespace MidtermApp.EntityManagers
{
    public abstract class GenericManager<T> where T : class
    {
        protected abstract string GetUrl();

        public async Task<T> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetUrl());

                HttpResponseMessage response = await client.GetAsync($"GetByID/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    T result = JsonConvert.DeserializeObject<T>(data);

                    return result;
                }

                else
                {
                    return null;
                }
            }
        }

        public async Task<List<T>> GetAll(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetUrl());

                HttpResponseMessage response = await client.GetAsync($"GetAll/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    List<T> result = JsonConvert.DeserializeObject<List<T>>(data);

                    return result;
                }

                else
                {
                    return null;
                }
            }

        }

        public async Task<bool> Add(T t)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetUrl());

                HttpResponseMessage response = await client.PostAsJsonAsync("Add", t);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Update(T t)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetUrl());

                HttpResponseMessage response = await client.PutAsJsonAsync("", t);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Remove(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetUrl());

                HttpResponseMessage response = await client.DeleteAsync(id.ToString());

                return response.IsSuccessStatusCode;
            }
        }
    }
}
