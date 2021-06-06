using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSolar.Data;
using MvcSolar.Models;

namespace MvcSolar.Controllers
{
    public class MeteorologiasController : Controller
    {
        private readonly MvcSolarContext _context;

        public MeteorologiasController(MvcSolarContext context)
        {
            _context = context;
        }

        // GET: Meteorologias
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "data_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var meteorologias = from s in _context.Meteorologias
                                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                meteorologias = meteorologias.Where(s => s.SkyCondition.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "nome_desc":
                    meteorologias = meteorologias.OrderByDescending(s => s.WeatherType);
                    break;
                case "Data":
                    meteorologias = meteorologias.OrderBy(s => s.SkyCondition);
                    break;
                case "data_desc":
                    meteorologias = meteorologias.OrderByDescending(s => s.SkyCondition);
                    break;
                default:
                    meteorologias = meteorologias.OrderBy(s => s.WeatherType);
                    break;
            }
            return View(await _context.Meteorologias.ToListAsync());
        }

        // GET: Meteorologias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meteorologia = await _context.Meteorologias
                .FirstOrDefaultAsync(m => m.MeteorologiaID == id);
            if (meteorologia == null)
            {
                return NotFound();
            }

            return View(meteorologia);
        }

        // GET: Meteorologias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meteorologias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeteorologiaID,WeatherType,SkyCondition,ProbPrecipitacao,Sunrise,Sunset")] Meteorologia meteorologia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meteorologia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meteorologia);
        }

        // GET: Meteorologias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meteorologia = await _context.Meteorologias.FindAsync(id);
            if (meteorologia == null)
            {
                return NotFound();
            }
            return View(meteorologia);
        }

        // POST: Meteorologias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeteorologiaID,WeatherType,SkyCondition,ProbPrecipitacao,Sunrise,Sunset")] Meteorologia meteorologia)
        {
            if (id != meteorologia.MeteorologiaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meteorologia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeteorologiaExists(meteorologia.MeteorologiaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meteorologia);
        }

        // GET: Meteorologias/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meteorologia = await _context.Meteorologias
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MeteorologiaID == id);
            if (meteorologia == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Apagar falhou. Tente outra vez, e se o problema persistir, contacte o administrador.";
            }

            return View(meteorologia);
        }

        // POST: Meteorologias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meteorologia = await _context.Meteorologias.FindAsync(id);
            if (meteorologia == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Meteorologias.Remove(meteorologia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool MeteorologiaExists(int id)
        {
            return _context.Meteorologias.Any(e => e.MeteorologiaID == id);
        }
    }
}
