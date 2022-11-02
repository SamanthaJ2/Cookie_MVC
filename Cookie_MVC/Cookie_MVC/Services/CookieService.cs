
using Cookie_MVC.Helpers;
using Cookie_MVC.Models;
using Cookie_MVC.Services.Interfaces;

namespace Cookie_MVC.Services
{
    public class CookieService : ICookieService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Cookies/";

        public CookieService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Cookie>> FindAll()
        {
            var responseGet = await _client.GetAsync(BasePath);

            var response = await responseGet.ReadContentAsync<List<Cookie>>();

            return response;
        }

        public async Task<Cookie> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);

            var response = await responseGet.ReadContentAsync<Cookie>();

            var cookie = new Cookie(response.Id, response.Name, response.Flavor, response.Quantity);

            return cookie;
        }

    }
}
