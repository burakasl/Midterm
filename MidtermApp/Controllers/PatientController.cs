using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MidtermApp.Entities;
using MidtermApp.EntityManagers;

namespace MidtermApp.Controllers
{
    public class PatientController : GenericController<Patient>
    {
        protected override GenericManager<Patient> GetManager()
        {
            return new PatientManager();
        }
    }
}

