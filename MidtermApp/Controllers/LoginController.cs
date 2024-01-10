using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MidtermApp.Entities;
using MidtermApp.EntityManagers;
using Newtonsoft.Json;

namespace MidtermApp.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string password)
        {
            LoginModel formData = new LoginModel();
            formData.Email = TempData["Email"] as string;
            formData.Password = password;

            try
            {
                LoginManager loginManager = new LoginManager();

                LoginModel loginModel = await loginManager.GetAsLogin(formData);

                if (loginModel.result == LoginResult.NotFound)
                {
                    ViewBag.Error = "Lüften tekrar deneyin...";
                    TempData["Email"] = TempData["Email"];
                    return View("Index");
                }

                else
                {
                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, loginModel.Email),
                    new Claim(ClaimTypes.Role, loginModel.result.ToString())
                };

                    var userIdentity = new ClaimsIdentity(claims, "User");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("ViewAll", "Patient");
                }
            }

            catch (Exception ex)
            {
                ViewBag.Error = "Lüften tekrar deneyin...";
                TempData["Email"] = TempData["Email"];
                return View("Index");
            }

        }

        public async Task<int> GetClaimId()
        {
            var user = HttpContext.User;

            var claimValue = user.FindFirst(ClaimTypes.Role).Value;

            if (claimValue == "Doctor")
            {
                DoctorManager doctorManager = new DoctorManager();

                Doctor doctor = await doctorManager.GetByEmail(user.FindFirst(ClaimTypes.Email).Value);

                return doctor.DoctorId;
            }

            else if (claimValue == "Patient")
            {
                PatientManager patientManager = new PatientManager();

                Patient patient = await patientManager.GetByEmail(user.FindFirst(ClaimTypes.Email).Value);

                return patient.PatientId;
            }

            else
            {
                Console.WriteLine("test");

                return 0;
            }
        }
    }
}

