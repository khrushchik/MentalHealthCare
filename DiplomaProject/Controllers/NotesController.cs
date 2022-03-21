using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiplomaProject.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Collections;


namespace DiplomaProject.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            //var applicationDbContext = _context.Notes.Include(n => n.Activity).Include(n => n.Mood).Include(n => n.User);
            IQueryable<Note> applicationDbContext = _context.Notes.Include(n => n.Activity).Include(n => n.Mood).Include(n => n.User);

            if (!(searchString==null))
            {
                applicationDbContext = applicationDbContext.Where(s => s.noteDate == Convert.ToDateTime(searchString));
            }

            return View(await applicationDbContext.AsNoTracking().ToListAsync());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .Include(n => n.Activity)
                .Include(n => n.Mood)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            ViewData["activityId"] = new SelectList(_context.Activities, "id", "activityName");
            ViewData["moodId"] = new SelectList(_context.Moods, "id", "moodName");
            ViewData["userId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,noteDate,moodId,activityId,plans,plansDone,thoughts,userId")] Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["activityId"] = new SelectList(_context.Activities, "id", "activityName", note.activityId);
            ViewData["moodId"] = new SelectList(_context.Moods, "id", "moodName", note.moodId);
            ViewData["userId"] = new SelectList(_context.Users, "Id", "Email", note.userId);
            return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewData["activityId"] = new SelectList(_context.Activities, "id", "activityName", note.activityId);
            ViewData["moodId"] = new SelectList(_context.Moods, "id", "moodName", note.moodId);
            ViewData["userId"] = new SelectList(_context.Users, "Id", "Email", note.userId);
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,noteDate,moodId,activityId,plans,plansDone,thoughts,userId")] Note note)
        {
            if (id != note.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.id))
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
            ViewData["activityId"] = new SelectList(_context.Activities, "id", "activityName", note.activityId);
            ViewData["moodId"] = new SelectList(_context.Moods, "id", "moodName", note.moodId);
            ViewData["userId"] = new SelectList(_context.Users, "Id", "Email", note.userId);
            return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .Include(n => n.Activity)
                .Include(n => n.Mood)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.id == id);
        }
    }
}
