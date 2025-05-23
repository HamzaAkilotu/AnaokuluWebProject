using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;

namespace AnaOkuluYS.Controllers
{
    public class EtkinlikTakvimiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtkinlikTakvimiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EtkinlikTakvimi
        public async Task<IActionResult> Index()
        {
            return View(await _context.EtkinlikTakvimi.ToListAsync());
        }

        // GET: EtkinlikTakvimi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etkinlikTakvimi = await _context.EtkinlikTakvimi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etkinlikTakvimi == null)
            {
                return NotFound();
            }

            return View(etkinlikTakvimi);
        }

        // GET: EtkinlikTakvimi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EtkinlikTakvimi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Baslik,Aciklama,BaslangicTarihi,BitisTarihi,Renk")] EtkinlikTakvimi etkinlikTakvimi)
        {
            if (ModelState.IsValid)
            {
                etkinlikTakvimi.OlusturulmaTarihi = DateTime.Now;
                _context.Add(etkinlikTakvimi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etkinlikTakvimi);
        }

        // GET: EtkinlikTakvimi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etkinlikTakvimi = await _context.EtkinlikTakvimi.FindAsync(id);
            if (etkinlikTakvimi == null)
            {
                return NotFound();
            }
            return View(etkinlikTakvimi);
        }

        // POST: EtkinlikTakvimi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama,BaslangicTarihi,BitisTarihi,Renk,OlusturulmaTarihi")] EtkinlikTakvimi etkinlikTakvimi)
        {
            if (id != etkinlikTakvimi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    etkinlikTakvimi.GuncellenmeTarihi = DateTime.Now;
                    _context.Update(etkinlikTakvimi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtkinlikTakvimiExists(etkinlikTakvimi.Id))
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
            return View(etkinlikTakvimi);
        }

        // GET: EtkinlikTakvimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etkinlikTakvimi = await _context.EtkinlikTakvimi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etkinlikTakvimi == null)
            {
                return NotFound();
            }

            return View(etkinlikTakvimi);
        }

        // POST: EtkinlikTakvimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etkinlikTakvimi = await _context.EtkinlikTakvimi.FindAsync(id);
            if (etkinlikTakvimi != null)
            {
                _context.EtkinlikTakvimi.Remove(etkinlikTakvimi);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EtkinlikTakvimiExists(int id)
        {
            return _context.EtkinlikTakvimi.Any(e => e.Id == id);
        }

        // GET: EtkinlikTakvimi/GetEvents
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.EtkinlikTakvimi
                .Select(e => new
                {
                    id = e.Id,
                    title = e.Baslik,
                    description = e.Aciklama,
                    start = e.BaslangicTarihi,
                    end = e.BitisTarihi,
                    color = e.Renk
                })
                .ToListAsync();

            return Json(events);
        }
    }
} 