using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab3;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class StudentHobbiesController : Controller
    {
        private readonly ApplicationContext _context;

        public StudentHobbiesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: StudentHobbies
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.StudentHobby.Include(s => s.Hobby).Include(s => s.Student);
            return View(await applicationContext.ToListAsync());
        }

        // GET: StudentHobbies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentHobby = await _context.StudentHobby
                .Include(s => s.Hobby)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentHobby == null)
            {
                return NotFound();
            }

            return View(studentHobby);
        }

        // GET: StudentHobbies/Create
        public IActionResult Create()
        {
            ViewData["HobbyId"] = new SelectList(_context.Hobby, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: StudentHobbies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,HobbyId")] StudentHobby studentHobby)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentHobby);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HobbyId"] = new SelectList(_context.Hobby, "Id", "Id", studentHobby.HobbyId);
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", studentHobby.StudentId);
            return View(studentHobby);
        }

        // GET: StudentHobbies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentHobby = await _context.StudentHobby.FindAsync(id);
            if (studentHobby == null)
            {
                return NotFound();
            }
            ViewData["HobbyId"] = new SelectList(_context.Hobby, "Id", "Id", studentHobby.HobbyId);
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", studentHobby.StudentId);
            return View(studentHobby);
        }

        // POST: StudentHobbies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,HobbyId")] StudentHobby studentHobby)
        {
            if (id != studentHobby.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentHobby);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentHobbyExists(studentHobby.Id))
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
            ViewData["HobbyId"] = new SelectList(_context.Hobby, "Id", "Id", studentHobby.HobbyId);
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", studentHobby.StudentId);
            return View(studentHobby);
        }

        // GET: StudentHobbies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentHobby = await _context.StudentHobby
                .Include(s => s.Hobby)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentHobby == null)
            {
                return NotFound();
            }

            return View(studentHobby);
        }

        // POST: StudentHobbies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentHobby = await _context.StudentHobby.FindAsync(id);
            if (studentHobby != null)
            {
                _context.StudentHobby.Remove(studentHobby);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentHobbyExists(int id)
        {
            return _context.StudentHobby.Any(e => e.Id == id);
        }
    }
}
