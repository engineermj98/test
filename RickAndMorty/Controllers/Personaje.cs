using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Models;
using System.Diagnostics;

namespace RickAndMorty.Controllers
{
    public class Personaje : Controller
    {
        private readonly ModeloServicioAPI _apiService;

        public Personaje()
        {
            _apiService = new ModeloServicioAPI();
        }
        [Route("Personaje/VistaPersonaje")]
        public async Task<ActionResult> VistaPersonaje()
        {
            var characters = await _apiService.GetCharacters();
            return View(characters);
        }


        public async Task<ActionResult> ShowCharacterDetails()
        {
            var character = await _apiService.GetCharacterById(1);
            return View(character);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       

    }
}

