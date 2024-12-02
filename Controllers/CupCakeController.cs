using HappyCakes.Models;
using Microsoft.AspNetCore.Mvc;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using HappyCakes.Extensions;

namespace HappyCakes.Controllers
{
    public class CupCakeController : Controller
    {
        private readonly IFirebaseClient _firebaseClient;

        public CupCakeController(IFirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient;
        }

        // Método para pegar todos os cupcakes
        public IActionResult Index()
        {
            var response = _firebaseClient.Get("cupcakes");
            var cupcakes = JsonConvert.DeserializeObject<List<CupCake>>(response.Body);
            cupcakes = cupcakes.Where(c => c != null).ToList();
            return View(cupcakes);
        }

        // Método para detalhes do cupcake
        public IActionResult Details(int id)
        {
            var response = _firebaseClient.Get($"cupcakes/{id}");
            var cupcake = JsonConvert.DeserializeObject<CupCake>(response.Body);

            if (cupcake == null)
                return NotFound();

            return View(cupcake);
        }
    }
}
