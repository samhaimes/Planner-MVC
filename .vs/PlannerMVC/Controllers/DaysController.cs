using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlannerMVC.Data;
using PlannerMVC.Models;

namespace PlannerMVC.Controllers
{
    public class DaysController : Controller
    {
        private readonly PlannerContext _context;

        public DaysController(PlannerContext context)
        {
            _context = context;
        }

        // GET: Days
        public async Task<IActionResult> Index()
        {
            return View(await _context.Day.ToListAsync());
        }

        private bool DayExists(string id)
        {
            return _context.Day.Any(e => e.Days == id);
        }
    }
}
