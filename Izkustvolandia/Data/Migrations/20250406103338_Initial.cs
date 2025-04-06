using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Izkustvolandia.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingTechniques",
                columns: table => new
                {
                    DrawingTechniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingTechniques", x => x.DrawingTechniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateOnly>(type: "date", nullable: false),
                    DeliveryOn = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.ProductId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDrawingTechniques",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DrawingTechniqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDrawingTechniques", x => new { x.DrawingTechniqueId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductDrawingTechniques_DrawingTechniques_DrawingTechniqueId",
                        column: x => x.DrawingTechniqueId,
                        principalTable: "DrawingTechniques",
                        principalColumn: "DrawingTechniqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDrawingTechniques_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductGenres",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGenres", x => new { x.GenreId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductGenres_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.OrderProductId);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f2b469c-8e1d-4719-b0e8-1af005ed9060", "6f2b469c-8e1d-4719-b0e8-1af005ed9060", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3b1cd17c-d186-4a74-86be-571a9fe256cd", 0, "374f198d-7939-45c1-b393-938b24a8d57d", "user@izkustvolandia.com", true, "Иван", "Георгиев", false, null, "USER@IZKUSTVOLANDIA.COM", "USER@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEGZbYMo0hbY+38u1+vMUd2kK8f6NYGfOwfxun3s9jLlCjLYmKSHraSd2gos6+Xwokg==", null, false, "fc4574b8-f5e4-40a8-bb0e-33e287922b80", false, "user@izkustvolandia.com" },
                    { "d1cca5f3-7195-4ba7-bcb9-c682e1f3d9c6", 0, "fa03ea15-377a-459b-8612-e9e478856d5d", "admin@izkustvolandia.com", true, "Иван", "Иванов", false, null, "ADMIN@IZKUSTVOLANDIA.COM", "ADMIN@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEDgamrUJQ3rRKu5OrD679t5rjdlaSGpCIbcryqYQS9nniZ/c5tHu9XkLnTfvXIbnhw==", null, false, "17fb03ec-25ee-4ef3-adaf-cfd6da561e2c", false, "admin@izkustvolandia.com" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTechniques",
                columns: new[] { "DrawingTechniqueId", "Name" },
                values: new object[,]
                {
                    { 1, "Маслени бои" },
                    { 2, "Акварел" },
                    { 3, "Темпера" },
                    { 4, "Графика" },
                    { 5, "Поантилизъм" },
                    { 6, "Фреска" },
                    { 7, "Гуаш" },
                    { 8, "Пастел" },
                    { 9, "Дигитална живопис" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Портрет" },
                    { 2, "Пейзаж" },
                    { 3, "Натюрморт" },
                    { 4, "Историческа живопис" },
                    { 5, "Религиозно изкуство" },
                    { 6, "Жанрова живопис" },
                    { 7, "Анималистика" },
                    { 8, "Сюрреализъм" },
                    { 9, "Абстрактно изкуство" },
                    { 10, "Кубизъм" },
                    { 11, "Импресионизъм" },
                    { 12, "Неоимпресионизъм" },
                    { 13, "Поп арт" },
                    { 14, "Миниатюра" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Author", "CreatedOn", "Description", "Height", "ImageUrls", "IsDeleted", "Name", "Price", "Width" },
                values: new object[,]
                {
                    { 1, "Анна Петрова", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Размер на платното 15х20 см. Продава се с рамка с дебелина 1 см. Нарисувана с акрилни бои върху платно с четка.", 20.0, "[\"mother-product-2-1.jpg\",\"mother-product-2-2.jpg\",\"mother-product-2-3.jpg\",\"mother-product-2-4.jpg\",\"mother-product-2-5.jpg\",\"mother-product-2-6.jpg\",\"mother-product-2-7.jpg\"]", false, "Майчина милувка 3", 120.00m, 15.0 },
                    { 2, "Анна Петрова", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Майчина милувка“ 5 е емоционална и изразителна картина, нарисувана с акрилни бои върху платно с помощта на четка и шпакли. Комбинацията от деликатни мазки и богата текстура придава дълбочина и характер на всяка линия. Платното е с размер 18х24 см и се предлага с елегантна рамка с дебелина 2 см, която допълва усещането за завършеност и уют.", 24.0, "[\"mother-product-1-1.jpg\",\"mother-product-1-2.jpg\",\"mother-product-1-3.jpg\",\"mother-product-1-4.jpg\"]", false, "Майчина милувка 5", 160.00m, 18.0 },
                    { 3, "Мария Николова", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Една“ 1 е елегантна творба, носеща усещане за нежност и самота. Създадена с акрилни бои върху платно, картината съчетава фини четкови мазки и текстури, постигнати с помощта на шпакли. Размерът ѝ е 15х20 см, а рамката с дебелина 1 см придава завършен и стилен вид.", 20.0, "[\"one-1-product-4-1.jpg\",\"one-1-product-4-2.jpg\",\"one-1-product-4-3.jpg\",\"one-1-product-4-4.jpg\",\"one-1-product-4-5.jpg\",\"one-1-product-4-6.jpg\",\"one-1-product-4-7.jpg\"]", false, "Една 1", 110.00m, 15.0 },
                    { 4, "Никол Симеонова", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Една“ е картина, която разказва история чрез усещане и текстура. Създадена с акрилни бои върху платно, комбинира изразителни четкови мазки и грубата чувственост на шпаклата. Композицията е с размер 15х20 см и е обрамчена с деликатна 1-сантиметрова рамка, която подчертава емоционалната ѝ наситеност.", 20.0, "[\"one-product-3-1.jpg\",\"one-product-3-2.jpg\",\"one-product-3-3.jpg\",\"one-product-3-4.jpg\",\"one-product-3-5.jpg\",\"one-product-3-6.jpg\"]", false, "Една", 105.00m, 15.0 },
                    { 5, "Елеонора Костова", new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Ти и аз“ 6 е нежна и хармонична картина, изразяваща силата на връзката между две души. Нарисувана с акрилни бои върху платно, използвайки фини четки, тя създава усещане за близост и топлина. Композицията е с квадратна форма – 20х20 см – и се предлага с елегантна рамка с дебелина 2 см, която допълва усещането за завършеност.", 20.0, "[\"you-and-me-product-5-1.jpg\",\"you-and-me-product-5-2.jpg\",\"you-and-me-product-5-3.jpg\",\"you-and-me-product-5-4.jpg\",\"you-and-me-product-5-5.jpg\",\"you-and-me-product-5-6.jpg\"]", false, "Ти и аз 6", 135.00m, 20.0 },
                    { 6, "Стефан Велинов", new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Релакс“ 2 е съвременна композиция, която улавя спокойствието на един миг на уединение. Картината е изпълнена с акрилни бои върху платно, използвайки изразителни движения на шпаклата, което ѝ придава характер и дълбочина. С размер 20х25 см и стилна рамка с дебелина 2 см, творбата е подходящ акцент за всеки уютен интериор.", 25.0, "[\"relax-product-6-1.jpg\",\"relax-product-6-2.jpg\",\"relax-product-6-3.jpg\",\"relax-product-6-4.jpg\",\"relax-product-6-5.jpg\",\"relax-product-6-6.jpg\"]", false, "Релакс 2", 145.00m, 20.0 },
                    { 7, "Валери Димитров", new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "„В гората“ 2 е живописен пейзаж, който пренася зрителя в сърцето на природата. Нарисувана с акрилни бои върху платно с помощта на четка и шпакли, картината комбинира фини детайли с богата текстура, за да улови магията на горската тишина. С размер 30х40 см и елегантна рамка с дебелина 2 см, творбата е идеален избор за любителите на природата и уюта.", 40.0, "[\"in-the-forest-product-7-1.jpg\",\"in-the-forest-product-7-2.jpg\",\"in-the-forest-product-7-3.jpg\",\"in-the-forest-product-7-4.jpg\",\"in-the-forest-product-7-5.jpg\",\"in-the-forest-product-7-6.jpg\"]", false, "В гората 2", 180.00m, 30.0 },
                    { 8, "Калина Стоянова", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Радост“ е експресивна композиция от три отделни платна, обединени от цветна енергия и усещане за позитивност. Всяко платно е с размер 20х20 см, изрисувано с акрилни бои, използвайки четка и шпакли. Богатата текстура и живите цветове създават чувство на движение и хармония. Композицията е монтирана върху дървена подрамка с дебелина 2 см и е идеален избор за модерния интериор.", 20.0, "[\"radost-product-8-1.jpg\",\"radost-product-8-2.jpg\",\"radost-product-8-3.jpg\"]", false, "Радост", 210.00m, 60.0 },
                    { 9, "Радостина Тодорова", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Идилия“ е спокойна и вдъхновяваща творба, която пресъздава усещането за хармония и уют. Нарисувана с акрилни бои върху платно с размери 40х30 см, тя съчетава топли тонове и плавни преходи, за да създаде чувство на уравновесеност и съзерцание. Идеален избор за всеки, който търси изкуство с успокояващо присъствие.", 30.0, "[\"idiliya-product-9-1.jpg\",\"idiliya-product-9-2.jpg\",\"idiliya-product-9-3.jpg\",\"idiliya-product-9-4.jpg\",\"idiliya-product-9-5.jpg\"]", false, "Идилия", 190.00m, 40.0 },
                    { 10, "Елица Ангелова", new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Тишина“ е дълбоко емоционална картина, която улавя усещането за вътрешен мир и съзерцание. Създадена с акрилни бои върху платно, използвайки подрамка, четка и шпакла, творбата съчетава текстура и плавни преходи, които приканват зрителя към спокойствие. Размерите ѝ са 40х30 см, а рамката с дебелина 2 см подчертава нейното естетическо въздействие.", 30.0, "[\"tishina-product-10-1.jpg\",\"tishina-product-10-2.jpg\",\"tishina-product-10-3.jpg\"]", false, "Тишина", 195.00m, 40.0 },
                    { 11, "Александър Стефанов", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Надпревара“ е впечатляваща двукомпонентна композиция, излъчваща движение, енергия и контраст. Изпълнена с акрилни бои върху две платна с подрамка, творбата използва четка и шпакла, за да изгради богата текстура и визуален ритъм. Всяко платно е с размер 50х100 см, а рамките с дебелина 2 см придават завършеност и стил. „Надпревара“ е идеален акцент за модерен интериор с характер.", 50.0, "[\"nadprevara-product-11-1.jpg\",\"nadprevara-product-11-2.jpg\",\"nadprevara-product-11-3.jpg\",\"nadprevara-product-11-4.jpg\",\"nadprevara-product-11-5.jpg\"]", false, "Надпревара", 360.00m, 100.0 },
                    { 12, "Ирина Михайлова", new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Мелодия“ е нежна триптих-композиция, която визуализира ритъма на емоциите чрез цвят и форма. Изградена от три платна с размер 20х20 см всяко, картината е нарисувана с акрилни бои, използвайки четка и шпакла за постигане на динамична текстура. Дървената подрамка с дебелина 2 см придава на композицията завършен вид, който е едновременно модерен и изразителен.", 20.0, "[\"melodiya-product-12-1.jpg\",\"melodiya-product-12-2.jpg\",\"melodiya-product-12-3.jpg\",\"melodiya-product-12-4.jpg\",\"melodiya-product-12-5.jpg\"]", false, "Мелодия", 225.00m, 60.0 },
                    { 13, "Яна Христова", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Кралица“ е внушителна и изразителна творба, която олицетворява сила, достойнство и вътрешна красота. Изпълнена с акрилни бои върху платно с помощта на четка и шпакли, картината съчетава текстура и емоция в изискана композиция. С размери 40х50 см и рамка с дебелина 2 см, „Кралица“ е истинско бижу за всеки интериор с характер.", 50.0, "[\"kralitsa-product-13-1.jpg\",\"kralitsa-product-13-2.jpg\",\"kralitsa-product-13-3.jpg\",\"kralitsa-product-13-4.jpg\"]", false, "Кралица", 240.00m, 40.0 },
                    { 14, "Камен Велев", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Миг“ е експресивна картина, уловила състоянието на внезапно вдъхновение. Създадена с акрилни бои върху платно с помощта на четка и шпакла, творбата впечатлява с драматична текстура и силно излъчване. С размер 50х60 см и рамка с дебелина 2 см, тя е идеален избор за модерен интериор, който търси изкуство със заряд.", 50.0, "[\"mig-product-14-1.jpg\",\"mig-product-14-2.jpg\",\"mig-product-14-3.jpg\",\"mig-product-14-4.jpg\",\"mig-product-14-5.jpg\"]", false, "Миг", 260.00m, 60.0 },
                    { 15, "Росица Минчева", new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Ангели“ е изтънчена композиция от четири миниатюрни платна, съчетаваща финес, духовност и текстура. Всяко от платната е с размер 10х10 см и е изрисувано с акрилни бои, с помощта на четка и шпакла. Композицията е обогатена със златно фолио и моделираща паста, които придават блясък и обем. Рамкирана с 2-сантиметрова рамка, „Ангели“ е съвършен акцент за изискан и светъл интериор.", 10.0, "[\"angeli-product-15-1.jpg\",\"angeli-product-15-2.jpg\",\"angeli-product-15-3.jpg\",\"angeli-product-15-4.jpg\",\"angeli-product-15-5.jpg\"]", false, "Ангели", 200.00m, 40.0 },
                    { 16, "Росица Минчева", new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Зелен ангел“ е фина и изразителна миниатюра, излъчваща мекота и светлина. Нарисувана с акрилни бои върху платно с размер 10х10 см, тя е създадена с четка и шпакла, а златното фолио и моделиращата паста ѝ придават блясък и дълбочина. Завършена с елегантна 2-сантиметрова рамка, тази творба е истинско бижу за всяко пространство.", 10.0, "[\"zelen-angel-product-16-1.jpg\",\"zelen-angel-product-16-2.jpg\",\"zelen-angel-product-16-3.jpg\",\"zelen-angel-product-16-4.jpg\",\"zelen-angel-product-16-5.jpg\"]", false, "Зелен ангел", 95.00m, 10.0 },
                    { 17, "Маргарита Алексиева", new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Космополитна жена 3“ е модерна миниатюра, която съчетава елегантност, индивидуалност и градски дух. Нарисувана с акрилни бои върху платно с размер 12х18 см, творбата използва четка и шпакла, за да изрази силен характер чрез текстура и детайл. Завършена с изискана рамка с дебелина 2 см, тази картина е идеален акцент за съвременен интериор с настроение.", 18.0, "[\"kosmopolitna-zhena-product-17-1.jpg\",\"kosmopolitna-zhena-product-17-2.jpg\",\"kosmopolitna-zhena-product-17-3.jpg\"]", false, "Космополитна жена 3", 130.00m, 12.0 },
                    { 18, "Теодора Златева", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Пристан“ е топла и емоционална картина, която символизира мястото, където човек намира покой. Нарисувана с акрилни бои върху платно с размер 20х30 см, използвайки четка, шпакла и моделираща паста, творбата впечатлява с релеф и дълбочина. Завършена с рамка с дебелина 2 см, „Пристан“ е идеално допълнение към интериор, търсещ уют и естетика.", 20.0, "[\"pristan-product-18-1.jpg\",\"pristan-product-18-2.jpg\",\"pristan-product-18-3.jpg\",\"pristan-product-18-4.jpg\",\"pristan-product-18-5.jpg\"]", false, "Пристан", 165.00m, 30.0 },
                    { 19, "Виктория Йорданова", new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Цветна магия“ е динамична и вдъхновяваща картина, която омагьосва с палитра от ярки цветове и богата текстура. Нарисувана с акрилни бои върху платно с размер 30х30 см, с помощта на четка и шпакла, творбата излъчва енергия и настроение. Завършена с елегантна рамка с дебелина 2 см, тя е перфектен акцент за модерен интериор с артистичен дух.", 30.0, "[\"cvetna-magiya-product-19-1.jpg\",\"cvetna-magiya-product-19-2.jpg\",\"cvetna-magiya-product-19-3.jpg\",\"cvetna-magiya-product-19-4.jpg\",\"cvetna-magiya-product-19-5.jpg\"]", false, "Цветна магия", 175.00m, 30.0 },
                    { 20, "Силвия Христова", new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Цветя“–1 е нежна и жизнена картина, която улавя елегантната красота на природата в пълен разцвет. Изрисувана с акрилни бои върху платно с помощта на четка, творбата се отличава с мекота и хармония. Размерът ѝ е 30х40 см, а рамката с дебелина 2 см придава завършеност и стил. Подходяща е за всеки дом, който търси свежест и топлота в интериора си.", 30.0, "[\"cvetya-product-20-1.jpg\",\"cvetya-product-20-2.jpg\",\"cvetya-product-20-3.jpg\",\"cvetya-product-20-4.jpg\",\"cvetya-product-20-5.jpg\",\"cvetya-product-20-6.jpg\"]", false, "Цветя–1", 185.00m, 40.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6f2b469c-8e1d-4719-b0e8-1af005ed9060", "d1cca5f3-7195-4ba7-bcb9-c682e1f3d9c6" });

            migrationBuilder.InsertData(
                table: "ProductDrawingTechniques",
                columns: new[] { "DrawingTechniqueId", "ProductId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 4 },
                    { 2, 7 },
                    { 3, 2 },
                    { 5, 6 },
                    { 7, 8 },
                    { 7, 9 },
                    { 7, 10 },
                    { 7, 11 },
                    { 7, 12 },
                    { 7, 13 },
                    { 7, 14 },
                    { 7, 15 },
                    { 7, 16 },
                    { 7, 17 },
                    { 7, 18 },
                    { 7, 19 },
                    { 7, 20 }
                });

            migrationBuilder.InsertData(
                table: "ProductGenres",
                columns: new[] { "GenreId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 14 },
                    { 1, 17 },
                    { 2, 5 },
                    { 2, 7 },
                    { 2, 9 },
                    { 2, 18 },
                    { 3, 6 },
                    { 3, 20 },
                    { 4, 2 },
                    { 5, 4 },
                    { 5, 15 },
                    { 5, 16 },
                    { 9, 8 },
                    { 9, 10 },
                    { 9, 11 },
                    { 9, 12 },
                    { 9, 13 },
                    { 9, 19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDrawingTechniques_ProductId",
                table: "ProductDrawingTechniques",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGenres_ProductId",
                table: "ProductGenres",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "ProductDrawingTechniques");

            migrationBuilder.DropTable(
                name: "ProductGenres");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DrawingTechniques");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
