using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JokesWebApp.Data;
using JokesWebApp.Models;
using Microsoft.AspNetCore;
using JokesWebApp.Data.Migrations;
using Microsoft.AspNetCore.Authorization;

namespace JokesWebApp.Controllers
{
    public class СoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public СoursesController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        // GET: Сourses
        public async Task<IActionResult> Index()
        {
            return _context.Courses != null ?
                        View(await _context.Courses.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Courses'  is null.");
        }




        // GET: Jokes/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();

        }

        //POST: Jokes/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Courses.Where(j => j.Name.Contains(SearchPhrase)).ToListAsync());

        }


        // GET: Сourses/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var сourses = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сourses == null)
            {
                return NotFound();
            }

            return View(сourses);
        }

        // GET: Сourses/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }



       



        // POST: Сourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Сourses сourses)
        {

            _context.Attach(сourses);
            _context.Entry(сourses).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: Сourses/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var сourses = await _context.Courses.FindAsync(id);
            if (сourses == null)
            {
                return NotFound();
            }
            return View(сourses);
        }

        // POST: Сourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(Сourses сourses)
        {

            _context.Update(сourses);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Сourses/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var сourses = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сourses == null)
            {
                return NotFound();
            }

            return View(сourses);
        }

        // POST: Сourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Courses'  is null.");
            }
            var сourses = await _context.Courses.FindAsync(id);
            if (сourses != null)
            {
                _context.Courses.Remove(сourses);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool СoursesExists(int id)
        {
            return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}