using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_JuegoWiki.Data;
using ProyectoFinal_JuegoWiki.Models;

namespace ProyectoFinal_JuegoWiki.Controllers
{
    public class ConsumiblesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsumiblesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consumibles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consumible.ToListAsync());
        }

        // GET: Consumibles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumible = await _context.Consumible
                .FirstOrDefaultAsync(m => m.ConsumibleID == id);
            if (consumible == null)
            {
                return NotFound();
            }

            return View(consumible);
        }

        // GET: Consumibles/Create
        [Authorize(Roles="Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consumibles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Create([Bind("ConsumibleID,Nombre,Descripcion,Imagen")] Consumible consumible)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumible);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumible);
        }

        // GET: Consumibles/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumible = await _context.Consumible.FindAsync(id);
            if (consumible == null)
            {
                return NotFound();
            }
            return View(consumible);
        }

        // POST: Consumibles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ConsumibleID,Nombre,Descripcion,Imagen")] Consumible consumible)
        {
            if (id != consumible.ConsumibleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumible);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumibleExists(consumible.ConsumibleID))
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
            return View(consumible);
        }

        // GET: Consumibles/Delete/5
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumible = await _context.Consumible
                .FirstOrDefaultAsync(m => m.ConsumibleID == id);
            if (consumible == null)
            {
                return NotFound();
            }

            return View(consumible);
        }

        // POST: Consumibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumible = await _context.Consumible.FindAsync(id);
            _context.Consumible.Remove(consumible);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumibleExists(int id)
        {
            return _context.Consumible.Any(e => e.ConsumibleID == id);
        }
    }
}
