using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_Models;
using EFcoreTesting.Models;

namespace WebAppTest.Controllers
{
    public class SiteTypesController : Controller
    {
        private readonly MaelstromContext _context;

        public SiteTypesController(MaelstromContext context)
        {
            _context = context;
        }

        // GET: SiteTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.SiteType.ToListAsync());
        }

        // GET: SiteTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SiteType == null)
            {
                return NotFound();
            }

            var siteType = await _context.SiteType
                .FirstOrDefaultAsync(m => m.SiteTypeID == id);
            if (siteType == null)
            {
                return NotFound();
            }

            return View(siteType);
        }

        // GET: SiteTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SiteTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiteTypeID,Name")] SiteType siteType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siteType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteType);
        }

        // GET: SiteTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SiteType == null)
            {
                return NotFound();
            }

            var siteType = await _context.SiteType.FindAsync(id);
            if (siteType == null)
            {
                return NotFound();
            }
            return View(siteType);
        }

        // POST: SiteTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiteTypeID,Name")] SiteType siteType)
        {
            if (id != siteType.SiteTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siteType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteTypeExists(siteType.SiteTypeID))
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
            return View(siteType);
        }

        // GET: SiteTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SiteType == null)
            {
                return NotFound();
            }

            var siteType = await _context.SiteType
                .FirstOrDefaultAsync(m => m.SiteTypeID == id);
            if (siteType == null)
            {
                return NotFound();
            }

            return View(siteType);
        }

        // POST: SiteTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SiteType == null)
            {
                return Problem("Entity set 'MaelstromContext.SiteType'  is null.");
            }
            var siteType = await _context.SiteType.FindAsync(id);
            if (siteType != null)
            {
                _context.SiteType.Remove(siteType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteTypeExists(int id)
        {
          return _context.SiteType.Any(e => e.SiteTypeID == id);
        }
    }
}
