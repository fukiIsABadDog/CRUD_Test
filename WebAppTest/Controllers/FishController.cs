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
    public class FishController : Controller
    {
        private readonly MaelstromContext _context;

        public FishController(MaelstromContext context)
        {
            _context = context;
        }

        // GET: Fish
        public async Task<IActionResult> Index()
        {
            var maelstromContext = _context.Fishs.Include(f => f.FishType).Include(f => f.Site);
            return View(await maelstromContext.ToListAsync());
        }

        // GET: Fish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fishs == null)
            {
                return NotFound();
            }

            var fish = await _context.Fishs
                .Include(f => f.FishType)
                .Include(f => f.Site)
                .FirstOrDefaultAsync(m => m.FishID == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // GET: Fish/Create
        public IActionResult Create()
        {
            ViewData["FishTypeID"] = new SelectList(_context.FishTypes, "FishTypeID", "FishTypeID");
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name");
            return View();
        }

        // POST: Fish/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FishID,NameOrTag,DateAdded,FishTypeID,SiteID,Image")] Fish fish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FishTypeID"] = new SelectList(_context.FishTypes, "FishTypeID", "FishTypeID", fish.FishTypeID);
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name", fish.SiteID);
            return View(fish);
        }

        // GET: Fish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fishs == null)
            {
                return NotFound();
            }

            var fish = await _context.Fishs.FindAsync(id);
            if (fish == null)
            {
                return NotFound();
            }
            ViewData["FishTypeID"] = new SelectList(_context.FishTypes, "FishTypeID", "FishTypeID", fish.FishTypeID);
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name", fish.SiteID);
            return View(fish);
        }

        // POST: Fish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FishID,NameOrTag,DateAdded,FishTypeID,SiteID,Image")] Fish fish)
        {
            if (id != fish.FishID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishExists(fish.FishID))
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
            ViewData["FishTypeID"] = new SelectList(_context.FishTypes, "FishTypeID", "FishTypeID", fish.FishTypeID);
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name", fish.SiteID);
            return View(fish);
        }

        // GET: Fish/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fishs == null)
            {
                return NotFound();
            }

            var fish = await _context.Fishs
                .Include(f => f.FishType)
                .Include(f => f.Site)
                .FirstOrDefaultAsync(m => m.FishID == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // POST: Fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fishs == null)
            {
                return Problem("Entity set 'MaelstromContext.Fishs'  is null.");
            }
            var fish = await _context.Fishs.FindAsync(id);
            if (fish != null)
            {
                _context.Fishs.Remove(fish);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishExists(int id)
        {
          return _context.Fishs.Any(e => e.FishID == id);
        }
    }
}
