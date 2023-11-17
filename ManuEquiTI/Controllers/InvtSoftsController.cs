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
    public class InvtSoftsController : Controller
    {
        private readonly DBContext _context;

        public InvtSoftsController(DBContext context)
        {
            _context = context;
        }

        // GET: InvtSofts
        public async Task<IActionResult> Index()
        {
              return _context.InvtSoft != null ? 
                          View(await _context.InvtSoft.ToListAsync()) :
                          Problem("Entity set 'DBContext.InvtSoft'  is null.");
        }

        // GET: InvtSofts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvtSoft == null)
            {
                return NotFound();
            }

            var invtSoft = await _context.InvtSoft
                .FirstOrDefaultAsync(m => m.idSoft == id);
            if (invtSoft == null)
            {
                return NotFound();
            }

            return View(invtSoft);
        }

        // GET: InvtSofts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvtSofts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idSoft,SoftWare,CodSoft,Observacoes")] InvtSoft invtSoft)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invtSoft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invtSoft);
        }

        // GET: InvtSofts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvtSoft == null)
            {
                return NotFound();
            }

            var invtSoft = await _context.InvtSoft.FindAsync(id);
            if (invtSoft == null)
            {
                return NotFound();
            }
            return View(invtSoft);
        }

        // POST: InvtSofts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idSoft,SoftWare,CodSoft,Observacoes")] InvtSoft invtSoft)
        {
            if (id != invtSoft.idSoft)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invtSoft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvtSoftExists(invtSoft.idSoft))
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
            return View(invtSoft);
        }

        // GET: InvtSofts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvtSoft == null)
            {
                return NotFound();
            }

            var invtSoft = await _context.InvtSoft
                .FirstOrDefaultAsync(m => m.idSoft == id);
            if (invtSoft == null)
            {
                return NotFound();
            }

            return View(invtSoft);
        }

        // POST: InvtSofts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvtSoft == null)
            {
                return Problem("Entity set 'DBContext.InvtSoft'  is null.");
            }
            var invtSoft = await _context.InvtSoft.FindAsync(id);
            if (invtSoft != null)
            {
                _context.InvtSoft.Remove(invtSoft);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvtSoftExists(int id)
        {
          return (_context.InvtSoft?.Any(e => e.idSoft == id)).GetValueOrDefault();
        }
    }
}
