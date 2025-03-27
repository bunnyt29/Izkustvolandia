using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Izkustvolandia.Data;
using Izkustvolandia.Domain;
using Izkustvolandia.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Izkustvolandia.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IzkustvolandiaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<User> _userManager;


        public ProductsController(IzkustvolandiaDbContext context,
            IWebHostEnvironment webhostEnvironment, UserManager<User> userManager)
        {
            _context = context;
            _webHostEnvironment = webhostEnvironment;
            _userManager = userManager;
        }
        
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var productListingModel = await this.GetListingProductViewModel();

            productListingModel.Products = await _context.Products
                .Include(p => p.Genres)
                .Include(p => p.DrawingTechniques)
                .Select(p => new DetailsProductViewModel()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Author = p.Author,
                    Width = p.Width,
                    Height = p.Height,
                    Price = p.Price,
                    Genres = p.Genres,
                    DrawingTechniques = p.DrawingTechniques
                })
                .ToListAsync();
            
            productListingModel.MinPrice = (int)Math.Floor(productListingModel.Products.Min(p => p.Price));
            productListingModel.MaxPrice = (int)Math.Ceiling(productListingModel.Products.Max(p => p.Price));
            
            return View(productListingModel);
        }

        public async Task<IActionResult> FilterByGenre(int genreId)
        {
            var productListingModel = await this.GetListingProductViewModel();
       
            productListingModel.Products = await _context.Products
                .Where(p => p.Genres.Any(g => g.GenreId == genreId))
                .Include(p => p.DrawingTechniques)
                .Include(p => p.Genres)
                .Select(p => new DetailsProductViewModel()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Author = p.Author,
                    Width = p.Width,
                    Height = p.Height,
                    Price = p.Price,
                    Genres = p.Genres,
                    DrawingTechniques = p.DrawingTechniques
                })
                .ToListAsync();

            return View(nameof(All), productListingModel);
        }
        
        public async Task<IActionResult> FilterByDrawingTechnique(int drawingTechniqueId)
        {
            var productListingModel = await this.GetListingProductViewModel();
       
            productListingModel.Products = await _context.Products
                .Where(p => p.DrawingTechniques.Any(dt => dt.DrawingTechniqueId == drawingTechniqueId))
                .Include(p => p.DrawingTechniques)
                .Include(p => p.Genres)
                .Select(p => new DetailsProductViewModel()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Author = p.Author,
                    Width = p.Width,
                    Height = p.Height,
                    Price = p.Price,
                    Genres = p.Genres,
                    DrawingTechniques = p.DrawingTechniques
                })
                .ToListAsync();

            return View(nameof(All), productListingModel);
        }
        
        public async Task<IActionResult> FilterByPrice(int minPrice, int maxPrice)
        {
            var productListingModel = await this.GetListingProductViewModel();
            
            productListingModel.Products = await _context.Products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .Include(p => p.Genres)
                .Include(p => p.DrawingTechniques)
                .Select(p => new DetailsProductViewModel()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Author = p.Author,
                    Width = p.Width,
                    Height = p.Height,
                    Price = p.Price,
                    Genres = p.Genres,
                    DrawingTechniques = p.DrawingTechniques
                })
                .ToListAsync();

            return View(nameof(All), productListingModel);
        }
        
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Where(p => p.ProductId == id)
                .Select(p => new DetailsProductViewModel()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Author = p.Author,
                    Width = p.Width,
                    Height = p.Height,
                    Price = p.Price,
                    Genres = p.Genres,
                    DrawingTechniques = p.DrawingTechniques
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var genres = _context.Genres.ToList();
            var drawingTechniques = _context.DrawingTechniques.ToList();
            var model = new CreateProductInputModel
            {
                GenreIds = new List<int>(),
                DrawingTechniqueIds = new List<int>()
            };
            ViewBag.Genres = genres;
            ViewBag.DrawingTechniques = drawingTechniques;
            return View(model);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = _context.Genres.ToList();
                ViewBag.DrawingTechniques = _context.DrawingTechniques.ToList();
                return View(inputModel);
            }

            var fileName = UploadImage(inputModel.Image);

            var product = new Product
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                ImageUrl = fileName,
                Author = inputModel.Author,
                Width = inputModel.Width,
                Height = inputModel.Height,
                Price = inputModel.Price,
                Genres = new List<Genre>(),
                DrawingTechniques = new List<DrawingTechnique>()
            };

            if (inputModel.GenreIds != null && inputModel.GenreIds.Any())
            {
                product.Genres = _context.Genres
                    .Where(g => inputModel.GenreIds.Contains(g.GenreId))
                    .ToList();
            }
            
            if (inputModel.DrawingTechniqueIds != null && inputModel.DrawingTechniqueIds.Any())
            {
                product.DrawingTechniques = _context.DrawingTechniques
                    .Where(dt => inputModel.DrawingTechniqueIds.Contains(dt.DrawingTechniqueId))
                    .ToList();
            }

            _context.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var genres = _context.Genres.ToList();
            var drawingTechniques = _context.DrawingTechniques.ToList();
            ViewBag.Genres = genres;
            ViewBag.DrawingTechniques = drawingTechniques;

            var product = await _context.Products
                .Where(p => p.ProductId == id)
                .Select(p => new EditProductInputModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Author = p.Author,
                    Width = p.Width,
                    Height = p.Height,
                    Price = p.Price,
                    GenreIds = p.Genres.Select(g => g.GenreId).ToList(),
                    DrawingTechniqueIds = p.DrawingTechniques.Select(dt => dt.DrawingTechniqueId).ToList()
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
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, EditProductInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = _context.Genres.ToList();
                ViewBag.DrawingTechniques = _context.DrawingTechniques.ToList();
                return View(inputModel);
            }

            var product = await _context.Products
                .Where(p => p.ProductId == id)
                .Include(p => p.Genres)
                .Include(p => p.DrawingTechniques)
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
            product.Width = inputModel.Width;
            product.Height = inputModel.Height;
            product.Price = inputModel.Price;

            if (inputModel.GenreIds != null && inputModel.GenreIds.Any())
            {
                product.Genres.Clear();

                product.Genres = _context.Genres
                    .Where(g => inputModel.GenreIds.Contains(g.GenreId))
                    .ToList();
            }
            
            if (inputModel.DrawingTechniqueIds != null && inputModel.DrawingTechniqueIds.Any())
            {
                product.DrawingTechniques.Clear();

                product.DrawingTechniques = _context.DrawingTechniques
                    .Where(dt => inputModel.DrawingTechniqueIds.Contains(dt.DrawingTechniqueId))
                    .ToList();
            }

            _context.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
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
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var user = await this._userManager.GetUserAsync(User);

            var itemInCart = await _context.Carts.Where(c => c.ProductId == productId && c.UserId == user.Id).AnyAsync();

            if (!itemInCart)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
                user.Products.Add(product);
            }

            await this._context.SaveChangesAsync();

            return RedirectToAction("Details", "Products", new { Id = productId });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var user = await this._userManager.GetUserAsync(User);

            var productInCart = _context.Carts
                .Where(c => c.ProductId == id && c.UserId == user.Id)
                .FirstOrDefault();

            _context.Carts.Remove(productInCart);

            await this._context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }
        
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cart()
        {
            var user = await this._userManager.GetUserAsync(User);

            var productsInCart = await _context.Carts
                .Where(p => p.UserId == user.Id)
                .Select(c => new DetailsProductViewModel()
                {
                    ProductId = c.Product.ProductId,
                    Name = c.Product.Name,
                    Description = c.Product.Description,
                    ImageUrl = c.Product.ImageUrl,
                    Author = c.Product.Author,
                    Width = c.Product.Width,
                    Height = c.Product.Height,
                    Price = c.Product.Price,
                    Genres = c.Product.Genres,
                    DrawingTechniques = c.Product.DrawingTechniques

                })
                .ToListAsync();

            return View(productsInCart);
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
                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Image/product-images");

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
        
        private async Task<ListingProductViewModel> GetListingProductViewModel()
        {
            return new ListingProductViewModel()
            {
                Genres = await _context.Genres
                    .ToListAsync(),

                DrawingTechniques = await _context.DrawingTechniques
                    .ToListAsync(),
        
            };
        }
    }
}
