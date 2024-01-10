using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MidtermApp.Entities;
using MidtermApp.EntityManagers;

namespace MidtermApp.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(RegisterModel formData)
        {
            formData.Email = TempData["Email"] as string;

            try
            {
                if (formData.IsDoctor == "on")
                {
                    DoctorManager doctorManager = new DoctorManager();

                    bool numberCheck = await doctorManager.CheckPersonnel(formData.PersonnelNumber);

                    if (!numberCheck)
                    {
                        TempData["Email"] = TempData["Email"];
                        ViewBag.Error = "Lütfen tekrar deneyin...";
                        return View("Index");
                    }

                    Doctor doctor = doctorManager.CreateDoctor(formData);

                    var result = await doctorManager.Add(doctor);

                    if (result)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        TempData["Email"] = TempData["Email"];
                        ViewBag.Error = "Lütfen tekrar deneyin...";
                        return View("Index");
                    }
                }

                else
                {
                    PatientManager patientManager = new PatientManager();
                    Patient patient = patientManager.CreatePatient(formData);

                    var result = await patientManager.Add(patient);

                    if (result)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        TempData["Email"] = TempData["Email"];
                        ViewBag.Error = "Lütfen tekrar deneyin...";
                        return View("Index");
                    }
                }
            }

            catch (Exception ex)
            {
                TempData["Email"] = TempData["Email"];
                ViewBag.Error = "Lütfen tekrar deneyin...";
                return View("Index");
            }
        }
    }
}

