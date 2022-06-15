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
    public class ArmadurasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArmadurasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Armaduras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Armadura.ToListAsync());
        }

        // GET: Armaduras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadura = await _context.Armadura
                .FirstOrDefaultAsync(m => m.ArmaduraID == id);
            if (armadura == null)
            {
                return NotFound();
            }

            return View(armadura);
        }

        // GET: Armaduras/Create
        [Authorize(Roles="Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Armaduras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Create([Bind("ArmaduraID,Nombre,Descripcion,Imagen,Vitalidad,ResFisica,ResMagica,ResFuego,ResRayo,ResSagrado,Peso")] Armadura armadura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armadura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(armadura);
        }

        // GET: Armaduras/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadura = await _context.Armadura.FindAsync(id);
            if (armadura == null)
            {
                return NotFound();
            }
            return View(armadura);
        }

        // POST: Armaduras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ArmaduraID,Nombre,Descripcion,Imagen,Vitalidad,ResFisica,ResMagica,ResFuego,ResRayo,ResSagrado,Peso")] Armadura armadura)
        {
            if (id != armadura.ArmaduraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armadura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmaduraExists(armadura.ArmaduraID))
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
            return View(armadura);
        }

        // GET: Armaduras/Delete/5
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadura = await _context.Armadura
                .FirstOrDefaultAsync(m => m.ArmaduraID == id);
            if (armadura == null)
            {
                return NotFound();
            }

            return View(armadura);
        }

        // POST: Armaduras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var armadura = await _context.Armadura.FindAsync(id);
            _context.Armadura.Remove(armadura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmaduraExists(int id)
        {
            return _context.Armadura.Any(e => e.ArmaduraID == id);
        }
    }
}
