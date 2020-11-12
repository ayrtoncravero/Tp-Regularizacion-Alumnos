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
    [Authorize(Roles = Roles.SuperAdminRole)]
    public class StudentMattersController : Controller
    {
        private readonly ConectionDB _context;

        public StudentMattersController(ConectionDB context)
        {
            _context = context;
        }

        // GET: StudentMatters
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var conectionDB = _context.StudentMatters.Include(s => s.Matter).Include(s => s.Student);
            return View(await conectionDB.ToListAsync());
        }

        // GET: StudentMatters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMatter = await _context.StudentMatters
                .Include(s => s.Matter)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentMatter == null)
            {
                return NotFound();
            }

            return View(studentMatter);
        }

        // GET: StudentMatters/Create
        public IActionResult Create()
        {
            ViewData["MatterId"] = new SelectList(_context.Matters, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            return View();
        }

        // POST: StudentMatters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,MatterId,EnrollmentDate")] StudentMatter studentMatter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentMatter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatterId"] = new SelectList(_context.Matters, "Id", "Id", studentMatter.MatterId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", studentMatter.StudentId);
            return View(studentMatter);
        }

        // GET: StudentMatters/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var studentMatter = await _context.StudentMatters.FindAsync(id);
        //    if (studentMatter == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["MatterId"] = new SelectList(_context.Matters, "Id", "Id", studentMatter.MatterId);
        //    ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", studentMatter.StudentId);
        //    return View(studentMatter);
        //}

        public async Task<IActionResult> Edit(int? idStudent, int? idMatter)
        {
            if (idStudent == null || idMatter == null)
            {
                return NotFound();
            }
            var studentmatter = await _context.StudentMatters.FindAsync(idStudent, idMatter);
            if (studentmatter == null)
            {
                return NotFound();
            }
            ViewData["estudianteId"] = new SelectList(_context.Students, "id", "apellido", studentmatter.StudentId);
            ViewData["materiaId"] = new SelectList(_context.Matters, "id", "nombre", studentmatter.MatterId);
            return View(studentmatter);
        }

        // POST: StudentMatters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,MatterId,EnrollmentDate")] StudentMatter studentMatter)
        {
            if (id != studentMatter.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentMatter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentMatterExists(studentMatter.StudentId))
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
            ViewData["MatterId"] = new SelectList(_context.Matters, "Id", "Id", studentMatter.MatterId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", studentMatter.StudentId);
            return View(studentMatter);
        }

        // GET: StudentMatters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMatter = await _context.StudentMatters
                .Include(s => s.Matter)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentMatter == null)
            {
                return NotFound();
            }

            return View(studentMatter);
        }

        // POST: StudentMatters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentMatter = await _context.StudentMatters.FindAsync(id);
            _context.StudentMatters.Remove(studentMatter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentMatterExists(int id)
        {
            return _context.StudentMatters.Any(e => e.StudentId == id);
        }
    }
}
