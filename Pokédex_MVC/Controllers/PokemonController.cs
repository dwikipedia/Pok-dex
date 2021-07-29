using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokédex.AppContext;
using Pokédex.Model;

namespace Pokédex_MVC.Controllers
{
    public class PokemonController : Controller
    {
        private readonly DataContext context;

        [BindProperty]
        public Pokemon Pokemon { get; set; }
        public PokemonController(DataContext _context) => context = _context;

        public List<SelectListItem> GenderList { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<Pokemon> GetById(int? id)
        {
            return await context.Pokemons.FirstOrDefaultAsync(x => x.PokemonId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            if (ModelState.IsValid)
            {
                if (Pokemon.PokemonId == 0)
                {
                    context.Pokemons.Add(Pokemon);
                }
                else context.Pokemons.Update(Pokemon);

                context.SaveChanges();
            }
            return View(Pokemon);
        }

        public async Task<IActionResult> Create(int? id)
        {
            GenderList = DropdownLists.DdlGender();
            ViewBag.DdlGender = GenderList;
            Pokemon = new Pokemon();

            if (id == null)
                return View(Pokemon);

            Pokemon = await GetById(id);
            if (Pokemon == null)
                return NotFound();

            return View(Pokemon);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            GenderList = DropdownLists.DdlGender();
            ViewBag.DdlGender = GenderList;
            Pokemon = new Pokemon();
            Pokemon = await GetById(id);

            if (Pokemon == null)
                return NotFound();

            return View(Pokemon);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await context.Pokemons.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await context.Pokemons.FirstOrDefaultAsync(a => a.PokemonId == id);
            if (data == null)
                return Json(new { success = false, message = "Delete failed." });

            context.Remove(data);
            await context.SaveChangesAsync();
            return Json(new { success = true, message = "Deleted successfully" });
        }
    }
}
