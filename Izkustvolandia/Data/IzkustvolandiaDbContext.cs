using Izkustvolandia.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Izkustvolandia.Data;

public class IzkustvolandiaDbContext : IdentityDbContext<User>
{
    public IzkustvolandiaDbContext(DbContextOptions<IzkustvolandiaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<DrawingTechnique> DrawingTechniques { get; set; }
    
    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }
    
    public DbSet<Cart> Carts { get; set; }
    
    public DbSet<ProductGenre> ProductGenres { get; set; }
    
    public DbSet<ProductDrawingTechnique> ProductDrawingTechniques { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasMany(p => p.Genres)
            .WithMany(g => g.Products)
            .UsingEntity<ProductGenre>();
        
        builder.Entity<Product>()
            .HasMany(p => p.DrawingTechniques)
            .WithMany(dt => dt.Products)
            .UsingEntity<ProductDrawingTechnique>();
        
        builder.Entity<Product>()
            .HasMany(p => p.OrderProducts)
            .WithOne(o => o.Product);
        
        
        builder.Entity<Product>()
            .HasMany(p => p.Users)
            .WithMany(u => u.Products)
            .UsingEntity<Cart>();
        
        builder.Entity<Order>()
            .HasMany(o  => o.OrderProducts)
            .WithOne(op => op.Order);
        
        builder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders);
        
        var roleId = Guid.NewGuid().ToString();

        builder.Entity<IdentityRole>()
            .HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = roleId
            });

        var adminId = Guid.NewGuid().ToString();

        var admin = new User()
        {
            Id = adminId,
            Email = "admin@izkustvolandia.com",
            NormalizedEmail = "ADMIN@IZKUSTVOLANDIA.COM",
            EmailConfirmed = true,
            FirstName = "Иван",
            LastName = "Иванов",
            UserName = "admin@izkustvolandia.com",
            NormalizedUserName = "ADMIN@IZKUSTVOLANDIA.COM"
        };

        PasswordHasher<User> ph = new PasswordHasher<User>();
        admin.PasswordHash = ph.HashPassword(admin, "Admin_123");

        builder.Entity<User>()
            .HasData(admin);

        builder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });

        var userId = Guid.NewGuid().ToString();

        var user = new User()
        {
            Id = userId,
            Email = "user@izkustvolandia.com",
            NormalizedEmail = "USER@IZKUSTVOLANDIA.COM",
            EmailConfirmed = true,
            FirstName = "Иван",
            LastName = "Георгиев",
            UserName = "user@izkustvolandia.com",
            NormalizedUserName = "USER@IZKUSTVOLANDIA.COM"
        };

        user.PasswordHash = ph.HashPassword(user, "User_123");

        builder.Entity<User>()
            .HasData(user);
        
        base.OnModelCreating(builder);
        
        builder.Entity<Genre>().HasData(
            new Genre { GenreId = 1, Name = "Портрет" },
            new Genre { GenreId = 2, Name = "Пейзаж" },
            new Genre { GenreId = 3, Name = "Натюрморт" },
            new Genre { GenreId = 4, Name = "Историческа живопис" },
            new Genre { GenreId = 5, Name = "Религиозно изкуство" },
            new Genre { GenreId = 6, Name = "Жанрова живопис" },
            new Genre { GenreId = 7, Name = "Анималистика" },
            new Genre { GenreId = 8, Name = "Сюрреализъм" },
            new Genre { GenreId = 9, Name = "Абстрактно изкуство" },
            new Genre { GenreId = 10, Name = "Кубизъм" },
            new Genre { GenreId = 11, Name = "Импресионизъм" },
            new Genre { GenreId = 12, Name = "Неоимпресионизъм" }, // Твоето специално изискване
            new Genre { GenreId = 13, Name = "Поп арт" },
            new Genre { GenreId = 14, Name = "Миниатюра" }
        );

        builder.Entity<DrawingTechnique>().HasData(
            new DrawingTechnique { DrawingTechniqueId = 1, Name = "Маслени бои" },
            new DrawingTechnique { DrawingTechniqueId = 2, Name = "Акварел" },
            new DrawingTechnique { DrawingTechniqueId = 3, Name = "Темпера" },
            new DrawingTechnique { DrawingTechniqueId = 4, Name = "Графика" },
            new DrawingTechnique { DrawingTechniqueId = 5, Name = "Поантилизъм" }, // Неоимпресионизъм
            new DrawingTechnique { DrawingTechniqueId = 6, Name = "Фреска" },
            new DrawingTechnique { DrawingTechniqueId = 7, Name = "Гуаш" },
            new DrawingTechnique { DrawingTechniqueId = 8, Name = "Пастел" },
            new DrawingTechnique { DrawingTechniqueId = 9, Name = "Дигитална живопис" }
        );
        
        builder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1,
                ImageUrls = new List<string>{"mother-product-2-1.jpg","mother-product-2-2.jpg", "mother-product-2-3.jpg", "mother-product-2-4.jpg", "mother-product-2-5.jpg", "mother-product-2-6.jpg", "mother-product-2-7.jpg"},
                Name = "Майчина милувка 3",
                Description = "Размер на платното 15х20 см. Продава се с рамка с дебелина 1 см. Нарисувана с акрилни бои върху платно с четка.",
                Author = "Анна Петрова",
                Width = 15,
                Height = 20,
                Genres = new List<Genre>(),
                Price = 120.00m,
                CreatedOn = new DateTime(2024, 3, 1),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 2,
                ImageUrls = new List<string>{"mother-product-1-1.jpg","mother-product-1-2.jpg", "mother-product-1-3.jpg", "mother-product-1-4.jpg"},
                Name = "Майчина милувка 5",
                Description = "„Майчина милувка“ 5 е емоционална и изразителна картина, нарисувана с акрилни бои върху платно с помощта на четка и шпакли. Комбинацията от деликатни мазки и богата текстура придава дълбочина и характер на всяка линия. Платното е с размер 18х24 см и се предлага с елегантна рамка с дебелина 2 см, която допълва усещането за завършеност и уют.",
                Author = "Анна Петрова", 
                Width = 18,
                Height = 24,
                Price = 160.00m,
                CreatedOn = new DateTime(2024, 3, 15),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 3,
                ImageUrls = new List<string>{"one-1-product-4-1.jpg","one-1-product-4-2.jpg", "one-1-product-4-3.jpg", "one-1-product-4-4.jpg", "one-1-product-4-5.jpg", "one-1-product-4-6.jpg", "one-1-product-4-7.jpg"},
                Name = "Една 1",
                Description = "„Една“ 1 е елегантна творба, носеща усещане за нежност и самота. Създадена с акрилни бои върху платно, картината съчетава фини четкови мазки и текстури, постигнати с помощта на шпакли. Размерът ѝ е 15х20 см, а рамката с дебелина 1 см придава завършен и стилен вид.",
                Author = "Мария Николова",
                Width = 15,
                Height = 20,
                Price = 110.00m,
                CreatedOn = new DateTime(2024, 3, 20),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 4,
                ImageUrls = new List<string>{"one-product-3-1.jpg","one-product-3-2.jpg", "one-product-3-3.jpg", "one-product-3-4.jpg", "one-product-3-5.jpg", "one-product-3-6.jpg"},
                Name = "Една",
                Description = "„Една“ е картина, която разказва история чрез усещане и текстура. Създадена с акрилни бои върху платно, комбинира изразителни четкови мазки и грубата чувственост на шпаклата. Композицията е с размер 15х20 см и е обрамчена с деликатна 1-сантиметрова рамка, която подчертава емоционалната ѝ наситеност.",
                Author = "Никол Симеонова",
                Width = 15,
                Height = 20,
                Price = 105.00m,
                CreatedOn = new DateTime(2024, 3, 25),
                IsDeleted = false
            }
        );

        builder.Entity<ProductGenre>().HasData(
            new ProductGenre { ProductId = 1, GenreId = 1 },

            new ProductGenre { ProductId = 2, GenreId = 4 },

            new ProductGenre { ProductId = 3, GenreId = 1 },
            
            new ProductGenre { ProductId = 4, GenreId = 5 }
        );
        
        builder.Entity<ProductDrawingTechnique>().HasData(
            new ProductDrawingTechnique { ProductId = 1, DrawingTechniqueId = 2 },

            new ProductDrawingTechnique { ProductId = 2, DrawingTechniqueId = 3 },

            new ProductDrawingTechnique { ProductId = 3, DrawingTechniqueId = 1 },
            
            new ProductDrawingTechnique { ProductId = 4, DrawingTechniqueId = 2 }
        );
    }
}