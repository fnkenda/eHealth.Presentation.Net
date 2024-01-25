using eHealth.Presentation.Models;

namespace eHealth.Presentation.Services
{
    public interface IMedecinsService
    {
        Task<List<Medecin>> GetMedecins();
        Task<Medecin> GetMedecinById(int? id);
        Task<bool> DeleteMedecin(int? id);
        Task<Uri> CreateMedecin(Medecin medecin);
    }
}
