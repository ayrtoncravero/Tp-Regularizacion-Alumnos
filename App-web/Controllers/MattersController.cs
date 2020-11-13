using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_web;
using Microsoft.AspNetCore.Authorization;
using App_web.Models;

namespace App_web.Controllers
{
    [Authorize(Roles = Roles.AdminRole)]
    public class MattersController : Controller
    {
        private readonly ConectionDB _context;

        public MattersController(ConectionDB context)
        {
            _context = context;
        }

        // GET: Matters
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matters.ToListAsync());
        }

        // GET: Matters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matter = await _context.Matters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matter == null)
            {
                return NotFound();
            }

            return View(matter);
        }

        // GET: Matters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Matter matter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matter);
        }

        // GET: Matters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matter = await _context.Matters.FindAsync(id);
            if (matter == null)
            {
                return NotFound();
            }
            return View(matter);
        }

        // POST: Matters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Matter matter)
        {
            if (id != matter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatterExists(matter.Id))
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
            return View(matter);
        }

        // GET: Matters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matter = await _context.Matters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matter == null)
            {
                return NotFound();
            }

            return View(matter);
        }

        // POST: Matters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matter = await _context.Matters.FindAsync(id);
            _context.Matters.Remove(matter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatterExists(int id)
        {
            return _context.Matters.Any(e => e.Id == id);
        }
    }
}
