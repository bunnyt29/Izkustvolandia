using Izkustvolandia.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Izkustvolandia.Data;

public class IzkustvolandiaDbContext : IdentityDbContext
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasMany(p => p.Genres)
            .WithMany(g => g.Products);
        
        builder.Entity<Product>()
            .HasMany(p => p.DrawingTechniques)
            .WithMany(dt => dt.Products);
        
        builder.Entity<Product>()
            .HasMany(p => p.OrderProducts)
            .WithOne(o => o.Product);
        
        
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
            UserName = "admin",
            NormalizedUserName = "ADMIN"
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
            UserName = "user",
            NormalizedUserName = "USER"
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
    }
}