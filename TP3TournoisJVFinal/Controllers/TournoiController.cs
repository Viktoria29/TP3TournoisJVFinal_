using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3TournoisJVFinal.Models;

namespace TP3TournoisJVFinal.Controllers
{
    public class TournoiController : Controller
    {
        private readonly TournoiContext _context;

        public TournoiController(TournoiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tournois.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournois
                .FirstOrDefaultAsync(m => m.IdTournoi == id);
            if (tournoi == null)
            {
                return NotFound();
            }

            return View(tournoi);
        }
        public async Task<IActionResult> Recherche(string recherche)
        {
            return View("Index",await _context.Tournois.Where(t => t.Jeu.Contains(recherche) ||
                                                           t.Nom.Contains(recherche) ||
                                                           t.Date.Contains(recherche) ||
                                                           t.Prix.ToString().Contains(recherche) ||
                                                           t.Theme.Contains(recherche) ||
                                                           t.Description.Contains(recherche) ||
                                                           recherche == null).ToListAsync());
        }

        public async Task<IActionResult> RechercheAvance(string rechercheNom, string rechercheDate, string rechercheJeu, string recherchePrix, string rechercheTheme )
        {
            return View("Search", await _context.Tournois.Where(t => (t.Jeu.Contains(rechercheJeu) || rechercheJeu == null) &&
                                                            (t.Nom.Contains(rechercheNom) || rechercheNom == null) &&
                                                            (t.Date.Contains(rechercheDate) || rechercheDate == null) &&
                                                            (t.Prix.ToString().Contains(recherchePrix) || recherchePrix == null) &&
                                                            (t.Theme.Contains(rechercheTheme) || rechercheTheme == null)).ToListAsync()); ;
        }



        // GET: Tournoi/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Search()
        {
            return View(await _context.Tournois.ToListAsync());
        }

        // POST: Tournoi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTournoi,Nom,Prix,Description,Date,Jeu,Theme")] Tournoi tournoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tournoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tournoi);
        }

        // GET: Tournoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournois.FindAsync(id);
            if (tournoi == null)
            {
                return NotFound();
            }
            return View(tournoi);
        }

        // POST: Tournoi/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTournoi,Nom,Prix,Description,Date,Jeu,Theme")] Tournoi tournoi)
        {
            if (id != tournoi.IdTournoi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournoiExists(tournoi.IdTournoi))
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
            return View(tournoi);
        }

        // GET: Tournoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournois
                .FirstOrDefaultAsync(m => m.IdTournoi == id);
            if (tournoi == null)
            {
                return NotFound();
            }

            return View(tournoi);
        }

        // POST: Tournoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tournoi = await _context.Tournois.FindAsync(id);
            _context.Tournois.Remove(tournoi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TournoiExists(int id)
        {
            return _context.Tournois.Any(e => e.IdTournoi == id);
        }
    }
}
