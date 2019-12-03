using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetInternetQuizer.Data;

namespace ProjetInternetQuizer.Controllers
{
    public class UtilisateursController : Controller
    {
        private readonly AideCoreContext _context;

        public UtilisateursController(AideCoreContext context)
        {
            _context = context;
        }

        // GET: Utilisateurs
        public async Task<IActionResult> Index()
        {
            var aideCoreContext = _context.Utilisateur.Include(u => u.IdentityKeyRoleNavigation);
            return View(await aideCoreContext.ToListAsync());
        }

        // GET: Utilisateurs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateur
                .Include(u => u.IdentityKeyRoleNavigation)
                .FirstOrDefaultAsync(m => m.IdentityKey == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public IActionResult Create()
        {
            ViewData["IdentityKeyRole"] = new SelectList(_context.Role, "IdentityKey", "IdentityKey");
            return View();
        }

        // POST: Utilisateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentityKey,Id,IdentityKeyRole,Email,Nom,Prenom")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityKeyRole"] = new SelectList(_context.Role, "IdentityKey", "IdentityKey", utilisateur.IdentityKeyRole);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            ViewData["IdentityKeyRole"] = new SelectList(_context.Role, "IdentityKey", "IdentityKey", utilisateur.IdentityKeyRole);
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdentityKey,Id,IdentityKeyRole,Email,Nom,Prenom")] Utilisateur utilisateur)
        {
            if (id != utilisateur.IdentityKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateurExists(utilisateur.IdentityKey))
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
            ViewData["IdentityKeyRole"] = new SelectList(_context.Role, "IdentityKey", "IdentityKey", utilisateur.IdentityKeyRole);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateur
                .Include(u => u.IdentityKeyRoleNavigation)
                .FirstOrDefaultAsync(m => m.IdentityKey == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var utilisateur = await _context.Utilisateur.FindAsync(id);
            _context.Utilisateur.Remove(utilisateur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurExists(string id)
        {
            return _context.Utilisateur.Any(e => e.IdentityKey == id);
        }
    }
}
