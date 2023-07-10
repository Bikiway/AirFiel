using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirFiel_Mariana_Oliveira.Data;
using AirFiel_Mariana_Oliveira.Data.Entities;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    public class AirplanesController : Controller
    {
        private readonly DataContext _context;

        public AirplanesController(DataContext context)
        {
            _context = context;
        }

        // GET: Airplanes
        public async Task<IActionResult> Index()
        {
            return View(await _context.airplains.ToListAsync());
        }

        // GET: Airplanes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplanes = await _context.airplains
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airplanes == null)
            {
                return NotFound();
            }

            return View(airplanes);
        }

        // GET: Airplanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FirstClass,SecondClass,Capacity1,Capacity2,ImagePlane")] Airplanes airplanes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airplanes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airplanes);
        }

        // GET: Airplanes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplanes = await _context.airplains.FindAsync(id);
            if (airplanes == null)
            {
                return NotFound();
            }
            return View(airplanes);
        }

        // POST: Airplanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FirstClass,SecondClass,Capacity1,Capacity2,ImagePlane")] Airplanes airplanes)
        {
            if (id != airplanes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airplanes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirplanesExists(airplanes.Id))
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
            return View(airplanes);
        }

        // GET: Airplanes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplanes = await _context.airplains
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airplanes == null)
            {
                return NotFound();
            }

            return View(airplanes);
        }

        // POST: Airplanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airplanes = await _context.airplains.FindAsync(id);
            _context.airplains.Remove(airplanes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirplanesExists(int id)
        {
            return _context.airplains.Any(e => e.Id == id);
        }
    }
}
