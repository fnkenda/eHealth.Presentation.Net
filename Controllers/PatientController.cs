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
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                int nextPatientId = _patients.Max(p => p.idPatient) + 1;
                await _patientService.SavePatient(
                    new Patient
                    {
                        idPatient = nextPatientId,
                        name = patient.name,
                        eMail = patient.eMail,
                        tel = patient.tel
                    });
                _patients = await _patientService.GetAll();
                return RedirectToAction("Index");
            }

            return View(patient);
        }
    }
}
