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
    public class ArmasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArmasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Armas
        public async Task<IActionResult> Index()
        {
            //SE GENERAN TANTAS LISTAS COMO PROPIEDADES FORANEAS TENGAMOS EN EL MODELO
            IQueryable<String> ListaTipos = from t in _context.TipoArma
                                            orderby t.Nombre
                                            select t.Nombre;

            IQueryable<String> ListaCenizas = from c in _context.Ceniza
                                              orderby c.Nombre
                                              select c.Nombre;

            //SE CREA UNA LISTA CON TODOS LOS OBJETOS DEL MODELO
            var ListaArmas = from a in _context.Arma
                             select a;

            //SE INCLUYEN EN DICHA LISTA LAS PROPIEDADES FORÁNEAS
            ListaArmas = ListaArmas.Include(a => a.Ceniza).Include(a => a.TipoArma);

            //SE CREA UNA VARIABLE DEL TIPO MODELO IGUAL QUE EL QUE SE USA EN LA VISTA ASOCIADA, Y SE INTRODUCEN LAS TRES LISTAS ANTERIORES
            var ArmaViewModel = new ArmaViewModel
            {
                TipoArma = new SelectList(await ListaTipos.Distinct().ToListAsync()),
                Ceniza = new SelectList(await ListaCenizas.Distinct().ToListAsync()),
                Arma = await ListaArmas.ToListAsync()
            };

            //SE RETORNA DICHA VARIABLE
            return View(ArmaViewModel);

            //var applicationDbContext = _context.Arma.Include(a => a.Ceniza).Include(a => a.TipoArma);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Armas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arma = await _context.Arma
                .Include(a => a.Ceniza)
                .Include(a => a.TipoArma)
                .FirstOrDefaultAsync(m => m.ArmaID == id);
            if (arma == null)
            {
                return NotFound();
            }

            return View(arma);
        }

        // GET: Armas/Create
        [Authorize(Roles="Administrador")]
        public IActionResult Create()
        {
            ViewData["CenizaID"] = new SelectList(_context.Ceniza, "CenizaID", "Nombre");
            ViewData["TipoArmaID"] = new SelectList(_context.TipoArma, "TipoArmaID", "Nombre");
            return View();
        }

        // POST: Armas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Create([Bind("ArmaID,Nombre,Descripcion,Imagen,TipoArmaID,CenizaID,DmgFisico,DmgMagico,DmgFuego,DmgRayo,DmgSagrado,DmgCritico,RequerimientoStr,EscaladoStr,RequerimientoDex,EscaladoDex,RequerimientoInt,EscaladoInt,RequerimientoFe,EscaladoFe,RequerimientoArcana,EscaladoArcana,Peso")] Arma arma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CenizaID"] = new SelectList(_context.Ceniza, "CenizaID", "CenizaID", arma.CenizaID);
            ViewData["TipoArmaID"] = new SelectList(_context.TipoArma, "TipoArmaID", "TipoArmaID", arma.TipoArmaID);
            return View(arma);
        }

        // GET: Armas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arma = await _context.Arma.FindAsync(id);
            if (arma == null)
            {
                return NotFound();
            }
            ViewData["CenizaID"] = new SelectList(_context.Ceniza, "CenizaID", "Nombre", arma.CenizaID);
            ViewData["TipoArmaID"] = new SelectList(_context.TipoArma, "TipoArmaID", "Nombre", arma.TipoArmaID);
            return View(arma);
        }

        // POST: Armas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ArmaID,Nombre,Descripcion,Imagen,TipoArmaID,CenizaID,DmgFisico,DmgMagico,DmgFuego,DmgRayo,DmgSagrado,DmgCritico,RequerimientoStr,EscaladoStr,RequerimientoDex,EscaladoDex,RequerimientoInt,EscaladoInt,RequerimientoFe,EscaladoFe,RequerimientoArcana,EscaladoArcana,Peso")] Arma arma)
        {
            if (id != arma.ArmaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmaExists(arma.ArmaID))
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
            ViewData["CenizaID"] = new SelectList(_context.Ceniza, "CenizaID", "CenizaID", arma.CenizaID);
            ViewData["TipoArmaID"] = new SelectList(_context.TipoArma, "TipoArmaID", "TipoArmaID", arma.TipoArmaID);
            return View(arma);
        }

        // GET: Armas/Delete/5
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arma = await _context.Arma
                .Include(a => a.Ceniza)
                .Include(a => a.TipoArma)
                .FirstOrDefaultAsync(m => m.ArmaID == id);
            if (arma == null)
            {
                return NotFound();
            }

            return View(arma);
        }

        // POST: Armas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arma = await _context.Arma.FindAsync(id);
            _context.Arma.Remove(arma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmaExists(int id)
        {
            return _context.Arma.Any(e => e.ArmaID == id);
        }
    }
}
