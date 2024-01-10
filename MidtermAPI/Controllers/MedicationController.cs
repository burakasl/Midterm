using System;
using MidtermAPI.DataAccess;
using MidtermAPI.Entities;

namespace MidtermAPI.Controllers
{
	public class MedicationController : GenericController<Medication>
	{
		public MedicationController()
		{
			repository = new MedicationRepository();
		}
	}
}

