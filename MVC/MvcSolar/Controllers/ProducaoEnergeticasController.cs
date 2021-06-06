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
    public class ProducaoEnergeticasController : Controller
    {
        private readonly MvcSolarContext _context;

        public ProducaoEnergeticasController(MvcSolarContext context)
        {
            _context = context;
        }

        // GET: ProducaoEnergeticas
        public async Task<IActionResult> Index()
        {
            var mvcSolarContext = _context.ProducoesEnergeticas.Include(p => p.Painel);
            return View(await mvcSolarContext.ToListAsync());
        }

        // GET: ProducaoEnergeticas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producaoEnergetica = await _context.ProducoesEnergeticas
                .Include(p => p.Painel)
                .FirstOrDefaultAsync(m => m.ProducaoEnergeticaID == id);
            if (producaoEnergetica == null)
            {
                return NotFound();
            }

            return View(producaoEnergetica);
        }

        // GET: ProducaoEnergeticas/Create
        public IActionResult Create()
        {
            ViewData["PainelID"] = new SelectList(_context.Paineis, "PainelID", "PainelID");
            return View();
        }

        // POST: ProducaoEnergeticas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProducaoEnergeticaID,Producao,Data,PainelID")] ProducaoEnergetica producaoEnergetica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producaoEnergetica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PainelID"] = new SelectList(_context.Paineis, "PainelID", "PainelID", producaoEnergetica.PainelID);
            return View(producaoEnergetica);
        }

        // GET: ProducaoEnergeticas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producaoEnergetica = await _context.ProducoesEnergeticas.FindAsync(id);
            if (producaoEnergetica == null)
            {
                return NotFound();
            }
            ViewData["PainelID"] = new SelectList(_context.Paineis, "PainelID", "PainelID", producaoEnergetica.PainelID);
            return View(producaoEnergetica);
        }

        // POST: ProducaoEnergeticas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProducaoEnergeticaID,Producao,Data,PainelID")] ProducaoEnergetica producaoEnergetica)
        {
            if (id != producaoEnergetica.ProducaoEnergeticaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producaoEnergetica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducaoEnergeticaExists(producaoEnergetica.ProducaoEnergeticaID))
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
            ViewData["PainelID"] = new SelectList(_context.Paineis, "PainelID", "PainelID", producaoEnergetica.PainelID);
            return View(producaoEnergetica);
        }

        // GET: ProducaoEnergeticas/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producaoEnergetica = await _context.ProducoesEnergeticas
                .AsNoTracking()
                .Include(p => p.Painel)
                .FirstOrDefaultAsync(m => m.ProducaoEnergeticaID == id);
            if (producaoEnergetica == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Apagar falhou. Tente outra vez, e se o problema persistir, contacte o administrador.";
            }

            return View(producaoEnergetica);
        }

        // POST: ProducaoEnergeticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producaoEnergetica = await _context.ProducoesEnergeticas.FindAsync(id);
            try
            {
                _context.ProducoesEnergeticas.Remove(producaoEnergetica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool ProducaoEnergeticaExists(int id)
        {
            return _context.ProducoesEnergeticas.Any(e => e.ProducaoEnergeticaID == id);
        }
    }
}
