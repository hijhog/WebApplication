using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.UsersApi.Controllers
{
    [Route("{controller}/{action}")]
    public class SiteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SiteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetOrders()
        {
            //identity server
            var authClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await authClient.GetDiscoveryDocumentAsync("https://localhost:10001");

            var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest 
                { 
                    Address = discoveryDocument.TokenEndpoint,

                    ClientId = "client_id",
                    ClientSecret = "client_secret",

                    Scope = "OrderAPI"
                });

            //orders api
            var ordersClient = _httpClientFactory.CreateClient();

            ordersClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await ordersClient.GetAsync("https://localhost:5001/site/secret");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Message = response.StatusCode.ToString();
                return View();
            }

            var message = await response.Content.ReadAsStringAsync();

            ViewBag.Message = message;

            return View();
        }
    }
}
