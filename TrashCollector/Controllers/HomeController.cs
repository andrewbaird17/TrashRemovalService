﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Customer"))
            {
                // Check if already a customer in Customers table
                var customerInDB = _context.Customers.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                if (customerInDB == null)
                {
                    return RedirectToAction("Create", "Customers");
                }
            }
            if (User.IsInRole("Employee"))
            {
                // Check if already a customer in EMployees table
                var employeeInDB = _context.Customers.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                if (employeeInDB == null)
                {
                    return RedirectToAction("Create", "Employees");
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
