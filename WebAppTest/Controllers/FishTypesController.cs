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
    public class FishTypesController : Controller
    {
        private readonly MaelstromContext _context;

        public FishTypesController(MaelstromContext context)
        {
            _context = context;
        }

        // GET: FishTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FishTypes.ToListAsync());
        }

        // GET: FishTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FishTypes == null)
            {
                return NotFound();
            }

            var fishType = await _context.FishTypes
                .FirstOrDefaultAsync(m => m.FishTypeID == id);
            if (fishType == null)
            {
                return NotFound();
            }

            return View(fishType);
        }

        // GET: FishTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FishTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FishTypeID,CommonName,ScientificName,MaxSize,RecommendedTankSize,MinTemp,MaxTemp,PhMin,PhMax")] FishType fishType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fishType);
        }

        // GET: FishTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FishTypes == null)
            {
                return NotFound();
            }

            var fishType = await _context.FishTypes.FindAsync(id);
            if (fishType == null)
            {
                return NotFound();
            }
            return View(fishType);
        }

        // POST: FishTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FishTypeID,CommonName,ScientificName,MaxSize,RecommendedTankSize,MinTemp,MaxTemp,PhMin,PhMax")] FishType fishType)
        {
            if (id != fishType.FishTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishTypeExists(fishType.FishTypeID))
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
            return View(fishType);
        }

        // GET: FishTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FishTypes == null)
            {
                return NotFound();
            }

            var fishType = await _context.FishTypes
                .FirstOrDefaultAsync(m => m.FishTypeID == id);
            if (fishType == null)
            {
                return NotFound();
            }

            return View(fishType);
        }

        // POST: FishTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FishTypes == null)
            {
                return Problem("Entity set 'MaelstromContext.FishTypes'  is null.");
            }
            var fishType = await _context.FishTypes.FindAsync(id);
            if (fishType != null)
            {
                _context.FishTypes.Remove(fishType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishTypeExists(int id)
        {
            return _context.FishTypes.Any(e => e.FishTypeID == id);
        }
    }
}
