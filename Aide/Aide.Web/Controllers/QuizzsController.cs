using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aide.Api.Models;

namespace Aide.Web.Controllers
{
    public class QuizzsController : Controller
    {
        private readonly AideCoreContext _context;

        public QuizzsController(AideCoreContext context)
        {
            _context = context;
        }

        // GET: Quizzs
        public async Task<IActionResult> Index()
        {
            var aideCoreContext = _context.Quizz.Include(q => q.IdentityKeyMatiereNavigation);
            return View(await aideCoreContext.ToListAsync());
        }

        // GET: Quizzs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizz = await _context.Quizz
                .Include(q => q.IdentityKeyMatiereNavigation)
                .FirstOrDefaultAsync(m => m.IdentityKey == id);
            if (quizz == null)
            {
                return NotFound();
            }

            return View(quizz);
        }

        // GET: Quizzs/Create
        public IActionResult Create()
        {
            ViewData["IdentityKeyMatiere"] = new SelectList(_context.QuizzMatiere, "IdentityKey", "Titre");
            return View();
        }

        // POST: Quizzs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentityKey,IdentityKeyMatiere,Titre,Description")] Quizz quizz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quizz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityKeyMatiere"] = new SelectList(_context.QuizzMatiere, "IdentityKey", "Titre", quizz.IdentityKeyMatiere);
            return View(quizz);
        }

        // GET: Quizzs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizz = await _context.Quizz.FindAsync(id);
            if (quizz == null)
            {
                return NotFound();
            }
            ViewData["IdentityKeyMatiere"] = new SelectList(_context.QuizzMatiere, "IdentityKey", "Titre", quizz.IdentityKeyMatiere);
            return View(quizz);
        }

        // POST: Quizzs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdentityKey,IdentityKeyMatiere,Titre,Description")] Quizz quizz)
        {
            if (id != quizz.IdentityKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quizz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizzExists(quizz.IdentityKey))
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
            ViewData["IdentityKeyMatiere"] = new SelectList(_context.QuizzMatiere, "IdentityKey", "Titre", quizz.IdentityKeyMatiere);
            return View(quizz);
        }

        // GET: Quizzs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizz = await _context.Quizz
                .Include(q => q.IdentityKeyMatiereNavigation)
                .FirstOrDefaultAsync(m => m.IdentityKey == id);
            if (quizz == null)
            {
                return NotFound();
            }

            return View(quizz);
        }

        // POST: Quizzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quizz = await _context.Quizz.FindAsync(id);
            _context.Quizz.Remove(quizz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizzExists(int id)
        {
            return _context.Quizz.Any(e => e.IdentityKey == id);
        }
    }
}
