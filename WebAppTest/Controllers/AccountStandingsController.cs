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
    public class AccountStandingsController : Controller
    {
        private readonly MaelstromContext _context;

        public AccountStandingsController(MaelstromContext context)
        {
            _context = context;
        }

        // GET: AccountStandings
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountStandings.ToListAsync());
        }

        // GET: AccountStandings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccountStandings == null)
            {
                return NotFound();
            }

            var accountStanding = await _context.AccountStandings
                .FirstOrDefaultAsync(m => m.AccountStandingID == id);
            if (accountStanding == null)
            {
                return NotFound();
            }

            return View(accountStanding);
        }

        // GET: AccountStandings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountStandings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountStandingID,Name")] AccountStanding accountStanding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountStanding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountStanding);
        }

        // GET: AccountStandings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AccountStandings == null)
            {
                return NotFound();
            }

            var accountStanding = await _context.AccountStandings.FindAsync(id);
            if (accountStanding == null)
            {
                return NotFound();
            }
            return View(accountStanding);
        }

        // POST: AccountStandings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountStandingID,Name")] AccountStanding accountStanding)
        {
            if (id != accountStanding.AccountStandingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountStanding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountStandingExists(accountStanding.AccountStandingID))
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
            return View(accountStanding);
        }

        // GET: AccountStandings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AccountStandings == null)
            {
                return NotFound();
            }

            var accountStanding = await _context.AccountStandings
                .FirstOrDefaultAsync(m => m.AccountStandingID == id);
            if (accountStanding == null)
            {
                return NotFound();
            }

            return View(accountStanding);
        }

        // POST: AccountStandings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AccountStandings == null)
            {
                return Problem("Entity set 'MaelstromContext.AccountStandings'  is null.");
            }
            var accountStanding = await _context.AccountStandings.FindAsync(id);
            if (accountStanding != null)
            {
                _context.AccountStandings.Remove(accountStanding);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountStandingExists(int id)
        {
            return _context.AccountStandings.Any(e => e.AccountStandingID == id);
        }
    }
}
