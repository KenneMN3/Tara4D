using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrestamosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prestamos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Prestamos.Include(p => p.Libro).Include(p => p.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Prestamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamosModels = await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PrestamoId == id);
            if (prestamosModels == null)
            {
                return NotFound();
            }

            return View(prestamosModels);
        }

        // GET: Prestamos/Create
        public IActionResult Create()
        {
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Genero");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Apellido");
            return View();
        }

        // POST: Prestamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestamoId,FechaPrestamo,FechaDevolucion,Estado,UsuarioId,LibroId")] PrestamosModels prestamosModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamosModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Genero", prestamosModels.LibroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Apellido", prestamosModels.UsuarioId);
            return View(prestamosModels);
        }

        // GET: Prestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamosModels = await _context.Prestamos.FindAsync(id);
            if (prestamosModels == null)
            {
                return NotFound();
            }
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Genero", prestamosModels.LibroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Apellido", prestamosModels.UsuarioId);
            return View(prestamosModels);
        }

        // POST: Prestamos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrestamoId,FechaPrestamo,FechaDevolucion,Estado,UsuarioId,LibroId")] PrestamosModels prestamosModels)
        {
            if (id != prestamosModels.PrestamoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamosModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamosModelsExists(prestamosModels.PrestamoId))
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
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Genero", prestamosModels.LibroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Apellido", prestamosModels.UsuarioId);
            return View(prestamosModels);
        }

        // GET: Prestamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamosModels = await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PrestamoId == id);
            if (prestamosModels == null)
            {
                return NotFound();
            }

            return View(prestamosModels);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamosModels = await _context.Prestamos.FindAsync(id);
            if (prestamosModels != null)
            {
                _context.Prestamos.Remove(prestamosModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamosModelsExists(int id)
        {
            return _context.Prestamos.Any(e => e.PrestamoId == id);
        }
    }
}
