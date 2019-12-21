using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_34_GymWebsite_MVC_Core;

namespace Lab_34_GymWebsite_MVC_Core.Controllers
{
    public class ExercisController : Controller
    {
        private readonly GymDatabaseModel _context;

        public ExercisController(GymDatabaseModel context)
        {
            _context = context;
        }

        // GET: Exercis
        public async Task<IActionResult> Index()
        {
            var gymDatabaseModel = _context.Exercises.Include(e => e.Category);
            return View(await gymDatabaseModel.ToListAsync());
        }

        // GET: Exercis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercis = await _context.Exercises
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (exercis == null)
            {
                return NotFound();
            }

            return View(exercis);
        }

        // GET: Exercis/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Exercis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseId,ExerciseName,CategoryId")] Exercis exercis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", exercis.CategoryId);
            return View(exercis);
        }

        // GET: Exercis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercis = await _context.Exercises.FindAsync(id);
            if (exercis == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", exercis.CategoryId);
            return View(exercis);
        }

        // POST: Exercis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseId,ExerciseName,CategoryId")] Exercis exercis)
        {
            if (id != exercis.ExerciseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercisExists(exercis.ExerciseId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", exercis.CategoryId);
            return View(exercis);
        }

        // GET: Exercis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercis = await _context.Exercises
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (exercis == null)
            {
                return NotFound();
            }

            return View(exercis);
        }

        // POST: Exercis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercis = await _context.Exercises.FindAsync(id);
            _context.Exercises.Remove(exercis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercisExists(int id)
        {
            return _context.Exercises.Any(e => e.ExerciseId == id);
        }
    }
}
