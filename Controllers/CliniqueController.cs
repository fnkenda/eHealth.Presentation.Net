using eHealth.Presentation.Models;
using eHealth.Presentation.Services;
using Microsoft.AspNetCore.Mvc;

namespace eHealth.Presentation.Controllers
{
	public class CliniqueController : Controller
	{
		private ICliniqueService _cliniqueService;
		private List<Clinique> _cliniques;


        public CliniqueController(ICliniqueService cliniqueService)
        {
            _cliniqueService = cliniqueService;
			_cliniques = _cliniqueService.GetCliniques().Result;
        }


        public IActionResult Index()
		{
			return View(_cliniques);
		}

		public IActionResult Details(Clinique clinique) {
			return View(clinique);
		}
		
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Clinique clinique)
		{
			if (ModelState.IsValid)
			{

				await _cliniqueService.CreateClinique(clinique);

				_cliniques = await _cliniqueService.GetCliniques();
				RedirectToAction("Index");
			}
			return View(clinique);
		}

	}
}
