using eHealth.Presentation.Models;

namespace eHealth.Presentation.Services
{
    public class PatientService : IPatientService
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;

        public PatientService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("patientApi:BaseAddress"));
        }
        public async Task<string> DeletePatient(int? id)
        {
            string deleteMessage = "Not deleted";
            HttpResponseMessage response = await _httpClient.DeleteAsync("/deletePatient/" + id.ToString());
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                deleteMessage = await response.Content.ReadAsStringAsync();
            }
            return deleteMessage;
        }

        public async Task<List<Patient>> GetAll()
        {
            List<Patient> patients = new List<Patient>();
            HttpResponseMessage response = await  _httpClient.GetAsync("/Patient");
            if (response.IsSuccessStatusCode)
            {
                patients = await response.Content.ReadFromJsonAsync<List<Patient>>();
            }
            return patients;
        }

        public async Task<Patient> GetById(int? id)
        {
            Patient patient = new Patient();
            HttpResponseMessage response = await _httpClient.GetAsync("/patient/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                patient = await response.Content.ReadFromJsonAsync<Patient>();
            }
            return patient;
        }

        public async Task<Patient> SavePatient(Patient patient)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
				"/savePatientData", patient);
            response.EnsureSuccessStatusCode();
            return patient;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/updatePatient", patient);
            response.EnsureSuccessStatusCode();
            return patient;
        }


    }
}
