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
        public async Task<IActionResult> All(string sortOrder)
        {
            var productListingModel = await this.GetListingProductViewModel();

            productListingModel.sortedBy = sortOrder;

            var productQuery = _context.Products
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Genres)
                .Include(p => p.DrawingTechniques)
                .Select(p => new ProductViewModel()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrls = p.ImageUrls,
                    Author = p.Author,
                    Width = p.Width,
                    Height = p.Height,
                    Price = p.Price,
                    Genres = p.Genres,
                    DrawingTechniques = p.DrawingTechniques
                });
            
            productQuery = sortOrder == "desc"
                ? productQuery.OrderByDescending(p => p.Price)
                : productQuery.OrderBy(p => p.Price);
            
            productListingModel.Products = await productQuery.ToListAsync();
            
            productListingModel.Filters.MinPrice = (int)Math.Floor(productListingModel.Products.Min(p => p.Price));
            productListingModel.Filters.MaxPrice = (int)Math.Ceiling(productListingModel.Products.Max(p => p.Price));
            
            return View(productListingModel);
        }
        
        public async Task<IActionResult> Filter(ProductFiltersViewModel filter)
        {
            var productListingModel = await this.GetListingProductViewModel();
            
            var query = _context.Products
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Genres)
                .Include(p => p.DrawingTechniques)
                .AsQueryable();

            // Filter by Genre
            if (!string.IsNullOrEmpty(filter.Genre))
            {
                query = query.Where(p => p.Genres.Any(g => g.Name == filter.Genre));
                productListingModel.Filters.Genre = filter.Genre;
            }

            // Filter by DrawingTechnique
            if (!string.IsNullOrEmpty(filter.DrawingTechnique))
            {
                query = query.Where(p => p.DrawingTechniques.Any(dt => dt.Name == filter.DrawingTechnique));
                productListingModel.Filters.DrawingTechnique = filter.DrawingTechnique;
            }

            if (!string.IsNullOrEmpty(filter.Search))
            {
                query = query.Where(p => p.Name.Contains(filter.Search));
                productListingModel.Filters.Search = filter.Search;
            }
            
            productListingModel.Products = await query
                .Select(p => new ProductViewModel()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrls = p.ImageUrls,
                    Author = p.Author,
                    Width = p.Width,
                    Height = p.Height,
                    Price = p.Price,
                    Genres = p.Genres,
                    DrawingTechniques = p.DrawingTechniques
                })
                .ToListAsync();
            
            if (productListingModel.Products.Count > 0)
            {
                productListingModel.Filters.MinPrice = (int)Math.Floor(productListingModel.Products.Min(p => p.Price));
                productListingModel.Filters.MaxPrice = (int)Math.Ceiling(productListingModel.Products.Max(p => p.Price));
            }
    
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
                .Where(p => p.IsDeleted == false)
                .Select(p => new DetailsProductViewModel()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrls = p.ImageUrls,
                    Author = p.Author,
                    Width = p.Width,
                    Height = p.Height,
                    Price = p.Price,
                    Genres = p.Genres,
                    DrawingTechniques = p.DrawingTechniques
                })
                .FirstOrDefaultAsync();

            product.SimilarProducts = await _context.Products
                .Where(p => p.Genres.Any(g => g.GenreId == product.Genres.First().GenreId) && p.ProductId != product.ProductId && p.IsDeleted == false)
                .Distinct()
                .Take(4)
                .Select(p => new ProductViewModel()
                    {
                        ProductId = p.ProductId,
                        Name = p.Name,
                        Description = p.Description,
                        ImageUrls = p.ImageUrls,
                        Author = p.Author,
                        Width = p.Width,
                        Height = p.Height,
                        Price = p.Price,
                        Genres = p.Genres,
                        DrawingTechniques = p.DrawingTechniques
                    })
                .ToListAsync();

            if (product.SimilarProducts.Count == 0)
            {
                product.SimilarProducts = await _context.Products
                    .Where(p => p.ProductId != product.ProductId && p.IsDeleted == false)
                    .Distinct()
                    .Take(4)
                    .Select(p => new ProductViewModel()
                    {
                        ProductId = p.ProductId,
                        Name = p.Name,
                        Description = p.Description,
                        ImageUrls = p.ImageUrls,
                        Author = p.Author,
                        Width = p.Width,
                        Height = p.Height,
                        Price = p.Price,
                        Genres = p.Genres,
                        DrawingTechniques = p.DrawingTechniques
                    })
                    .ToListAsync();
            }
            
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

            var fileNames = UploadImages(inputModel.Images);

            var product = new Product
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                ImageUrls = fileNames,
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
                    ImageUrls = p.ImageUrls,
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

            if (inputModel.Images is not null)
            {
                var fileNames = UploadImages(inputModel.Images);
                product.ImageUrls = fileNames;
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
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var user = await this._userManager.GetUserAsync(User);

            var itemInCart = await _context.Carts
                .AnyAsync(c => c.ProductId == productId && c.UserId == user.Id);

            if (!itemInCart)
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(p => p.ProductId == productId);

                if (product != null)
                {
                    user.Products.Add(product);
                }
            }

            await _context.SaveChangesAsync();

            // Redirect to the previous page
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        [HttpGet]
        public async Task<IActionResult> CartSummary()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Json(new { count = 0 });
            }

            var count = await _context.Carts.CountAsync(c => c.UserId == user.Id);

            return Json(new { count });
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
                    ImageUrls = c.Product.ImageUrls,
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

                // Уверяваме се, че папката съществува
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
        
        private List<string> UploadImages(IFormFile[] files)
        {
            if (files != null && files.Length > 0)
            {
                List<string> fileNames = new List<string>();

                files = files.OrderBy(f => f.FileName).ToArray();
                
                foreach (var file in files)
                {
                    fileNames.Add(UploadImage(file));
                }
                
                return fileNames; 
            }

            return new List<string>();
        }
        
        
        private async Task<ListingProductViewModel> GetListingProductViewModel()
        {
            return new ListingProductViewModel()
            {
                Filters = new ProductFiltersViewModel()
                {
                    Genres = await _context.Genres
                        .ToListAsync(),

                    DrawingTechniques = await _context.DrawingTechniques
                        .ToListAsync()
                }
            };
        }
    }
}
