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
    public class TipoArmasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoArmasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoArmas
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoArma.ToListAsync());
        }

        // GET: TipoArmas/Details/5
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArma = await _context.TipoArma
                .FirstOrDefaultAsync(m => m.TipoArmaID == id);
            if (tipoArma == null)
            {
                return NotFound();
            }

            return View(tipoArma);
        }

        // GET: TipoArmas/Create
        [Authorize(Roles="Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoArmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Create([Bind("TipoArmaID,Nombre")] TipoArma tipoArma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoArma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoArma);
        }

        // GET: TipoArmas/Edit/5
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArma = await _context.TipoArma.FindAsync(id);
            if (tipoArma == null)
            {
                return NotFound();
            }
            return View(tipoArma);
        }

        // POST: TipoArmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("TipoArmaID,Nombre")] TipoArma tipoArma)
        {
            if (id != tipoArma.TipoArmaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoArma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoArmaExists(tipoArma.TipoArmaID))
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
            return View(tipoArma);
        }

        // GET: TipoArmas/Delete/5
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArma = await _context.TipoArma
                .FirstOrDefaultAsync(m => m.TipoArmaID == id);
            if (tipoArma == null)
            {
                return NotFound();
            }

            return View(tipoArma);
        }

        // POST: TipoArmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoArma = await _context.TipoArma.FindAsync(id);
            _context.TipoArma.Remove(tipoArma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoArmaExists(int id)
        {
            return _context.TipoArma.Any(e => e.TipoArmaID == id);
        }
    }
}
