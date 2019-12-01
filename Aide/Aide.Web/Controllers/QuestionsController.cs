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
    public class QuestionsController : Controller
    {
        private readonly AideCoreContext _context;

        public QuestionsController(AideCoreContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var aideCoreContext = _context.Question.Include(q => q.IdentityKeyQuestionTypeNavigation).Include(q => q.IdentityKeyQuizzNavigation);
            return View(await aideCoreContext.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.IdentityKeyQuestionTypeNavigation)
                .Include(q => q.IdentityKeyQuizzNavigation)
                .FirstOrDefaultAsync(m => m.IdentityKey == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            ViewData["IdentityKeyQuestionType"] = new SelectList(_context.QuestionType, "IdentityKey", "Nom");
            ViewData["IdentityKeyQuizz"] = new SelectList(_context.Quizz, "IdentityKey", "Titre");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentityKey,IdentityKeyQuizz,IdentityKeyQuestionType,Numero,Points,Question1")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityKeyQuestionType"] = new SelectList(_context.QuestionType, "IdentityKey", "Nom", question.IdentityKeyQuestionType);
            ViewData["IdentityKeyQuizz"] = new SelectList(_context.Quizz, "IdentityKey", "Titre", question.IdentityKeyQuizz);
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["IdentityKeyQuestionType"] = new SelectList(_context.QuestionType, "IdentityKey", "Nom", question.IdentityKeyQuestionType);
            ViewData["IdentityKeyQuizz"] = new SelectList(_context.Quizz, "IdentityKey", "Titre", question.IdentityKeyQuizz);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdentityKey,IdentityKeyQuizz,IdentityKeyQuestionType,Numero,Points,Question1")] Question question)
        {
            if (id != question.IdentityKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.IdentityKey))
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
            ViewData["IdentityKeyQuestionType"] = new SelectList(_context.QuestionType, "IdentityKey", "Nom", question.IdentityKeyQuestionType);
            ViewData["IdentityKeyQuizz"] = new SelectList(_context.Quizz, "IdentityKey", "Titre", question.IdentityKeyQuizz);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.IdentityKeyQuestionTypeNavigation)
                .Include(q => q.IdentityKeyQuizzNavigation)
                .FirstOrDefaultAsync(m => m.IdentityKey == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Question.FindAsync(id);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.IdentityKey == id);
        }
    }
}
