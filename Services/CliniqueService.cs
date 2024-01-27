using eHealth.Presentation.Models;

namespace eHealth.Presentation.Services
{
	public class CliniqueService : ICliniqueService
	{
		private HttpClient _httpClient;
		private IConfiguration _configuration;

        public CliniqueService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("eHealthApi:BaseAddress"));
		}

		public async Task<Uri> CreateClinique(Clinique clinique)
		{
			HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
				"/api/addclinique", clinique);
			response.EnsureSuccessStatusCode();
			return response.Headers.Location; 
		}

		public async Task<bool> DeleteClinique(int? id)
		{
			string deleteMessage = "Not deleted";
			HttpResponseMessage response = await _httpClient.DeleteAsync("/api/deleteclinique" + id.ToString());
			response.EnsureSuccessStatusCode();
			if (response.IsSuccessStatusCode)
			{
				deleteMessage = await response.Content.ReadAsStringAsync();
				return true;
			}
			else {
				return false;
			}
			
		}

		public async Task<Clinique> GetCliniqueById(int? id)
		{
			Clinique clinique = new Clinique();
			HttpResponseMessage response = await _httpClient.GetAsync("/api/clinique/" + id.ToString());
			if (response.IsSuccessStatusCode)
			{
				clinique = await response.Content.ReadFromJsonAsync<Clinique>();
			}
			return clinique;
		}

		public async Task<List<Clinique>> GetCliniques()
		{
			List<Clinique> cliniques = new List<Clinique>();
			HttpResponseMessage response = await _httpClient.GetAsync("/api/cliniques");
			if (response.IsSuccessStatusCode)
			{
				cliniques = await response.Content.ReadFromJsonAsync<List<Clinique>>();
			}
			return cliniques;
		}
	}
}
