using eHealth.Presentation.Filters;
using eHealth.Presentation.Models;
using eHealth.Presentation.Services;
using Microsoft.AspNetCore.Mvc;

namespace eHealth.Presentation.Controllers
{
    public class MedecinsController : Controller
	{
		//private IEhealthRepository repository;

		private  IMedecinsService _medecinsService;

		private List<Medecin> _medecins;
		public  MedecinsController(IMedecinsService medecinsService)
		{
			_medecinsService = medecinsService;
			_medecins = _medecinsService.GetMedecins().Result;

        }

		public IActionResult Index()
		{

			if (_medecins == null)
			{
				return NotFound();
			}

			return View(_medecins);
		}

		[ServiceFilter(typeof(LogActionFilterAttribute))]
		public async Task<IActionResult> Details(int? id)
		{
			var medecin = await _medecinsService.GetMedecinById(id);

			if (medecin == null)
			{
				return NotFound(nameof(medecin));
			}

			return View(medecin);
		}

	
        public async Task<IActionResult> Supprimer(int? id)
        {
            var medecin = await _medecinsService.GetMedecinById(id);

            if (medecin == null)
            {
                return NotFound(nameof(medecin));
            }

            return View(medecin);
        }


        [HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Medecin medecin)
		{
			if (ModelState.IsValid)
			{

				await _medecinsService.CreateMedecin(medecin);


                _medecins = await _medecinsService.GetMedecins();
                return RedirectToAction("Index");
			}
			return View(medecin);
		}


	}
}
