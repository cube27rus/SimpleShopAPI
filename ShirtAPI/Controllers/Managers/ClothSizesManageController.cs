using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShirtAPI.DB;
using ShirtAPI.Models;

namespace ShirtAPI.Controllers.Managers
{
    public class ClothSizesManageController : Controller
    {
        private readonly ApplicationContext _context;

        public ClothSizesManageController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ClothSizesManage
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ClothSize.Include(c => c.Clothes).Include(c => c.Size);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ClothSizesManage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothSize = await _context.ClothSize
                .Include(c => c.Clothes)
                .Include(c => c.Size)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothSize == null)
            {
                return NotFound();
            }

            return View(clothSize);
        }

        // GET: ClothSizesManage/Create
        public IActionResult Create()
        {
            ViewData["ClothesId"] = new SelectList(_context.Clothes, "Id", "Id");
            ViewData["SizeId"] = new SelectList(_context.Set<Size>(), "Id", "Id");
            return View();
        }

        // POST: ClothSizesManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClothesId,SizeId,Id,Created")] ClothSize clothSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClothesId"] = new SelectList(_context.Clothes, "Id", "Id", clothSize.ClothesId);
            ViewData["SizeId"] = new SelectList(_context.Set<Size>(), "Id", "Id", clothSize.SizeId);
            return View(clothSize);
        }

        // GET: ClothSizesManage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothSize = await _context.ClothSize.FindAsync(id);
            if (clothSize == null)
            {
                return NotFound();
            }
            ViewData["ClothesId"] = new SelectList(_context.Clothes, "Id", "Id", clothSize.ClothesId);
            ViewData["SizeId"] = new SelectList(_context.Set<Size>(), "Id", "Id", clothSize.SizeId);
            return View(clothSize);
        }

        // POST: ClothSizesManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClothesId,SizeId,Id,Created")] ClothSize clothSize)
        {
            if (id != clothSize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothSizeExists(clothSize.Id))
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
            ViewData["ClothesId"] = new SelectList(_context.Clothes, "Id", "Id", clothSize.ClothesId);
            ViewData["SizeId"] = new SelectList(_context.Set<Size>(), "Id", "Id", clothSize.SizeId);
            return View(clothSize);
        }

        // GET: ClothSizesManage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothSize = await _context.ClothSize
                .Include(c => c.Clothes)
                .Include(c => c.Size)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothSize == null)
            {
                return NotFound();
            }

            return View(clothSize);
        }

        // POST: ClothSizesManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothSize = await _context.ClothSize.FindAsync(id);
            _context.ClothSize.Remove(clothSize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothSizeExists(int id)
        {
            return _context.ClothSize.Any(e => e.Id == id);
        }
    }
}
