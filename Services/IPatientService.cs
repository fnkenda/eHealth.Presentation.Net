using eHealth.Presentation.Models;

namespace eHealth.Presentation.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAll();

        Task<Patient> GetById(int? id);

        Task<Patient> SavePatient(Patient patient);

        Task<Patient> UpdatePatient(Patient patient);

        Task<string> DeletePatient(int? id);
    }
}
