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
    public class ManutencoesController : Controller
    {
        private readonly MvcSolarContext _context;

        public ManutencoesController(MvcSolarContext context)
        {
            _context = context;
        }

        // GET: Manutencoes
        public async Task<IActionResult> Index(string sortOrder)
        {
            var mvcSolarContext = _context.Manutencoes.Include(m => m.Funcionario).Include(m => m.Habitacao);

            ViewData["DateSortParm"] = sortOrder;

            var manutencoes = from s in _context.Manutencoes
                          select s;
            switch (sortOrder)
            {
                case "Data":
                    manutencoes = manutencoes.OrderBy(s => s.Data);
                    break;
                default:
                    manutencoes = manutencoes.OrderByDescending(s => s.Data);
                    break;
            }

            return View(await manutencoes.ToListAsync());
        }

        // GET: Manutencoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencoes
                .Include(m => m.Funcionario)
                .Include(m => m.Habitacao)
                .FirstOrDefaultAsync(m => m.ManutencaoID == id);
            if (manutencao == null)
            {
                return NotFound();
            }

            return View(manutencao);
        }

        // GET: Manutencoes/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioID"] = new SelectList(_context.Funcionarios, "UtilizadorId", "UtilizadorId");
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID");
            return View();
        }

        // POST: Manutencoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManutencaoID,FuncionarioID,HabitacaoID,Data")] Manutencao manutencao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manutencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioID"] = new SelectList(_context.Funcionarios, "UtilizadorId", "UtilizadorId", manutencao.FuncionarioID);
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", manutencao.HabitacaoID);
            return View(manutencao);
        }

        // GET: Manutencoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencoes.FindAsync(id);
            if (manutencao == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioID"] = new SelectList(_context.Funcionarios, "UtilizadorId", "UtilizadorId", manutencao.FuncionarioID);
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", manutencao.HabitacaoID);
            return View(manutencao);
        }

        // POST: Manutencoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManutencaoID,FuncionarioID,HabitacaoID,Data")] Manutencao manutencao)
        {
            if (id != manutencao.ManutencaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manutencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManutencaoExists(manutencao.ManutencaoID))
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
            ViewData["FuncionarioID"] = new SelectList(_context.Funcionarios, "UtilizadorId", "UtilizadorId", manutencao.FuncionarioID);
            ViewData["HabitacaoID"] = new SelectList(_context.Habitacoes, "HabitacaoID", "HabitacaoID", manutencao.HabitacaoID);
            return View(manutencao);
        }

        // GET: Manutencoes/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencoes
                .AsNoTracking()
                .Include(m => m.Funcionario)
                .Include(m => m.Habitacao)
                .FirstOrDefaultAsync(m => m.ManutencaoID == id);
            if (manutencao == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Apagar falhou. Tente outra vez, e se o problema persistir, contacte o administrador.";
            }

            return View(manutencao);
        }

        // POST: Manutencoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manutencao = await _context.Manutencoes.FindAsync(id);
            if (manutencao == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Manutencoes.Remove(manutencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool ManutencaoExists(int id)
        {
            return _context.Manutencoes.Any(e => e.ManutencaoID == id);
        }
    }
}
