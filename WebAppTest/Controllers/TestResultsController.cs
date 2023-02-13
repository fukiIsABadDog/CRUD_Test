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
    public class TestResultsController : Controller
    {
        private readonly MaelstromContext _context;

        public TestResultsController(MaelstromContext context)
        {
            _context = context;
        }

        // GET: TestResults
        public async Task<IActionResult> Index()
        {
            var maelstromContext = _context.TestResults.Include(t => t.Site);
            return View(await maelstromContext.ToListAsync());
        }

        // GET: TestResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TestResults == null)
            {
                return NotFound();
            }

            var testResult = await _context.TestResults
                .Include(t => t.Site)
                .FirstOrDefaultAsync(m => m.TestResultID == id);
            if (testResult == null)
            {
                return NotFound();
            }

            return View(testResult);
        }

        // GET: TestResults/Create
        public IActionResult Create()
        {
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name");
            return View();
        }

        // POST: TestResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestResultID,SiteID,Temperature,Ph,Sality,Alkalinty,Calcium,Magnesium,Phosphate,Nitrate,Nitrite,Ammonia")] TestResult testResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name", testResult.SiteID);
            return View(testResult);
        }

        // GET: TestResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TestResults == null)
            {
                return NotFound();
            }

            var testResult = await _context.TestResults.FindAsync(id);
            if (testResult == null)
            {
                return NotFound();
            }
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name", testResult.SiteID);
            return View(testResult);
        }

        // POST: TestResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestResultID,SiteID,Temperature,Ph,Sality,Alkalinty,Calcium,Magnesium,Phosphate,Nitrate,Nitrite,Ammonia")] TestResult testResult)
        {
            if (id != testResult.TestResultID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestResultExists(testResult.TestResultID))
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
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name", testResult.SiteID);
            return View(testResult);
        }

        // GET: TestResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TestResults == null)
            {
                return NotFound();
            }

            var testResult = await _context.TestResults
                .Include(t => t.Site)
                .FirstOrDefaultAsync(m => m.TestResultID == id);
            if (testResult == null)
            {
                return NotFound();
            }

            return View(testResult);
        }

        // POST: TestResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TestResults == null)
            {
                return Problem("Entity set 'MaelstromContext.TestResults'  is null.");
            }
            var testResult = await _context.TestResults.FindAsync(id);
            if (testResult != null)
            {
                _context.TestResults.Remove(testResult);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestResultExists(int id)
        {
          return _context.TestResults.Any(e => e.TestResultID == id);
        }
    }
}
