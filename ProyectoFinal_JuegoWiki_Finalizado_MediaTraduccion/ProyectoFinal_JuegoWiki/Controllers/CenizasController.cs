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
    public class CenizasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CenizasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cenizas
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ceniza.ToListAsync());
        }

        // GET: Cenizas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ceniza = await _context.Ceniza
                .FirstOrDefaultAsync(m => m.CenizaID == id);
            if (ceniza == null)
            {
                return NotFound();
            }

            return View(ceniza);
        }

        // GET: Cenizas/Create
        [Authorize(Roles="Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cenizas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Create([Bind("CenizaID,Nombre,Descripcion,CosteMana")] Ceniza ceniza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ceniza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ceniza);
        }

        // GET: Cenizas/Edit/5
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ceniza = await _context.Ceniza.FindAsync(id);
            if (ceniza == null)
            {
                return NotFound();
            }
            return View(ceniza);
        }

        // POST: Cenizas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("CenizaID,Nombre,Descripcion,CosteMana")] Ceniza ceniza)
        {
            if (id != ceniza.CenizaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ceniza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenizaExists(ceniza.CenizaID))
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
            return View(ceniza);
        }

        // GET: Cenizas/Delete/5
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ceniza = await _context.Ceniza
                .FirstOrDefaultAsync(m => m.CenizaID == id);
            if (ceniza == null)
            {
                return NotFound();
            }

            return View(ceniza);
        }

        // POST: Cenizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ceniza = await _context.Ceniza.FindAsync(id);
            _context.Ceniza.Remove(ceniza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenizaExists(int id)
        {
            return _context.Ceniza.Any(e => e.CenizaID == id);
        }
    }
}
