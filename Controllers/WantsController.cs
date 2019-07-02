using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookShop.Controllers
{
    [Authorize]
    public class WantsController : Controller
    {
        private readonly BookShopContext _context;

        public WantsController(BookShopContext context)
        {
            _context = context;
        }

        // GET: Wants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Want.ToListAsync());
        }

        // GET: Wants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var want = await _context.Want
                .FirstOrDefaultAsync(m => m.id == id);
            if (want == null)
            {
                return NotFound();
            }

            return View(want);
        }

        // GET: Wants/Create
        public IActionResult Create()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View();
        }

        // POST: Wants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price")] Want want)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                want.OwnerId = userId;
                _context.Add(want);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(want);
        }

        // GET: Wants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var want = await _context.Want.FindAsync(id);
            if (want == null)
            {
                return NotFound();
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (want.OwnerId != userId)
            {
                return NoContent();
            }
            return View(want);
        }

        // POST: Wants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price")] Want want)
        {
            if (id != want.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    if (want.OwnerId != userId)
                    {
                        return NoContent();
                    }
                    _context.Update(want);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WantExists(want.id))
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
            return View(want);
        }

        // GET: Wants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var want = await _context.Want
                .FirstOrDefaultAsync(m => m.id == id);
            if (want == null)
            {
                return NotFound();
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (want.OwnerId != userId)
            {
                return NoContent();
            }

            return View(want);
        }

        // POST: Wants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var want = await _context.Want.FindAsync(id);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (want.OwnerId != userId)
            {
                return NoContent();
            }
            _context.Want.Remove(want);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WantExists(int id)
        {
            return _context.Want.Any(e => e.id == id);
        }
    }
}
