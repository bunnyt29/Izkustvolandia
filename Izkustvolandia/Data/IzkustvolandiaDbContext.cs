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
            new Genre { GenreId = 12, Name = "Неоимпресионизъм" },
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
            },
            new Product
            {
                ProductId = 5,
                ImageUrls = new List<string>{"you-and-me-product-5-1.jpg","you-and-me-product-5-2.jpg", "you-and-me-product-5-3.jpg", "you-and-me-product-5-4.jpg", "you-and-me-product-5-5.jpg", "you-and-me-product-5-6.jpg"},
                Name = "Ти и аз 6",
                Description = "„Ти и аз“ 6 е нежна и хармонична картина, изразяваща силата на връзката между две души. Нарисувана с акрилни бои върху платно, използвайки фини четки, тя създава усещане за близост и топлина. Композицията е с квадратна форма – 20х20 см – и се предлага с елегантна рамка с дебелина 2 см, която допълва усещането за завършеност.",
                Author = "Елеонора Костова",
                Width = 20,
                Height = 20,
                Price = 135.00m,
                CreatedOn = new DateTime(2024, 3, 27),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 6,
                ImageUrls = new List<string>{"relax-product-6-1.jpg","relax-product-6-2.jpg", "relax-product-6-3.jpg", "relax-product-6-4.jpg", "relax-product-6-5.jpg", "relax-product-6-6.jpg"},
                Name = "Релакс 2",
                Description = "„Релакс“ 2 е съвременна композиция, която улавя спокойствието на един миг на уединение. Картината е изпълнена с акрилни бои върху платно, използвайки изразителни движения на шпаклата, което ѝ придава характер и дълбочина. С размер 20х25 см и стилна рамка с дебелина 2 см, творбата е подходящ акцент за всеки уютен интериор.",
                Author = "Стефан Велинов",
                Width = 20,
                Height = 25,
                Price = 145.00m,
                CreatedOn = new DateTime(2024, 3, 29),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 7,
                ImageUrls = new List<string>{"in-the-forest-product-7-1.jpg","in-the-forest-product-7-2.jpg", "in-the-forest-product-7-3.jpg", "in-the-forest-product-7-4.jpg", "in-the-forest-product-7-5.jpg", "in-the-forest-product-7-6.jpg"},
                Name = "В гората 2",
                Description = "„В гората“ 2 е живописен пейзаж, който пренася зрителя в сърцето на природата. Нарисувана с акрилни бои върху платно с помощта на четка и шпакли, картината комбинира фини детайли с богата текстура, за да улови магията на горската тишина. С размер 30х40 см и елегантна рамка с дебелина 2 см, творбата е идеален избор за любителите на природата и уюта.",
                Author = "Валери Димитров",
                Width = 30,
                Height = 40,
                Price = 180.00m,
                CreatedOn = new DateTime(2024, 3, 30),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 8,
                ImageUrls = new List<string>
                {
                    "radost-product-8-1.jpg",
                    "radost-product-8-2.jpg",
                    "radost-product-8-3.jpg"
                },
                Name = "Радост",
                Description = "„Радост“ е експресивна композиция от три отделни платна, обединени от цветна енергия и усещане за позитивност. Всяко платно е с размер 20х20 см, изрисувано с акрилни бои, използвайки четка и шпакли. Богатата текстура и живите цветове създават чувство на движение и хармония. Композицията е монтирана върху дървена подрамка с дебелина 2 см и е идеален избор за модерния интериор.",
                Author = "Калина Стоянова",
                Width = 60,
                Height = 20,
                Price = 210.00m,
                CreatedOn = new DateTime(2024, 3, 31),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 9,
                ImageUrls = new List<string>
                {
                    "idiliya-product-9-1.jpg",
                    "idiliya-product-9-2.jpg",
                    "idiliya-product-9-3.jpg",
                    "idiliya-product-9-4.jpg",
                    "idiliya-product-9-5.jpg"
                },
                Name = "Идилия",
                Description = "„Идилия“ е спокойна и вдъхновяваща творба, която пресъздава усещането за хармония и уют. Нарисувана с акрилни бои върху платно с размери 40х30 см, тя съчетава топли тонове и плавни преходи, за да създаде чувство на уравновесеност и съзерцание. Идеален избор за всеки, който търси изкуство с успокояващо присъствие.",
                Author = "Радостина Тодорова",
                Width = 40,
                Height = 30,
                Price = 190.00m,
                CreatedOn = new DateTime(2024, 4, 1),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 10,
                ImageUrls = new List<string>
                {
                    "tishina-product-10-1.jpg",
                    "tishina-product-10-2.jpg",
                    "tishina-product-10-3.jpg"
                },
                Name = "Тишина",
                Description = "„Тишина“ е дълбоко емоционална картина, която улавя усещането за вътрешен мир и съзерцание. Създадена с акрилни бои върху платно, използвайки подрамка, четка и шпакла, творбата съчетава текстура и плавни преходи, които приканват зрителя към спокойствие. Размерите ѝ са 40х30 см, а рамката с дебелина 2 см подчертава нейното естетическо въздействие.",
                Author = "Елица Ангелова",
                Width = 40,
                Height = 30,
                Price = 195.00m,
                CreatedOn = new DateTime(2024, 4, 2),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 11,
                ImageUrls = new List<string>
                {
                    "nadprevara-product-11-1.jpg",
                    "nadprevara-product-11-2.jpg",
                    "nadprevara-product-11-3.jpg",
                    "nadprevara-product-11-4.jpg",
                    "nadprevara-product-11-5.jpg"
                },
                Name = "Надпревара",
                Description = "„Надпревара“ е впечатляваща двукомпонентна композиция, излъчваща движение, енергия и контраст. Изпълнена с акрилни бои върху две платна с подрамка, творбата използва четка и шпакла, за да изгради богата текстура и визуален ритъм. Всяко платно е с размер 50х100 см, а рамките с дебелина 2 см придават завършеност и стил. „Надпревара“ е идеален акцент за модерен интериор с характер.",
                Author = "Александър Стефанов",
                Width = 100, 
                Height = 50, 
                Price = 360.00m,
                CreatedOn = new DateTime(2024, 4, 3),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 12,
                ImageUrls = new List<string>
                {
                    "melodiya-product-12-1.jpg",
                    "melodiya-product-12-2.jpg",
                    "melodiya-product-12-3.jpg",
                    "melodiya-product-12-4.jpg",
                    "melodiya-product-12-5.jpg"
                },
                Name = "Мелодия",
                Description = "„Мелодия“ е нежна триптих-композиция, която визуализира ритъма на емоциите чрез цвят и форма. Изградена от три платна с размер 20х20 см всяко, картината е нарисувана с акрилни бои, използвайки четка и шпакла за постигане на динамична текстура. Дървената подрамка с дебелина 2 см придава на композицията завършен вид, който е едновременно модерен и изразителен.",
                Author = "Ирина Михайлова",
                Width = 60, // 3 x 20 см
                Height = 20,
                Price = 225.00m,
                CreatedOn = new DateTime(2024, 4, 4),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 13,
                ImageUrls = new List<string>
                {
                    "kralitsa-product-13-1.jpg",
                    "kralitsa-product-13-2.jpg",
                    "kralitsa-product-13-3.jpg",
                    "kralitsa-product-13-4.jpg"
                },
                Name = "Кралица",
                Description = "„Кралица“ е внушителна и изразителна творба, която олицетворява сила, достойнство и вътрешна красота. Изпълнена с акрилни бои върху платно с помощта на четка и шпакли, картината съчетава текстура и емоция в изискана композиция. С размери 40х50 см и рамка с дебелина 2 см, „Кралица“ е истинско бижу за всеки интериор с характер.",
                Author = "Яна Христова",
                Width = 40,
                Height = 50,
                Price = 240.00m,
                CreatedOn = new DateTime(2024, 4, 5),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 14,
                ImageUrls = new List<string>
                {
                    "mig-product-14-1.jpg",
                    "mig-product-14-2.jpg",
                    "mig-product-14-3.jpg",
                    "mig-product-14-4.jpg",
                    "mig-product-14-5.jpg"
                },
                Name = "Миг",
                Description = "„Миг“ е експресивна картина, уловила състоянието на внезапно вдъхновение. Създадена с акрилни бои върху платно с помощта на четка и шпакла, творбата впечатлява с драматична текстура и силно излъчване. С размер 50х60 см и рамка с дебелина 2 см, тя е идеален избор за модерен интериор, който търси изкуство със заряд.",
                Author = "Камен Велев",
                Width = 60,
                Height = 50,
                Price = 260.00m,
                CreatedOn = new DateTime(2024, 4, 5),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 15,
                ImageUrls = new List<string>
                {
                    "angeli-product-15-1.jpg",
                    "angeli-product-15-2.jpg",
                    "angeli-product-15-3.jpg",
                    "angeli-product-15-4.jpg",
                    "angeli-product-15-5.jpg"
                },
                Name = "Ангели",
                Description = "„Ангели“ е изтънчена композиция от четири миниатюрни платна, съчетаваща финес, духовност и текстура. Всяко от платната е с размер 10х10 см и е изрисувано с акрилни бои, с помощта на четка и шпакла. Композицията е обогатена със златно фолио и моделираща паста, които придават блясък и обем. Рамкирана с 2-сантиметрова рамка, „Ангели“ е съвършен акцент за изискан и светъл интериор.",
                Author = "Росица Минчева",
                Width = 40, 
                Height = 10,
                Price = 200.00m,
                CreatedOn = new DateTime(2024, 4, 7),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 16,
                ImageUrls = new List<string>
                {
                    "zelen-angel-product-16-1.jpg",
                    "zelen-angel-product-16-2.jpg",
                    "zelen-angel-product-16-3.jpg",
                    "zelen-angel-product-16-4.jpg",
                    "zelen-angel-product-16-5.jpg"
                },
                Name = "Зелен ангел",
                Description = "„Зелен ангел“ е фина и изразителна миниатюра, излъчваща мекота и светлина. Нарисувана с акрилни бои върху платно с размер 10х10 см, тя е създадена с четка и шпакла, а златното фолио и моделиращата паста ѝ придават блясък и дълбочина. Завършена с елегантна 2-сантиметрова рамка, тази творба е истинско бижу за всяко пространство.",
                Author = "Росица Минчева",
                Width = 10,
                Height = 10,
                Price = 95.00m,
                CreatedOn = new DateTime(2024, 4, 8),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 17,
                ImageUrls = new List<string>
                {
                    "kosmopolitna-zhena-product-17-1.jpg",
                    "kosmopolitna-zhena-product-17-2.jpg",
                    "kosmopolitna-zhena-product-17-3.jpg"
                },
                Name = "Космополитна жена 3",
                Description = "„Космополитна жена 3“ е модерна миниатюра, която съчетава елегантност, индивидуалност и градски дух. Нарисувана с акрилни бои върху платно с размер 12х18 см, творбата използва четка и шпакла, за да изрази силен характер чрез текстура и детайл. Завършена с изискана рамка с дебелина 2 см, тази картина е идеален акцент за съвременен интериор с настроение.",
                Author = "Маргарита Алексиева",
                Width = 12,
                Height = 18,
                Price = 130.00m,
                CreatedOn = new DateTime(2024, 4, 9),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 18,
                ImageUrls = new List<string>
                {
                    "pristan-product-18-1.jpg",
                    "pristan-product-18-2.jpg",
                    "pristan-product-18-3.jpg",
                    "pristan-product-18-4.jpg",
                    "pristan-product-18-5.jpg"
                },
                Name = "Пристан",
                Description = "„Пристан“ е топла и емоционална картина, която символизира мястото, където човек намира покой. Нарисувана с акрилни бои върху платно с размер 20х30 см, използвайки четка, шпакла и моделираща паста, творбата впечатлява с релеф и дълбочина. Завършена с рамка с дебелина 2 см, „Пристан“ е идеално допълнение към интериор, търсещ уют и естетика.",
                Author = "Теодора Златева",
                Width = 30,
                Height = 20,
                Price = 165.00m,
                CreatedOn = new DateTime(2024, 4, 10),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 19,
                ImageUrls = new List<string>
                {
                    "cvetna-magiya-product-19-1.jpg",
                    "cvetna-magiya-product-19-2.jpg",
                    "cvetna-magiya-product-19-3.jpg",
                    "cvetna-magiya-product-19-4.jpg",
                    "cvetna-magiya-product-19-5.jpg"
                },
                Name = "Цветна магия",
                Description = "„Цветна магия“ е динамична и вдъхновяваща картина, която омагьосва с палитра от ярки цветове и богата текстура. Нарисувана с акрилни бои върху платно с размер 30х30 см, с помощта на четка и шпакла, творбата излъчва енергия и настроение. Завършена с елегантна рамка с дебелина 2 см, тя е перфектен акцент за модерен интериор с артистичен дух.",
                Author = "Виктория Йорданова",
                Width = 30,
                Height = 30,
                Price = 175.00m,
                CreatedOn = new DateTime(2024, 4, 11),
                IsDeleted = false
            },
            new Product
            {
                ProductId = 20,
                ImageUrls = new List<string>
                {
                    "cvetya-product-20-1.jpg",
                    "cvetya-product-20-2.jpg",
                    "cvetya-product-20-3.jpg",
                    "cvetya-product-20-4.jpg",
                    "cvetya-product-20-5.jpg",
                    "cvetya-product-20-6.jpg",
                },
                Name = "Цветя–1",
                Description = "„Цветя“–1 е нежна и жизнена картина, която улавя елегантната красота на природата в пълен разцвет. Изрисувана с акрилни бои върху платно с помощта на четка, творбата се отличава с мекота и хармония. Размерът ѝ е 30х40 см, а рамката с дебелина 2 см придава завършеност и стил. Подходяща е за всеки дом, който търси свежест и топлота в интериора си.",
                Author = "Силвия Христова",
                Width = 40,
                Height = 30,
                Price = 185.00m,
                CreatedOn = new DateTime(2024, 4, 12),
                IsDeleted = false
            }
        );

        builder.Entity<ProductGenre>().HasData(
            new ProductGenre { ProductId = 1, GenreId = 1 },

            new ProductGenre { ProductId = 2, GenreId = 4 },

            new ProductGenre { ProductId = 3, GenreId = 1 },
            
            new ProductGenre { ProductId = 4, GenreId = 5 },
            
            new ProductGenre { ProductId = 5, GenreId = 2 },
            
            new ProductGenre { ProductId = 6, GenreId = 3 },
            
            new ProductGenre { ProductId = 7, GenreId = 2 },
            
            new ProductGenre { ProductId = 8, GenreId = 9 },   
            new ProductGenre { ProductId = 9, GenreId = 2 },   
            new ProductGenre { ProductId = 10, GenreId = 9 },  
            new ProductGenre { ProductId = 11, GenreId = 9 },  
            new ProductGenre { ProductId = 12, GenreId = 9 },  
            new ProductGenre { ProductId = 13, GenreId = 9 },  
            new ProductGenre { ProductId = 14, GenreId = 1 },  
            new ProductGenre { ProductId = 15, GenreId = 5 },  
            new ProductGenre { ProductId = 16, GenreId = 5 },  
            new ProductGenre { ProductId = 17, GenreId = 1 },  
            new ProductGenre { ProductId = 18, GenreId = 2 },  
            new ProductGenre { ProductId = 19, GenreId = 9 },  
            new ProductGenre { ProductId = 20, GenreId = 3 } 
        );
        
        builder.Entity<ProductDrawingTechnique>().HasData(
            new ProductDrawingTechnique { ProductId = 1, DrawingTechniqueId = 2 },

            new ProductDrawingTechnique { ProductId = 2, DrawingTechniqueId = 3 },

            new ProductDrawingTechnique { ProductId = 3, DrawingTechniqueId = 1 },
            
            new ProductDrawingTechnique { ProductId = 4, DrawingTechniqueId = 2 },
            
            new ProductDrawingTechnique { ProductId = 5, DrawingTechniqueId = 1 },
            
            new ProductDrawingTechnique { ProductId = 6, DrawingTechniqueId = 5 },
            
            new ProductDrawingTechnique { ProductId = 7, DrawingTechniqueId = 2 },
            
            new ProductDrawingTechnique { ProductId = 8, DrawingTechniqueId = 7 },   
            new ProductDrawingTechnique { ProductId = 9, DrawingTechniqueId = 7 },   
            new ProductDrawingTechnique { ProductId = 10, DrawingTechniqueId = 7 },  
            new ProductDrawingTechnique { ProductId = 11, DrawingTechniqueId = 7 },  
            new ProductDrawingTechnique { ProductId = 12, DrawingTechniqueId = 7 }, 
            new ProductDrawingTechnique { ProductId = 13, DrawingTechniqueId = 7 },  
            new ProductDrawingTechnique { ProductId = 14, DrawingTechniqueId = 7 },  
            new ProductDrawingTechnique { ProductId = 15, DrawingTechniqueId = 7 },  
            new ProductDrawingTechnique { ProductId = 16, DrawingTechniqueId = 7 },  
            new ProductDrawingTechnique { ProductId = 17, DrawingTechniqueId = 7 },  
            new ProductDrawingTechnique { ProductId = 18, DrawingTechniqueId = 7 },  
            new ProductDrawingTechnique { ProductId = 19, DrawingTechniqueId = 7 },  
            new ProductDrawingTechnique { ProductId = 20, DrawingTechniqueId = 7 }
        );
    }
}