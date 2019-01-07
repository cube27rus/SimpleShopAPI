using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShirtAPI.DB;
using ShirtAPI.Models;

namespace ShirtAPI.Controllers.Managers
{
    public class ImagesManageController : Controller
    {
        private readonly ApplicationContext _context;
        private IHostingEnvironment _appEnvironment;
        public ImagesManageController(ApplicationContext context, 
            IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: ImagesManage
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Images.Include(i => i.Clothes);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ImagesManage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .Include(i => i.Clothes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: ImagesManage/Create
        public IActionResult Create()
        {
            ViewData["ClothesId"] = new SelectList(_context.Clothes, "Id", "Title");
            return View();
        }

        // POST: ImagesManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClothesId,Path,Alt,Id,Created")] Image image, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    // путь к папке Files
                    string path = "\\Images\\" + uploadedFile.FileName;
                    // сохраняем файл в папку Files в каталоге wwwroot
                    var localPath = _appEnvironment.WebRootPath + path;
                    using (var fileStream = new FileStream(localPath, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    var alt = uploadedFile.FileName;
                    var imgPath = path.Replace(@"\\", @"\");

                    image.Path = imgPath;
                    if (image.Alt == null)
                    {
                        image.Alt = alt;
                    }
                }
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClothesId"] = new SelectList(_context.Clothes, "Id", "Id", image.ClothesId);
            return View(image);
        }

        // GET: ImagesManage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);
            
            if (image == null)
            {
                return NotFound();
            }
            ViewData["ClothesId"] = new SelectList(_context.Clothes, "Id", "Id", image.ClothesId);
            ViewData["ClothesTitle"] = new SelectList(_context.Clothes, "Title", "Title", image.Clothes);
            return View(image);
        }

        // POST: ImagesManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClothesId,Path,Alt,Id,Created")] Image image, IFormFile uploadedFile)
        {
            if (id != image.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (uploadedFile != null)
                    {
                        var directoryPath = _appEnvironment.WebRootPath;
                        if ((System.IO.File.Exists(directoryPath + image.Path)))
                        {
                            System.IO.File.Delete(directoryPath + image.Path);
                        }
                        // путь к папке Files
                        string path = "\\Images\\" + uploadedFile.FileName;
                        // сохраняем файл в папку Files в каталоге wwwroot
                        var localPath = directoryPath + path;
                        using (var fileStream = new FileStream(localPath, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                        var alt = uploadedFile.FileName;
                        var imgPath = path.Replace(@"\\", @"\");

                        image.Path = imgPath;
                        image.Alt = alt;
                    }
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.Id))
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
            ViewData["ClothesId"] = new SelectList(_context.Clothes, "Id", "Id", image.ClothesId);
            return View(image);
        }

        // GET: ImagesManage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .Include(i => i.Clothes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: ImagesManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.Images.FindAsync(id);
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
