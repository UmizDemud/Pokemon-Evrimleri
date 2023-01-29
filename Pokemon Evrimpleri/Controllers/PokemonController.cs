using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon_Evrimpleri.Models;
using Pokemon_Evrimpleri.RequestModule;

namespace Pokemon_Evrimpleri.Controllers
{
    public class PokemonController : Controller
    {

        // GET: PokemonController
        public async Task<ActionResult> Index()
        {
            await PokemonProcessor.Setup();
            ViewBag.id = 1;
            return View(await PokemonProcessor.ProcessIntoModel(0, 20));
        }

        // GET: PokemonController
        public async Task<ActionResult> List(int id)
        {
            ViewBag.id = id;
            return View("index", await PokemonProcessor.ProcessIntoModel((id - 1) * 20, (id) * 20));
        }

        // GET: PokemonController/pikachu
        public async Task<ActionResult> Details(int id)
        {
            return View(await PokemonProcessor.ProcessOneIntoModel(id));
        }
    }
}
