using System;
using MidtermAPI.DataAccess;
using MidtermAPI.Entities;

namespace MidtermAPI.Controllers
{
	public class TestController : GenericController<Test>
	{
		public TestController()
		{
			repository = new TestRepository();
		}
	}
}

