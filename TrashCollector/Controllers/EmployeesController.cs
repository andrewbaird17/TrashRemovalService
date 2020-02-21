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
        public async Task<IActionResult> Index(Employee employee)
        {
            var todayDayOfWeek = DateTime.Today.DayOfWeek;
            var todayDateTime = DateTime.Today.Day;
            var employeeinDB = employee;
            //Limit by in ZipCOde, IsSuspended, PickUpDay today, (have to add onetimepickup somehow)
            var customersToday = _context.Customers.Where(c => c.Account.Address.ZipCode == employeeinDB.RouteZipCode)
                .Where(c => c.Account.IsSuspended == false)
                .Where(c => c.Account.PickUpDay == todayDayOfWeek)
                .Include(c=>c.Account)
                .Include(c=>c.Account.Address);
            var customersTodayOneTime = _context.Customers.Where(c => c.Account.Address.ZipCode == employeeinDB.RouteZipCode)
                .Where(c => c.Account.IsSuspended == false)
                .Where(c=> c.Account.OneTimePickup.Day == todayDateTime)
                .Include(c => c.Account)
                .Include(c => c.Account.Address);
            var customersInDBToday = customersToday.Concat(customersTodayOneTime);
            return View(await customersInDBToday.ToListAsync());
        }

        //public async Task<IActionResult> IndexSelect(Employee employee)
        //{
        //    // should create a different list of customers based off of a different selected day
        //    var day = DateTime.Today.DayOfWeek;
        //    var employeeinDB = employee;
        //    var customersInDBDay = _context.Customers.Where(c => c.Account.Address.ZipCode == employeeinDB.RouteZipCode).Where(c => c.Account.PickUpDay == day).Include(c => c.Account).Include(c => c.Account.Address);
        //    return View(await customersInDBDay.ToListAsync());
        //}

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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RouteZipCode")] Employee employee)
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
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RouteZipCode,IdentityUserId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
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
