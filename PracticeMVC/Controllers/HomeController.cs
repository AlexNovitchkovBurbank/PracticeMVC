using Microsoft.AspNetCore.Mvc;
using PracticeMVC.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace PracticeMVC.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("OnPost_SendingContentIntNotInUrl")]
        public async Task OnPost_SendingContentIntNotInUrl(string input)
        {
            HttpClient client = new HttpClient();

            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Port = 7000;
            uriBuilder.Path = "Home/Receive_ContentIntNotInUrl";
            uriBuilder.Host = "localhost";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uriBuilder.Uri);
            StringContent stringContent = new StringContent(input, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = stringContent;

            var result = await client.SendAsync(httpRequestMessage);

            Console.WriteLine(result.Content.ReadAsStringAsync().Result);
        }

        [HttpPost]
        [Route("OnPost_SendingContentIntInUrl")]
        public async Task OnPost_SendingContentIntInUrl(string input)
        {
            HttpClient client = new HttpClient();

            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Port = 7000;
            uriBuilder.Path = "Home/Receive_ContentIntInUrl/" + input + 1;
            uriBuilder.Host = "localhost";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uriBuilder.Uri);
            StringContent stringContent = new StringContent(input, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = stringContent;

            var result = await client.SendAsync(httpRequestMessage);

            Console.WriteLine(result.Content.ReadAsStringAsync().Result);
        }

        [HttpPost]
        [Route("OnPost_SendingContentStringNotInUrl")]
        public async Task OnPost_SendingContentStringNotInUrl(string input)
        {
            HttpClient client = new HttpClient();

            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Port = 7000;
            uriBuilder.Path = "Home/Receive_ContentStringNotInUrl";
            uriBuilder.Host = "localhost";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uriBuilder.Uri);
            StringContent stringContent = new StringContent("\"" + input + "\"", Encoding.UTF8, "application/json");
            httpRequestMessage.Content = stringContent;

            var result = await client.SendAsync(httpRequestMessage);

            Console.WriteLine(result.Content.ReadAsStringAsync().Result);
        }

        [HttpPost]
        [Route("OnPost_SendingContentStringInUrl")]
        public async Task OnPost_SendingContentStringInUrl(string input)
        {
            HttpClient client = new HttpClient();

            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Port = 7000;
            uriBuilder.Path = "Home/Receive_ContentStringInUrl/" + input + "a";
            uriBuilder.Host = "localhost";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uriBuilder.Uri);
            StringContent stringContent = new StringContent(input, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = stringContent;

            var result = await client.SendAsync(httpRequestMessage);

            Console.WriteLine(result.Content.ReadAsStringAsync().Result);
        }
    }
}