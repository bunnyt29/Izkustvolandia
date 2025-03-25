using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Izkustvolandia.Data;
using Izkustvolandia.Domain;
using Izkustvolandia.Models.Products;

namespace Izkustvolandia.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IzkustvolandiaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IzkustvolandiaDbContext context,
            IWebHostEnvironment webhostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webhostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(
                await _context.Products
                .Where(p => p.IsDeleted == false)
                .ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            var fileName = UploadImage(inputModel.Image);
            var product = new Product
            {
                ImageUrl = fileName,
                Name = inputModel.Name,
                Description = inputModel.Description,
                Author = inputModel.Author,
                Height = inputModel.Height,
                Width = inputModel.Width,
                Price = inputModel.Price,
            };
            
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Where(p => p.ProductId == id)
                .Select(p => new EditProductInputModel
                {
                    ProductId = p.ProductId,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Description = p.Description,
                    Author = p.Author,
                    Height = p.Height,
                    Width = p.Width,
                    Price = p.Price,
                })
                .FirstOrDefaultAsync();
            
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, EditProductInputModel inputModel)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == id)
                .FirstOrDefaultAsync();

            if (product is null)
            {
                return NotFound();
            }

            if (inputModel.Image is not null)
            {
                var fileName = UploadImage(inputModel.Image);
                product.ImageUrl = fileName;
            }
            
            product.Name = inputModel.Name;
            product.Description = inputModel.Description;
            product.Author = inputModel.Author;
            product.Height = inputModel.Height;
            product.Width = inputModel.Width;
            product.Price = inputModel.Price;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        private string UploadImage(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Създаване на уникално име за файла
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Път към папката wwwroot/Image
                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Image");

                // Увери се, че папката съществува
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string filePath = Path.Combine(uploadPath, fileName);

                // Запис на файла чрез FileStream
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return fileName; // Връща името на файла, което ще запазим в базата
            }

            return "";
        }
    }
}
