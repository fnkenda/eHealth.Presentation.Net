using eHealth.Presentation.Models;

namespace eHealth.Presentation.Services
{
	public interface ICliniqueService
	{
		Task<List<Clinique>> GetCliniques();
		Task<Clinique> GetCliniqueById(int? id);
		Task<bool> DeleteClinique(int? id);
		Task<Uri> CreateClinique(Clinique clinique);
	}
}
