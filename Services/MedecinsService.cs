using eHealth.Presentation.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;

namespace eHealth.Presentation.Services
{
    //https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
    public class MedecinsService : IMedecinsService
    { 
        private readonly IConfiguration _configuration;

        
        private  HttpClient _httpClient;

        public MedecinsService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("eHealthApi:BaseAddress"));

            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<Uri> CreateMedecin(Medecin medecin)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
                "/api/create", medecin);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<bool> DeleteMedecin(int? id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/delete/" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<Medecin> GetMedecinById(int? id)
        {
            Medecin medecin = null;

            HttpResponseMessage response = await _httpClient.GetAsync("/api/medecin/" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                medecin = await response.Content.ReadFromJsonAsync<Medecin>();
            }

            return medecin;
        }

        public async Task<List<Medecin>> GetMedecins()
        {
            List<Medecin> medecins = null;

            HttpResponseMessage response = await _httpClient.GetAsync("/api/medecins");

            if (response.IsSuccessStatusCode) {
                medecins = await response.Content.ReadFromJsonAsync<List<Medecin>>();
            }

            return medecins;
        }
    }
}
