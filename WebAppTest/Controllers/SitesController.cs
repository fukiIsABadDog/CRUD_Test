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
    public class SitesController : Controller
    {
        private readonly MaelstromContext _context;

        public SitesController(MaelstromContext context)
        {
            _context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index()
        {
            var maelstromContext = _context.Site.Include(s => s.SiteType);
            return View(await maelstromContext.ToListAsync());
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Site == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .Include(s => s.SiteType)
                .FirstOrDefaultAsync(m => m.SiteID == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            ViewData["SiteTypeID"] = new SelectList(_context.SiteType, "SiteTypeID", "Name");
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiteID,Name,Capacity,Location,SiteTypeID")] Site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiteTypeID"] = new SelectList(_context.SiteType, "SiteTypeID", "Name", site.SiteTypeID);
            return View(site);
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Site == null)
            {
                return NotFound();
            }

            var site = await _context.Site.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            ViewData["SiteTypeID"] = new SelectList(_context.SiteType, "SiteTypeID", "Name", site.SiteTypeID);
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiteID,Name,Capacity,Location,SiteTypeID")] Site site)
        {
            if (id != site.SiteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.SiteID))
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
            ViewData["SiteTypeID"] = new SelectList(_context.SiteType, "SiteTypeID", "Name", site.SiteTypeID);
            return View(site);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Site == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .Include(s => s.SiteType)
                .FirstOrDefaultAsync(m => m.SiteID == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Site == null)
            {
                return Problem("Entity set 'MaelstromContext.Site'  is null.");
            }
            var site = await _context.Site.FindAsync(id);
            if (site != null)
            {
                _context.Site.Remove(site);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(int id)
        {
          return _context.Site.Any(e => e.SiteID == id);
        }
    }
}
