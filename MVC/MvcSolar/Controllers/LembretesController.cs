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
    public class LembretesController : Controller
    {
        private readonly MvcSolarContext _context;

        public LembretesController(MvcSolarContext context)
        {
            _context = context;
        }

        // GET: Lembretes
        public async Task<IActionResult> Index()
        {
            var mvcSolarContext = _context.Lembretes.Include(l => l.Evento).Include(l => l.Utilizador);
            return View(await mvcSolarContext.ToListAsync());
        }

        // GET: Lembretes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembretes
                .Include(l => l.Evento)
                .Include(l => l.Utilizador)
                .FirstOrDefaultAsync(m => m.LembreteID == id);
            if (lembrete == null)
            {
                return NotFound();
            }

            return View(lembrete);
        }

        // GET: Lembretes/Create
        public IActionResult Create()
        {
            ViewData["EventoID"] = new SelectList(_context.Eventos, "EventoId", "EventoId");
            ViewData["UtilizadorID"] = new SelectList(_context.Utilizadores, "UtilizadorId", "UtilizadorId");
            return View();
        }

        // POST: Lembretes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LembreteID,dataHora,EventoID,UtilizadorID")] Lembrete lembrete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lembrete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoID"] = new SelectList(_context.Eventos, "EventoId", "EventoId", lembrete.EventoID);
            ViewData["UtilizadorID"] = new SelectList(_context.Utilizadores, "UtilizadorId", "UtilizadorId", lembrete.UtilizadorID);
            return View(lembrete);
        }

        // GET: Lembretes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembretes.FindAsync(id);
            if (lembrete == null)
            {
                return NotFound();
            }
            ViewData["EventoID"] = new SelectList(_context.Eventos, "EventoId", "EventoId", lembrete.EventoID);
            ViewData["UtilizadorID"] = new SelectList(_context.Utilizadores, "UtilizadorId", "UtilizadorId", lembrete.UtilizadorID);
            return View(lembrete);
        }

        // POST: Lembretes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LembreteID,dataHora,EventoID,UtilizadorID")] Lembrete lembrete)
        {
            if (id != lembrete.LembreteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lembrete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LembreteExists(lembrete.LembreteID))
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
            ViewData["EventoID"] = new SelectList(_context.Eventos, "EventoId", "EventoId", lembrete.EventoID);
            ViewData["UtilizadorID"] = new SelectList(_context.Utilizadores, "UtilizadorId", "UtilizadorId", lembrete.UtilizadorID);
            return View(lembrete);
        }

        // GET: Lembretes/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembretes
                .AsNoTracking()
                .Include(l => l.Evento)
                .Include(l => l.Utilizador)
                .FirstOrDefaultAsync(m => m.LembreteID == id);
            if (lembrete == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Apagar falhou. Tente outra vez, e se o problema persistir, contacte o administrador.";
            }

            return View(lembrete);
        }

        // POST: Lembretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lembrete = await _context.Lembretes.FindAsync(id);
            if (lembrete == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try {
            _context.Lembretes.Remove(lembrete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool LembreteExists(int id)
        {
            return _context.Lembretes.Any(e => e.LembreteID == id);
        }
    }
}
