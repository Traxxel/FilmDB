using FilmDB.BLAZOR.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components;

namespace FilmDB.BLAZOR.Services
{
    public class FilmDBService
    {
        private readonly HttpClient _httpClient;
        private readonly IAccessTokenProvider _tokenProvider;
        private readonly NavigationManager _navigationManager;

        public FilmDBService(IHttpClientFactory clientFactory, IAccessTokenProvider tokenProvider, NavigationManager navigationManager)
        {
            _httpClient = clientFactory.CreateClient("FilmDB.API");
            _tokenProvider = tokenProvider;
            _navigationManager = navigationManager;
        }

        private async Task EnsureTokenAsync()
        {
            var tokenResult = await _tokenProvider.RequestAccessToken();
            if (tokenResult.TryGetToken(out var token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Value);
            }
            else
            {
                throw new AccessTokenNotAvailableException(_navigationManager, tokenResult, null);
            }
        }

        // Sender-Methoden
        public async Task<List<SenderModel>> GetSenderAsync()
        {
            try 
            {
                return await _httpClient.GetFromJsonAsync<List<SenderModel>>("api/sender") ?? new List<SenderModel>();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return new List<SenderModel>();
            }
        }

        public async Task<SenderModel> CreateSenderAsync(SenderModel sender)
        {
            try 
            {
                var response = await _httpClient.PostAsJsonAsync("api/sender", sender);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<SenderModel>() ?? throw new Exception("Fehler beim Erstellen des Senders");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                throw;
            }
        }

        public async Task<SenderModel> UpdateSenderAsync(SenderModel sender)
        {
            try 
            {
                var response = await _httpClient.PutAsJsonAsync($"api/sender/{sender.ID}", sender);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<SenderModel>() ?? throw new Exception("Fehler beim Aktualisieren des Senders");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                throw;
            }
        }

        public async Task DeleteSenderAsync(int id)
        {
            try 
            {
                var response = await _httpClient.DeleteAsync($"api/sender/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        // Gesehen-Methoden
        public async Task<List<GesehenModel>> GetGesehenAsync()
        {
            try 
            {
                return await _httpClient.GetFromJsonAsync<List<GesehenModel>>("api/gesehen") ?? new List<GesehenModel>();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return new List<GesehenModel>();
            }
        }

        public async Task<GesehenModel> CreateGesehenAsync(GesehenModel gesehen)
        {
            try 
            {
                var response = await _httpClient.PostAsJsonAsync("api/gesehen", gesehen);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<GesehenModel>() ?? throw new Exception("Fehler beim Erstellen des Gesehen-Eintrags");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                throw;
            }
        }

        public async Task<GesehenModel> UpdateGesehenAsync(GesehenModel gesehen)
        {
            try 
            {
                var response = await _httpClient.PutAsJsonAsync($"api/gesehen/{gesehen.ID}", gesehen);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<GesehenModel>() ?? throw new Exception("Fehler beim Aktualisieren des Gesehen-Eintrags");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                throw;
            }
        }

        public async Task DeleteGesehenAsync(int id)
        {
            try 
            {
                var response = await _httpClient.DeleteAsync($"api/gesehen/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
} 