using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSolar.Data;
using MvcSolar.Models;
using MvcSolar.Services;

namespace MvcSolar.Controllers
{
    public class ConsumoEnergeticosController : Controller
    {
        private readonly MvcSolarContext _context;

        public ConsumoEnergeticosController(MvcSolarContext context)
        {
            _context = context;
        }

        public JsonResult ConsumoEnergeticoGrafico()
        {
            var listaPopulacao = ConsumoEnergeticosService.GetConsumoEnergeticos();
            return Json(listaPopulacao);
        }
        // GET: ConsumoEnergeticos
        public async Task<IActionResult> Index()
        {
            var mvcSolarContext = _context.ConsumosEnergeticos.Include(c => c.Habitacao);
            return View(await mvcSolarContext.ToListAsync());
        }


        // GET: ConsumoEnergeticos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumoEnergetico = await _context.ConsumosEnergeticos
                .Include(c => c.Habitacao)
                .FirstOrDefaultAsync(m => m.ConsumoEnergeticoID == id);
            if (consumoEnergetico == null)
            {
                return NotFound();
            }

            return View(consumoEnergetico);
        }

        // GET: ConsumoEnergeticos/Create
        public IActionResult Create()
        {
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID");
            return View();
        }

        // POST: ConsumoEnergeticos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsumoEnergeticoID,Consumo,Data,HabitacaoID")] ConsumoEnergetico consumoEnergetico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumoEnergetico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", consumoEnergetico.HabitacaoID);
            return View(consumoEnergetico);
        }

        // GET: ConsumoEnergeticos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumoEnergetico = await _context.ConsumosEnergeticos.FindAsync(id);
            if (consumoEnergetico == null)
            {
                return NotFound();
            }
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", consumoEnergetico.HabitacaoID);
            return View(consumoEnergetico);
        }

        // POST: ConsumoEnergeticos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsumoEnergeticoID,Consumo,Data,HabitacaoID")] ConsumoEnergetico consumoEnergetico)
        {
            if (id != consumoEnergetico.ConsumoEnergeticoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumoEnergetico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumoEnergeticoExists(consumoEnergetico.ConsumoEnergeticoID))
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
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", consumoEnergetico.HabitacaoID);
            return View(consumoEnergetico);
        }

        // GET: ConsumoEnergeticos/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumoEnergetico = await _context.ConsumosEnergeticos
                .AsNoTracking()
                .Include(c => c.Habitacao)
                .FirstOrDefaultAsync(m => m.ConsumoEnergeticoID == id);
            if (consumoEnergetico == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Apagar falhou. Tente outra vez, e se o problema persistir, contacte o administrador.";
            }
            return View(consumoEnergetico);
        }

        // POST: ConsumoEnergeticos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumoEnergetico = await _context.ConsumosEnergeticos.FindAsync(id);
            if (consumoEnergetico == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try {
            _context.ConsumosEnergeticos.Remove(consumoEnergetico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool ConsumoEnergeticoExists(int id)
        {
            return _context.ConsumosEnergeticos.Any(e => e.ConsumoEnergeticoID == id);
        }
    }
}
