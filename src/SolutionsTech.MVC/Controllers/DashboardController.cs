using Microsoft.AspNetCore.Mvc;

namespace SolutionsTech.MVC.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
