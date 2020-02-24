using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var todayDayOfWeek = DateTime.Today.DayOfWeek;
            var todayDateTime = DateTime.Today.Day;

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeinDB = _context.Employees.Where(e => e.IdentityUserId == userId).FirstOrDefault();

            //Limit by in ZipCOde, IsSuspended, PickUpDay today, add onetimepickup
            var customersToday = _context.Customers.Where(c => c.Account.Address.ZipCode == employeeinDB.RouteZipCode)
                .Where(c => c.Account.IsSuspended == false)
                .Where(c => c.Account.PickUpDay == todayDayOfWeek)
                .Include(c => c.Account)
                .Include(c => c.Account.Address);
            var customersTodayOneTime = _context.Customers.Where(c => c.Account.Address.ZipCode == employeeinDB.RouteZipCode)
                .Where(c => c.Account.IsSuspended == false)
                .Where(c => c.Account.OneTimePickup.Day == todayDateTime)
                .Include(c => c.Account)
                .Include(c => c.Account.Address);

            var customersInDBToday = customersToday.Concat(customersTodayOneTime);
            return View(await customersInDBToday.ToListAsync());
        }

        public async Task<IActionResult> SelectDayToView(DayOfWeek daySelected)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeinDB = _context.Employees.Where(e => e.IdentityUserId == userId).FirstOrDefault();

            //Limit by in ZipCode, IsSuspended, PickUpDay selected day of week
            var customersForDay = _context.Customers.Where(c => c.Account.Address.ZipCode == employeeinDB.RouteZipCode)
                .Where(c => c.Account.IsSuspended == false)
                .Where(c => c.Account.PickUpDay == daySelected)
                .Include(c => c.Account)
                .Include(c => c.Account.Address);

            return View(await customersForDay.ToListAsync());
        }

        public async Task<IActionResult> ConfirmAndChargeAccount(Customer customer)
        {
            var todayDateTime = DateTime.Today.Day;
            var customerInDB = await _context.Customers.Include(c => c.Account).FirstOrDefaultAsync(m => m.Id == customer.Id);
            if (customerInDB.Account.IsPickedUp != true)
            {
                customerInDB.Account.IsPickedUp = true;
                customerInDB.Account.Balance += 75;
                await _context.SaveChangesAsync();
            }
            else if(customerInDB.Account.OneTimePickup.Day == todayDateTime)
            {
                customerInDB.Account.Balance += 75;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Employees");
        }

        public async Task<IActionResult> SeeOnMap(Customer customer)
        {
            var customerInDB = await _context.Customers.Include(c => c.Account).Include(c=>c.Account.Address).FirstOrDefaultAsync(m => m.Id == customer.Id);
            return View(customerInDB);
        }
        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                var employeeInDB = _context.Employees.Single(m => m.Id == employee.Id);
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employeeInDB.IdentityUserId = userId;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Employees", employee.Id);
            }
            else
            {
                return await Create(employee);
            }

        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {

            _context.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
