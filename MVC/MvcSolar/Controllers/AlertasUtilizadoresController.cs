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
    public class AlertasUtilizadoresController : Controller
    {
        private readonly MvcSolarContext _context;

        public AlertasUtilizadoresController(MvcSolarContext context)
        {
            _context = context;
        }

        // GET: AlertasUtilizadores
        public async Task<IActionResult> Index()
        {
            var mvcSolarContext = _context.AlertasUtilizadores.Include(a => a.Utilizador);
            return View(await mvcSolarContext.ToListAsync());
        }

        // GET: AlertasUtilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertasUtilizador = await _context.AlertasUtilizadores
                .Include(a => a.Utilizador)
                .FirstOrDefaultAsync(m => m.AlertasUtilizadorID == id);
            if (alertasUtilizador == null)
            {
                return NotFound();
            }

            return View(alertasUtilizador);
        }

        // GET: AlertasUtilizadores/Create
        public IActionResult Create()
        {
            ViewData["UtilizadorID"] = new SelectList(_context.Utilizadores, "UtilizadorId", "UtilizadorId");
            return View();
        }

        // POST: AlertasUtilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlertasUtilizadorID,UtilizadorID,Tipo")] AlertasUtilizador alertasUtilizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alertasUtilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UtilizadorID"] = new SelectList(_context.Utilizadores, "UtilizadorId", "UtilizadorId", alertasUtilizador.UtilizadorID);
            return View(alertasUtilizador);
        }

        // GET: AlertasUtilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertasUtilizador = await _context.AlertasUtilizadores.FindAsync(id);
            if (alertasUtilizador == null)
            {
                return NotFound();
            }
            ViewData["UtilizadorID"] = new SelectList(_context.Utilizadores, "UtilizadorId", "UtilizadorId", alertasUtilizador.UtilizadorID);
            return View(alertasUtilizador);
        }

        // POST: AlertasUtilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlertasUtilizadorID,UtilizadorID,Tipo")] AlertasUtilizador alertasUtilizador)
        {
            if (id != alertasUtilizador.AlertasUtilizadorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alertasUtilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertasUtilizadorExists(alertasUtilizador.AlertasUtilizadorID))
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
            ViewData["UtilizadorID"] = new SelectList(_context.Utilizadores, "UtilizadorId", "UtilizadorId", alertasUtilizador.UtilizadorID);
            return View(alertasUtilizador);
        }

        // GET: AlertasUtilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertasUtilizador = await _context.AlertasUtilizadores
                .AsNoTracking()
                .Include(a => a.Utilizador)
                .FirstOrDefaultAsync(m => m.AlertasUtilizadorID == id);
            if (alertasUtilizador == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Apagar falhou. Tente outra vez, e se o problema persistir, contacte o administrador.";
            }

            return View(alertasUtilizador);
        }

        // POST: AlertasUtilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alertasUtilizador = await _context.AlertasUtilizadores.FindAsync(id);
            if (alertasUtilizador == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.AlertasUtilizadores.Remove(alertasUtilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool AlertasUtilizadorExists(int id)
        {
            return _context.AlertasUtilizadores.Any(e => e.AlertasUtilizadorID == id);
        }
    }
}
