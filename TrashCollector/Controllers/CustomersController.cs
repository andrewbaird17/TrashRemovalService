using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(Customer customer)
        {
            var customerInDB = _context.Customers.Where(c=>c.Id == customer.Id).Include("Account");
            return View(await customerInDB.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.Include(c => c.Account).Include(c => c.Account.Address).FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                var customerInDB = _context.Customers.Single(m => m.Id == customer.Id);
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customerInDB.IdentityUserId = userId;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Customers");
            }
            else
            {
                return await Create(customer);
            }
        }

        // GET: Customers/EditPickUpDay
        public async Task<IActionResult> EditPickUpDay(int? id)
        {
            var customer = await _context.Customers.Include("Account").FirstOrDefaultAsync(m => m.Id == id);
            return View(customer);
        }

        // POST: Customers/EditPickUpDay
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPickUpDay(Customer customer)
        {
            var customerInDB = await _context.Customers.Include(c => c.Account).FirstOrDefaultAsync(m => m.Id == customer.Id);
            customerInDB.Account.PickUpDay = customer.Account.PickUpDay;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Customers",customerInDB);
        }

        // GET: Customers/EditOneTimePickUP
        public async Task<IActionResult> EditOneTimePickUp(int? id)
        {
            var customer = await _context.Customers.Include("Account").FirstOrDefaultAsync(m => m.Id == id);
            return View(customer);
        }

        // POST: Customers/EditOneTimePickUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOneTimePickUp(Customer customer)
        {
            var customerInDB = await _context.Customers.Include(c => c.Account).FirstOrDefaultAsync(m => m.Id == customer.Id);
            customerInDB.Account.OneTimePickup = customer.Account.OneTimePickup;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Customers", customerInDB);
        }

        // GET: Customers/EditServiceSuspension
        public async Task<IActionResult> EditServiceSuspension(int? id)
        {
            var customer = await _context.Customers.Include("Account").FirstOrDefaultAsync(m => m.Id == id);
            return View(customer);
        }

        // POST: Customers/EditServiceSuspension
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditServiceSuspension(Customer customer)
        {
            var customerInDB = await _context.Customers.Include(c => c.Account).FirstOrDefaultAsync(m => m.Id == customer.Id);
            customerInDB.Account.IsSuspended = customer.Account.IsSuspended;
            customerInDB.Account.StartDateSuspend = customer.Account.StartDateSuspend;
            customerInDB.Account.EndDateSuspend = customer.Account.EndDateSuspend;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Customers", customerInDB);
        }
        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Account)
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
