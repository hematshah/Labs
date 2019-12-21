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
    public class WorkoutLogController : Controller
    {
        private readonly GymDatabaseModel _context;

        public WorkoutLogController(GymDatabaseModel context)
        {
            _context = context;
        }

        // GET: WorkoutLog
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkoutLog.ToListAsync());
        }

        // GET: WorkoutLog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutLog = await _context.WorkoutLog
                .FirstOrDefaultAsync(m => m.WorkoutLogId == id);
            if (workoutLog == null)
            {
                return NotFound();
            }

            return View(workoutLog);
        }

        // GET: WorkoutLog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkoutLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkoutLogId,DateTime,ExerciseId")] WorkoutLog workoutLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutLog);
        }

        // GET: WorkoutLog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutLog = await _context.WorkoutLog.FindAsync(id);
            if (workoutLog == null)
            {
                return NotFound();
            }
            return View(workoutLog);
        }

        // POST: WorkoutLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkoutLogId,DateTime,ExerciseId")] WorkoutLog workoutLog)
        {
            if (id != workoutLog.WorkoutLogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutLogExists(workoutLog.WorkoutLogId))
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
            return View(workoutLog);
        }

        // GET: WorkoutLog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutLog = await _context.WorkoutLog
                .FirstOrDefaultAsync(m => m.WorkoutLogId == id);
            if (workoutLog == null)
            {
                return NotFound();
            }

            return View(workoutLog);
        }

        // POST: WorkoutLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutLog = await _context.WorkoutLog.FindAsync(id);
            _context.WorkoutLog.Remove(workoutLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutLogExists(int id)
        {
            return _context.WorkoutLog.Any(e => e.WorkoutLogId == id);
        }
    }
}
