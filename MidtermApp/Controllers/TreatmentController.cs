using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MidtermApp.Entities;
using MidtermApp.EntityManagers;

namespace MidtermApp.Controllers
{
    public class TreatmentController : GenericController<Treatment>
    {
        protected override GenericManager<Treatment> GetManager()
        {
            return new TreatmentManager();
        }
    }
}

