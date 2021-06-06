﻿using System;
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
    public class PaineisController : Controller
    {
        private readonly MvcSolarContext _context;

        public PaineisController(MvcSolarContext context)
        {
            _context = context;
        }

        // GET: Paineis
        public async Task<IActionResult> Index()
        {
            var mvcSolarContext = _context.Paineis.Include(p => p.Habitacao);
            return View(await mvcSolarContext.ToListAsync());
        }

        // GET: Paineis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painel = await _context.Paineis
                .Include(p => p.Habitacao)
                .FirstOrDefaultAsync(m => m.PainelID == id);
            if (painel == null)
            {
                return NotFound();
            }

            return View(painel);
        }

        // GET: Paineis/Create
        public IActionResult Create()
        {
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID");
            return View();
        }

        // POST: Paineis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PainelID,HabitacaoID,ProducaoPrevistaHora,Modelo,Estado")] Painel painel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(painel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", painel.HabitacaoID);
            return View(painel);
        }

        // GET: Paineis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painel = await _context.Paineis.FindAsync(id);
            if (painel == null)
            {
                return NotFound();
            }
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", painel.HabitacaoID);
            return View(painel);
        }

        // POST: Paineis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PainelID,HabitacaoID,ProducaoPrevistaHora,Modelo,Estado")] Painel painel)
        {
            if (id != painel.PainelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(painel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PainelExists(painel.PainelID))
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
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", painel.HabitacaoID);
            return View(painel);
        }

        // GET: Paineis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painel = await _context.Paineis
                .Include(p => p.Habitacao)
                .FirstOrDefaultAsync(m => m.PainelID == id);
            if (painel == null)
            {
                return NotFound();
            }

            return View(painel);
        }

        // POST: Paineis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var painel = await _context.Paineis.FindAsync(id);
            _context.Paineis.Remove(painel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PainelExists(int id)
        {
            return _context.Paineis.Any(e => e.PainelID == id);
        }
    }
}
