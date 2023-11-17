using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManuEquiTI.Data;
using ManuEquiTI.Models;

namespace ManuEquiTI.Controllers
{
    public class InvtMaqsController : Controller
    {
        private readonly DBContext _context;

        public InvtMaqsController(DBContext context)
        {
            _context = context;
        }

        // GET: InvtMaqs
        public async Task<IActionResult> Index()
        {
              return _context.InvtMaq != null ? 
                          View(await _context.InvtMaq.ToListAsync()) :
                          Problem("Entity set 'DBContext.InvtMaq'  is null.");
        }

        // GET: InvtMaqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvtMaq == null)
            {
                return NotFound();
            }

            var invtMaq = await _context.InvtMaq
                .FirstOrDefaultAsync(m => m.idMaq == id);
            if (invtMaq == null)
            {
                return NotFound();
            }

            return View(invtMaq);
        }

        // GET: InvtMaqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvtMaqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idMaq,Maquina,CodMaq,Observacoes")] InvtMaq invtMaq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invtMaq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invtMaq);
        }

        // GET: InvtMaqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvtMaq == null)
            {
                return NotFound();
            }

            var invtMaq = await _context.InvtMaq.FindAsync(id);
            if (invtMaq == null)
            {
                return NotFound();
            }
            return View(invtMaq);
        }

        // POST: InvtMaqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idMaq,Maquina,CodMaq,Observacoes")] InvtMaq invtMaq)
        {
            if (id != invtMaq.idMaq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invtMaq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvtMaqExists(invtMaq.idMaq))
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
            return View(invtMaq);
        }

        // GET: InvtMaqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvtMaq == null)
            {
                return NotFound();
            }

            var invtMaq = await _context.InvtMaq
                .FirstOrDefaultAsync(m => m.idMaq == id);
            if (invtMaq == null)
            {
                return NotFound();
            }

            return View(invtMaq);
        }

        // POST: InvtMaqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvtMaq == null)
            {
                return Problem("Entity set 'DBContext.InvtMaq'  is null.");
            }
            var invtMaq = await _context.InvtMaq.FindAsync(id);
            if (invtMaq != null)
            {
                _context.InvtMaq.Remove(invtMaq);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvtMaqExists(int id)
        {
          return (_context.InvtMaq?.Any(e => e.idMaq == id)).GetValueOrDefault();
        }
    }
}
