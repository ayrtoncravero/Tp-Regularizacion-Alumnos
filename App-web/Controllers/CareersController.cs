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
using Microsoft.AspNetCore.Hosting;
using App_web.ViewModel;

namespace App_web.Controllers
{
    public class CareersController : Controller
    {
        private readonly ConectionDB _context;
        private readonly IWebHostEnvironment env;

        public CareersController(ConectionDB context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Careers
        public async Task<IActionResult> Index(int page = 1)
        {
            Paginator paginator = new Paginator();
            int RegisterForPage = 5;

            var registersShow = _context.Careers
                .Skip((page - 1) * RegisterForPage)
                .Take(RegisterForPage);

            paginator.PageActual = page;
            paginator.RegistersForPages = RegisterForPage;
            paginator.TotalRegisters = await _context.Careers.CountAsync();

            ViewBag.Paginator = paginator;

            return View(await _context.Careers.ToListAsync());
        }

        // GET: Careers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Careers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }

        // GET: Careers/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Careers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] Career career)
        {
            if (ModelState.IsValid)
            {
                _context.Add(career);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(career);
        }

        // GET: Careers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Careers.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }
            return View(career);
        }

        // POST: Careers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] Career career)
        {
            if (id != career.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(career);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerExists(career.Id))
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
            return View(career);
        }

        // GET: Careers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Careers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }

        // POST: Careers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var career = await _context.Careers.FindAsync(id);
            _context.Careers.Remove(career);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException f)
            {
                if (f.InnerException.Message.Contains("REFERENCE constraint"))
                {
                    ModelState.AddModelError(string.Empty, "No se puede eliminar la carrera, ya que tiene estudantes inscriptos");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, f.InnerException.Message);
                }
            }
            catch (Exception f)
            {
                ModelState.AddModelError(string.Empty, f.Message);
            }

            return View(career);
        }

        private bool CareerExists(int id)
        {
            return _context.Careers.Any(e => e.Id == id);
        }
    }
}
