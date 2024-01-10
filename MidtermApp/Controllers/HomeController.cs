using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MidtermApp.Entities;
using MidtermApp.EntityManagers;
using MidtermApp.Models;
using Newtonsoft.Json;

namespace MidtermApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Index(string email)
    {
        DoctorManager dc = new DoctorManager();

        Doctor doctor = await dc.GetByEmail(email);

        if (doctor == null)
        {
            PatientManager pc = new PatientManager();

            Patient patient = await pc.GetByEmail(email);

            if (patient == null)
            {
                TempData["Email"] = email;

                return RedirectToAction("Index", "Register");
            }

            else
            {
                TempData["Email"] = email;

                return RedirectToAction("Index", "Login");
            }
        }

        else
        {
            TempData["Email"] = email;

            return RedirectToAction("Index", "Login");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

