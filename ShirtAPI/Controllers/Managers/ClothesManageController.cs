using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShirtAPI.DB;
using ShirtAPI.Models;

namespace ShirtAPI.Controllers
{
    public class ClothesManageController : Controller
    {
        private readonly ApplicationContext _context;

        public ClothesManageController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ClothesManage
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Clothes.Include(c => c.Category).Include(c => c.Type);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ClothesManage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes
                .Include(c => c.Category)
                .Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // GET: ClothesManage/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["TypeId"] = new SelectList(_context.Type, "Id", "Id");
            return View();
        }

        // POST: ClothesManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,CategoryId,Price,TypeId,Id,Created")] Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", clothes.CategoryId);
            ViewData["TypeId"] = new SelectList(_context.Type, "Id", "Id", clothes.TypeId);
            return View(clothes);
        }

        // GET: ClothesManage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes.FindAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", clothes.CategoryId);
            ViewData["TypeId"] = new SelectList(_context.Type, "Id", "Id", clothes.TypeId);
            return View(clothes);
        }

        // POST: ClothesManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,CategoryId,Price,TypeId,Id,Created")] Clothes clothes)
        {
            if (id != clothes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothesExists(clothes.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", clothes.CategoryId);
            ViewData["TypeId"] = new SelectList(_context.Type, "Id", "Id", clothes.TypeId);
            return View(clothes);
        }

        // GET: ClothesManage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes
                .Include(c => c.Category)
                .Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // POST: ClothesManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothes = await _context.Clothes.FindAsync(id);
            _context.Clothes.Remove(clothes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothesExists(int id)
        {
            return _context.Clothes.Any(e => e.Id == id);
        }
    }
}
