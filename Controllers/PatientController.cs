using eHealth.Presentation.Models;
using eHealth.Presentation.Services;
using Microsoft.AspNetCore.Mvc;

namespace eHealth.Presentation.Controllers
{
    public class PatientController : Controller
    {
        private IPatientService _patientService;
        private List<Patient> _patients;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
            _patients = _patientService.GetAll().Result;
        }


        public IActionResult Index()
        {
            return View(_patients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            return View();
        }
    }
}
