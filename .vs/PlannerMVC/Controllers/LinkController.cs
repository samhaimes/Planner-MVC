﻿using System;
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
    public class LinkController : Controller
    {
        private readonly PlannerContext _context;

        public LinkController(PlannerContext context)
        {
            _context = context;
        }

        // GET: Link
        public async Task<IActionResult> Index()
        {
            var plannerContext = _context.Link.Include(l => l.Activity).Include(l => l.Day);
            return View(await plannerContext.ToListAsync());
        }

        // GET: Link/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Link
                .Include(l => l.Activity)
                .Include(l => l.Day)
                .FirstOrDefaultAsync(m => m.LinkId == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // GET: Link/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName");
            ViewData["DayId"] = new SelectList(_context.Day, "DayId", "DayId");
            return View();
        }

        // POST: Link/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkId,ActivityId,DayId")] Link link)
        {
            if (ModelState.IsValid)
            {
                _context.Add(link);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName", link.ActivityId);
            ViewData["DayId"] = new SelectList(_context.Day, "DayId", "DayId", link.DayId);
            return View(link);
        }

        // GET: Link/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Link.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName", link.ActivityId);
            ViewData["DayId"] = new SelectList(_context.Day, "DayId", "DayId", link.DayId);
            return View(link);
        }

        // POST: Link/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinkId,ActivityId,DayId")] Link link)
        {
            if (id != link.LinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(link);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinkExists(link.LinkId))
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
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName", link.ActivityId);
            ViewData["DayId"] = new SelectList(_context.Day, "DayId", "DayId", link.DayId);
            return View(link);
        }

        // GET: Link/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Link
                .Include(l => l.Activity)
                .Include(l => l.Day)
                .FirstOrDefaultAsync(m => m.LinkId == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // POST: Link/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var link = await _context.Link.FindAsync(id);
            _context.Link.Remove(link);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinkExists(int id)
        {
            return _context.Link.Any(e => e.LinkId == id);
        }
    }
}
