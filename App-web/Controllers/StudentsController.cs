using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_web;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using App_web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using App_web.Models;
using Microsoft.AspNetCore.Identity;

namespace App_web.Controllers
{
    [Authorize(Roles = Roles.AdminRole)]
    public class StudentsController : Controller
    {
        private readonly ConectionDB _context;
        private readonly IWebHostEnvironment env;

        public StudentsController(ConectionDB context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Students
        //Aqui se resive la info del Search
        [AllowAnonymous]
        public async Task<IActionResult> Index(string textSearch, int? CareerId, int page = 1)
        {
            int RegisterForPage = 5;

            //Consulta con los filtros
            //Filtro para la busqueda de Name
            var conectionDB = _context.Students.Include(s => s.Career).Select(e => e);
            if (!string.IsNullOrEmpty(textSearch))
            {
                conectionDB = conectionDB.Where(e => e.Name.Contains(textSearch));
            }

            //Filtro para Careers
            if (CareerId.HasValue)
            {
                conectionDB = conectionDB.Where(e => e.CareerId == CareerId.Value);
            }

            //Generar pagina
            var registersShow = conectionDB
                .Skip((page - 1) * RegisterForPage)
                .Take(RegisterForPage);
             
            //Crear modelo para la vista
            StudentsViewModel model = new StudentsViewModel()
            {
                Students = await registersShow.ToListAsync(),
                ListCareers = new SelectList(_context.Careers, "Id", "Description", CareerId),
                textSearch = textSearch,
                CareerId = CareerId
            };

            model.Paginator.PageActual = page;
            model.Paginator.RegistersForPages = RegisterForPage;
            model.Paginator.TotalRegisters = await conectionDB.CountAsync();

            return View(model);

        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Career)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Description");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Year,CareerId,NamePhoto")] Student student)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;

                if(files != null && files.Count > 0)
                {
                    var filesPhoto = files[0];
                    var pathDesitine = Path.Combine(env.WebRootPath, "images\\students");
                    if (filesPhoto.Length > 0)
                    {
                        var fileDestine = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(filesPhoto.FileName);

                        using (var filestream = new FileStream(Path.Combine(pathDesitine, fileDestine), FileMode.Create))
                        {
                            filesPhoto.CopyTo(filestream);
                            student.NamePhoto = fileDestine;
                        }
                    }
                }

                _context.Add(student);
                await _context.SaveChangesAsync();

                //Profe intente hacer el auto-role al estudiante que recien se registra, pero me tiro error

                //var userAdmin = userManager.Users.Where(x => x.Email == Roles.MailAdminRole).FirstOrDefault();
                ////if (userAdmin != null) return;

                //userAdmin = new IdentityUser
                //{
                //    UserName = Roles.MailAdminRole,
                //    Email = Roles.MailAdminRole,
                //    EmailConfirmed = true,
                //    PhoneNumberConfirmed = true
                //};

                //await userManager.CreateAsync(userAdmin, "w5KYECgrWfKy3z");
                //await userManager.AddToRoleAsync(userAdmin, Roles.EstudianteRole);


                return RedirectToAction(nameof(Index));
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Description", student.CareerId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Students.FindAsync(id);
            var student = await _context.Students
                    .Include(x => x.StudentMatter)
                        .ThenInclude(m => m.Matter)
                    .FirstOrDefaultAsync(e => e.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Description", student.CareerId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Year,CareerId,NamePhoto")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    var filesPhoto = files[0];
                    var pathDesitine = Path.Combine(env.WebRootPath, "images\\students");
                    if (filesPhoto.Length > 0)
                    {
                        var fileDestine = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(filesPhoto.FileName);

                        using (var filestream = new FileStream(Path.Combine(pathDesitine, fileDestine), FileMode.Create))
                        {
                            filesPhoto.CopyTo(filestream);

                            string oldFile = Path.Combine(pathDesitine, student.NamePhoto ?? "");
                            if (System.IO.File.Exists(oldFile))
                                System.IO.File.Delete(oldFile); 
                            student.NamePhoto = fileDestine;
                        };
                    }
                }

                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Description", student.CareerId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Career)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
