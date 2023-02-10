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
    public class AccountPaymentsController : Controller
    {
        private readonly MaelstromContext _context;

        public AccountPaymentsController(MaelstromContext context)
        {
            _context = context;
        }

        // GET: AccountPayments
        public async Task<IActionResult> Index()
        {
            var maelstromContext = _context.AccountPayments.Include(a => a.Account).Include(a => a.Payments);
            return View(await maelstromContext.ToListAsync());
        }

        // GET: AccountPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccountPayments == null)
            {
                return NotFound();
            }

            var accountPayment = await _context.AccountPayments
                .Include(a => a.Account)
                .Include(a => a.Payments)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (accountPayment == null)
            {
                return NotFound();
            }

            return View(accountPayment);
        }

        // GET: AccountPayments/Create
        public IActionResult Create()
        {
            ViewData["AccountID"] = new SelectList(_context.Accounts, "AccountID", "AccountID");
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID");
            return View();
        }

        // POST: AccountPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountID,PaymentID")] AccountPayment accountPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountID"] = new SelectList(_context.Accounts, "AccountID", "AccountID", accountPayment.AccountID);
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID", accountPayment.PaymentID);
            return View(accountPayment);
        }

        // GET: AccountPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AccountPayments == null)
            {
                return NotFound();
            }

            var accountPayment = await _context.AccountPayments.FindAsync(id);
            if (accountPayment == null)
            {
                return NotFound();
            }
            ViewData["AccountID"] = new SelectList(_context.Accounts, "AccountID", "AccountID", accountPayment.AccountID);
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID", accountPayment.PaymentID);
            return View(accountPayment);
        }

        // POST: AccountPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountID,PaymentID")] AccountPayment accountPayment)
        {
            if (id != accountPayment.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountPaymentExists(accountPayment.AccountID))
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
            ViewData["AccountID"] = new SelectList(_context.Accounts, "AccountID", "AccountID", accountPayment.AccountID);
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID", accountPayment.PaymentID);
            return View(accountPayment);
        }

        // GET: AccountPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AccountPayments == null)
            {
                return NotFound();
            }

            var accountPayment = await _context.AccountPayments
                .Include(a => a.Account)
                .Include(a => a.Payments)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (accountPayment == null)
            {
                return NotFound();
            }

            return View(accountPayment);
        }

        // POST: AccountPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AccountPayments == null)
            {
                return Problem("Entity set 'MaelstromContext.AccountPayments'  is null.");
            }
            var accountPayment = await _context.AccountPayments.FindAsync(id);
            if (accountPayment != null)
            {
                _context.AccountPayments.Remove(accountPayment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountPaymentExists(int id)
        {
            return _context.AccountPayments.Any(e => e.AccountID == id);
        }
    }
}
