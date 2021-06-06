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
    public class HabitacoesController : Controller
    {
        private readonly MvcSolarContext _context;

        public HabitacoesController(MvcSolarContext context)
        {
            _context = context;
        }

        // GET: Habitacoes
        public async Task<IActionResult> Index()
        {
            var mvcSolarContext = _context.Habitacoes.Include(h => h.Localidade);
            return View(await mvcSolarContext.ToListAsync());
        }

        // GET: Habitacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacao = await _context.Habitacoes
                .Include(h => h.Localidade)
                .FirstOrDefaultAsync(m => m.HabitacaoID == id);
            if (habitacao == null)
            {
                return NotFound();
            }

            return View(habitacao);
        }

        // GET: Habitacoes/Create
        public IActionResult Create()
        {
            ViewData["LocalidadeID"] = new SelectList(_context.Localidades, "LocalidadeID", "LocalidadeID");
            return View();
        }

        // POST: Habitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HabitacaoID,Morada,Latitude,Longitude,Bateria,Capacidade,LocalidadeID")] Habitacao habitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalidadeID"] = new SelectList(_context.Localidades, "LocalidadeID", "LocalidadeID", habitacao.LocalidadeID);
            return View(habitacao);
        }

        // GET: Habitacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacao = await _context.Habitacoes.FindAsync(id);
            if (habitacao == null)
            {
                return NotFound();
            }
            ViewData["LocalidadeID"] = new SelectList(_context.Localidades, "LocalidadeID", "LocalidadeID", habitacao.LocalidadeID);
            return View(habitacao);
        }

        // POST: Habitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HabitacaoID,Morada,Latitude,Longitude,Bateria,Capacidade,LocalidadeID")] Habitacao habitacao)
        {
            if (id != habitacao.HabitacaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacaoExists(habitacao.HabitacaoID))
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
            ViewData["LocalidadeID"] = new SelectList(_context.Localidades, "LocalidadeID", "LocalidadeID", habitacao.LocalidadeID);
            return View(habitacao);
        }

        // GET: Habitacoes/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacao = await _context.Habitacoes
                .AsNoTracking()
                .Include(h => h.Localidade)
                .FirstOrDefaultAsync(m => m.HabitacaoID == id);
            if (habitacao == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Apagar falhou. Tente outra vez, e se o problema persistir, contacte o administrador.";
            }

            return View(habitacao);
        }

        // POST: Habitacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitacao = await _context.Habitacoes.FindAsync(id);
            if (habitacao == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try {
            _context.Habitacoes.Remove(habitacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool HabitacaoExists(int id)
        {
            return _context.Habitacoes.Any(e => e.HabitacaoID == id);
        }
    }
}
