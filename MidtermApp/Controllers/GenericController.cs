using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MidtermApp.Entities;
using MidtermApp.EntityManagers;

namespace MidtermApp.Controllers
{
    public abstract class GenericController<T> : Controller where T : class
    {
        protected abstract GenericManager<T> GetManager();

        [HttpGet]
        public async Task<ActionResult> ViewAll()
        {
            try
            {
                GenericManager<T> genericManager = GetManager();

                LoginController loginController = new LoginController();

                int id = await loginController.GetClaimId();

                List<T> result = await genericManager.GetAll(id);

                return View(result);
            }

            catch (Exception ex)
            {
                return View();
            }

            
        }

        [HttpGet]
        public async Task<ActionResult> ViewDetails(int id)
        {
            try
            {
                GenericManager<T> genericManager = GetManager();

                T result = await genericManager.GetById(id);

                return View(result);
            }

            catch (Exception ex)
            {
                return View();
            }
        }
    }
}

