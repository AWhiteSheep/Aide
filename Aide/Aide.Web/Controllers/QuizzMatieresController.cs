using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aide.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Aide.Web.Controllers
{
    [Authorize]
    public class QuizzMatieresController : Controller
    {
        private readonly AideCoreContext _context;

        public QuizzMatieresController(AideCoreContext context)
        {
            _context = context;
        }

        // GET: QuizzMatieres
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuizzMatiere.ToListAsync());
        }

        // GET: QuizzMatieres/AjaxList
        public async Task<IActionResult> AjaxList()
        {
            return PartialView("Index", await _context.QuizzMatiere.ToListAsync());
        }

        // GET: QuizzMatieres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizzMatiere = await _context.QuizzMatiere
                .FirstOrDefaultAsync(m => m.IdentityKey == id);
            if (quizzMatiere == null)
            {
                return NotFound();
            }

            return View(quizzMatiere);
        }

        // GET: QuizzMatieres/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: QuizzMatieres/AjaxCreate
        public IActionResult AjaxCreate()
        {
            return PartialView("Create");
        }

        // POST: QuizzMatieres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentityKey,Titre")] QuizzMatiere quizzMatiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quizzMatiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quizzMatiere);
        }

        // POST: QuizzMatieres/AjaxCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> AjaxCreate([FromForm] QuizzMatiere quizzMatiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quizzMatiere);
                await _context.SaveChangesAsync();
                return quizzMatiere.IdentityKey.ToString();
            }
            return JsonConvert.SerializeObject(quizzMatiere).ToString();
        }
        // GET: QuizzMatieres/Row
        public async Task<IActionResult> Row(int id)
        {
            return PartialView("_QuizzMatiereRow", await _context.QuizzMatiere.FindAsync(id));
        }

        // GET: QuizzMatieres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizzMatiere = await _context.QuizzMatiere.FindAsync(id);
            if (quizzMatiere == null)
            {
                return NotFound();
            }
            return PartialView(quizzMatiere);
        }

        // PUT: QuizzMatieres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] QuizzMatiere quizzMatiere)
        {
            if (id != quizzMatiere.IdentityKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quizzMatiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizzMatiereExists(quizzMatiere.IdentityKey))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok();
            }
            return NoContent();
        }

        // GET: QuizzMatieres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizzMatiere = await _context.QuizzMatiere
                .FirstOrDefaultAsync(m => m.IdentityKey == id);
            if (quizzMatiere == null)
            {
                return NotFound();
            }

            return PartialView(quizzMatiere);
        }

        // DELETE: QuizzMatieres/DeleteConfirmed/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<string> DeleteConfirmed(int id)
        {
            var quizzMatiere = await _context.QuizzMatiere.FindAsync(id);
            _context.QuizzMatiere.Remove(quizzMatiere);
            await _context.SaveChangesAsync();
            return id.ToString();
        }

        private bool QuizzMatiereExists(int id)
        {
            return _context.QuizzMatiere.Any(e => e.IdentityKey == id);
        }
    }
}
