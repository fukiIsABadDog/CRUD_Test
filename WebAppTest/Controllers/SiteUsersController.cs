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
    public class SiteUsersController : Controller
    {
        private readonly MaelstromContext _context;

        public SiteUsersController(MaelstromContext context)
        {
            _context = context;
        }

        // GET: SiteUsers
        public async Task<IActionResult> Index()
        {
            var maelstromContext = _context.SiteUsers.Include(s => s.Site).Include(s => s.User);
            return View(await maelstromContext.ToListAsync());
        }

        // GET: SiteUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SiteUsers == null)
            {
                return NotFound();
            }

            var siteUser = await _context.SiteUsers
                .Include(s => s.Site)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SiteID == id);
            if (siteUser == null)
            {
                return NotFound();
            }

            return View(siteUser);
        }

        // GET: SiteUsers/Create
        public IActionResult Create()
        {
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name");
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName");
            return View();
        }

        // POST: SiteUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,SiteID")] SiteUser siteUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siteUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name", siteUser.SiteID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName", siteUser.UserID);
            return View(siteUser);
        }

        // GET: SiteUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SiteUsers == null)
            {
                return NotFound();
            }

            var siteUser = await _context.SiteUsers.FindAsync(id);
            if (siteUser == null)
            {
                return NotFound();
            }
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name", siteUser.SiteID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName", siteUser.UserID);
            return View(siteUser);
        }

        // POST: SiteUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,SiteID")] SiteUser siteUser)
        {
            if (id != siteUser.SiteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siteUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteUserExists(siteUser.SiteID))
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
            ViewData["SiteID"] = new SelectList(_context.Site, "SiteID", "Name", siteUser.SiteID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName", siteUser.UserID);
            return View(siteUser);
        }

        // GET: SiteUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SiteUsers == null)
            {
                return NotFound();
            }

            var siteUser = await _context.SiteUsers
                .Include(s => s.Site)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SiteID == id);
            if (siteUser == null)
            {
                return NotFound();
            }

            return View(siteUser);
        }

        // POST: SiteUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SiteUsers == null)
            {
                return Problem("Entity set 'MaelstromContext.SiteUsers'  is null.");
            }
            var siteUser = await _context.SiteUsers.FindAsync(id);
            if (siteUser != null)
            {
                _context.SiteUsers.Remove(siteUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteUserExists(int id)
        {
          return _context.SiteUsers.Any(e => e.SiteID == id);
        }
    }
}
