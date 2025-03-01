using FilmDB.BLAZOR.Models;
using System.Net.Http.Json;

namespace FilmDB.BLAZOR.Services
{
    public class FilmDBService
    {
        private readonly HttpClient _httpClient;

        public FilmDBService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }

        // Sender-Methoden
        public async Task<List<SenderModel>> GetSenderAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<SenderModel>>("api/sender") ?? new List<SenderModel>();
        }

        public async Task<SenderModel> CreateSenderAsync(SenderModel sender)
        {
            var response = await _httpClient.PostAsJsonAsync("api/sender", sender);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SenderModel>() ?? throw new Exception("Fehler beim Erstellen des Senders");
        }

        public async Task<SenderModel> UpdateSenderAsync(SenderModel sender)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/sender/{sender.ID}", sender);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SenderModel>() ?? throw new Exception("Fehler beim Aktualisieren des Senders");
        }

        public async Task DeleteSenderAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/sender/{id}");
            response.EnsureSuccessStatusCode();
        }

        // Gesehen-Methoden
        public async Task<List<GesehenModel>> GetGesehenAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<GesehenModel>>("api/gesehen") ?? new List<GesehenModel>();
        }

        public async Task<GesehenModel> CreateGesehenAsync(GesehenModel gesehen)
        {
            var response = await _httpClient.PostAsJsonAsync("api/gesehen", gesehen);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GesehenModel>() ?? throw new Exception("Fehler beim Erstellen des Gesehen-Eintrags");
        }

        public async Task<GesehenModel> UpdateGesehenAsync(GesehenModel gesehen)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/gesehen/{gesehen.ID}", gesehen);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GesehenModel>() ?? throw new Exception("Fehler beim Aktualisieren des Gesehen-Eintrags");
        }

        public async Task DeleteGesehenAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/gesehen/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
} 