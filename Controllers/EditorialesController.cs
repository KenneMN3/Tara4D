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
    public class EditorialesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EditorialesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Editoriales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Editoriales.ToListAsync());
        }

        // GET: Editoriales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorialesModels = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.EditorialId == id);
            if (editorialesModels == null)
            {
                return NotFound();
            }

            return View(editorialesModels);
        }

        // GET: Editoriales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EditorialId,Nombre,Pais,AnioFundacion,Contacto")] EditorialesModels editorialesModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorialesModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editorialesModels);
        }

        // GET: Editoriales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorialesModels = await _context.Editoriales.FindAsync(id);
            if (editorialesModels == null)
            {
                return NotFound();
            }
            return View(editorialesModels);
        }

        // POST: Editoriales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EditorialId,Nombre,Pais,AnioFundacion,Contacto")] EditorialesModels editorialesModels)
        {
            if (id != editorialesModels.EditorialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorialesModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialesModelsExists(editorialesModels.EditorialId))
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
            return View(editorialesModels);
        }

        // GET: Editoriales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorialesModels = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.EditorialId == id);
            if (editorialesModels == null)
            {
                return NotFound();
            }

            return View(editorialesModels);
        }

        // POST: Editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editorialesModels = await _context.Editoriales.FindAsync(id);
            if (editorialesModels != null)
            {
                _context.Editoriales.Remove(editorialesModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialesModelsExists(int id)
        {
            return _context.Editoriales.Any(e => e.EditorialId == id);
        }
    }
}
