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
    public class AvariasController : Controller
    {
        private readonly MvcSolarContext _context;

        public AvariasController(MvcSolarContext context)
        {
            _context = context;
        }

        // GET: Avarias
        public async Task<IActionResult> Index(string sortOrder)
        {
            var mvcSolarContext = _context.Avarias.Include(a => a.Habitacao);

            ViewData["DateSortParm"] = sortOrder;

            var avarias = from s in _context.Avarias
                          select s;
            switch (sortOrder)
            {
                case "Data":
                    avarias = avarias.OrderBy(s => s.Data);
                    break;
                default:
                    avarias = avarias.OrderByDescending(s => s.Data);
                    break;
            }
            return View(await avarias.AsNoTracking().ToListAsync());
        }

        // GET: Avarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaria = await _context.Avarias
                .Include(a => a.Habitacao)
                .FirstOrDefaultAsync(m => m.AvariaID == id);
            if (avaria == null)
            {
                return NotFound();
            }

            return View(avaria);
        }

        // GET: Avarias/Create
        public IActionResult Create()
        {
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID");
            return View();
        }

        // POST: Avarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvariaID,HabitacaoID,Data")] Avaria avaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", avaria.HabitacaoID);
            return View(avaria);
        }

        // GET: Avarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaria = await _context.Avarias.FindAsync(id);
            if (avaria == null)
            {
                return NotFound();
            }
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", avaria.HabitacaoID);
            return View(avaria);
        }

        // POST: Avarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvariaID,HabitacaoID,Data")] Avaria avaria)
        {
            if (id != avaria.AvariaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvariaExists(avaria.AvariaID))
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
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", avaria.HabitacaoID);
            return View(avaria);
        }

        // GET: Avarias/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaria = await _context.Avarias
                .AsNoTracking()
                .Include(a => a.Habitacao)
                .FirstOrDefaultAsync(m => m.AvariaID == id);
            if (avaria == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Apagar falhou. Tente outra vez, e se o problema persistir, contacte o administrador.";
            }

            return View(avaria);
        }

        // POST: Avarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avaria = await _context.Avarias.FindAsync(id);
            if (avaria == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Avarias.Remove(avaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool AvariaExists(int id)
        {
            return _context.Avarias.Any(e => e.AvariaID == id);
        }
    }
}
