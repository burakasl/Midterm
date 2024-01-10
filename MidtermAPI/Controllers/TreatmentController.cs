using System;
using MidtermAPI.DataAccess;
using MidtermAPI.Entities;

namespace MidtermAPI.Controllers
{
	public class TreatmentController : GenericController<Treatment>
	{
		public TreatmentController()
		{
			repository = new TreatmentRepository();
		}
	}
}