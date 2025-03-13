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
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Libros.Include(l => l.Autor).Include(l => l.Editorial);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librosModels = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .FirstOrDefaultAsync(m => m.LibroId == id);
            if (librosModels == null)
            {
                return NotFound();
            }

            return View(librosModels);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Apellido");
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "EditorialId", "Contacto");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibroId,Titulo,Genero,FechaPublicacion,ISBN,AutorId,EditorialId")] LibrosModels librosModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(librosModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Apellido", librosModels.AutorId);
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "EditorialId", "Contacto", librosModels.EditorialId);
            return View(librosModels);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librosModels = await _context.Libros.FindAsync(id);
            if (librosModels == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Apellido", librosModels.AutorId);
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "EditorialId", "Contacto", librosModels.EditorialId);
            return View(librosModels);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LibroId,Titulo,Genero,FechaPublicacion,ISBN,AutorId,EditorialId")] LibrosModels librosModels)
        {
            if (id != librosModels.LibroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(librosModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibrosModelsExists(librosModels.LibroId))
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
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "Apellido", librosModels.AutorId);
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "EditorialId", "Contacto", librosModels.EditorialId);
            return View(librosModels);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librosModels = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .FirstOrDefaultAsync(m => m.LibroId == id);
            if (librosModels == null)
            {
                return NotFound();
            }

            return View(librosModels);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var librosModels = await _context.Libros.FindAsync(id);
            if (librosModels != null)
            {
                _context.Libros.Remove(librosModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibrosModelsExists(int id)
        {
            return _context.Libros.Any(e => e.LibroId == id);
        }
    }
}
