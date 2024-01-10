using System;
using MidtermApp.Entities;
using Newtonsoft.Json;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MidtermApp.Entities;
using MidtermApp.EntityManagers;

namespace MidtermApp.EntityManagers
{
	public class LoginManager
	{
		public async Task<LoginModel> GetAsLogin(LoginModel formData)
		{
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api:3001/");

                HttpResponseMessage response = await client.PostAsJsonAsync("api/Login/CheckLogin", formData);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    LoginModel loginResult = JsonConvert.DeserializeObject<LoginModel>(data);

                    return loginResult;
                }

                else
                {
                    return null;
                }
            }
        }
	}
}

