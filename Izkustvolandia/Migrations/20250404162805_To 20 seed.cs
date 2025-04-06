using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Izkustvolandia.Migrations
{
    /// <inheritdoc />
    public partial class To20seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d5d9b0e7-b993-4742-a5dc-ab01f60da77d", "7ef5b586-3242-4639-ab16-4dba46c799c9" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b92e96f-67c1-42b3-bee9-30a3ca39270c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5d9b0e7-b993-4742-a5dc-ab01f60da77d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ef5b586-3242-4639-ab16-4dba46c799c9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36418dae-f5ae-4c6f-8c71-d228d2dc6353", "36418dae-f5ae-4c6f-8c71-d228d2dc6353", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "23cae1e2-ae4a-450f-ae5e-058567023c59", 0, "29e289f5-d934-4c9f-9c1c-f15a1bb3fe98", "user@izkustvolandia.com", true, "Иван", "Георгиев", false, null, "USER@IZKUSTVOLANDIA.COM", "USER@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEHjv753FmHyvuNsSnHoKeZwZ3XSsa2/yKqH6lpEmIqGO0mTi31r2E2HxODWoEBF7Bg==", null, false, "570114ab-ccce-4291-b697-3669e8926a54", false, "user@izkustvolandia.com" },
                    { "e7105a6b-13ae-45fd-bed1-404aa1121fe6", 0, "dcfae9c9-51a8-49b6-979b-fde03d089708", "admin@izkustvolandia.com", true, "Иван", "Иванов", false, null, "ADMIN@IZKUSTVOLANDIA.COM", "ADMIN@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEGKYag7yXvMRgYEwkIaAn3Fka16qgAu6UIJ2KkABIIle1L9tFjpxtyqCD2PA/1SwMQ==", null, false, "82b977b2-23ed-4507-aae8-8f7be88f3916", false, "admin@izkustvolandia.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Author", "CreatedOn", "Description", "Height", "ImageUrls", "IsDeleted", "Name", "Price", "Width" },
                values: new object[,]
                {
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
                values: new object[] { "36418dae-f5ae-4c6f-8c71-d228d2dc6353", "e7105a6b-13ae-45fd-bed1-404aa1121fe6" });

            migrationBuilder.InsertData(
                table: "ProductDrawingTechniques",
                columns: new[] { "DrawingTechniqueId", "ProductId" },
                values: new object[,]
                {
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
                    { 1, 14 },
                    { 1, 17 },
                    { 2, 9 },
                    { 2, 18 },
                    { 3, 20 },
                    { 5, 15 },
                    { 5, 16 },
                    { 9, 8 },
                    { 9, 10 },
                    { 9, 11 },
                    { 9, 12 },
                    { 9, 13 },
                    { 9, 19 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "36418dae-f5ae-4c6f-8c71-d228d2dc6353", "e7105a6b-13ae-45fd-bed1-404aa1121fe6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23cae1e2-ae4a-450f-ae5e-058567023c59");

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 12 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 13 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 14 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 15 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 16 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 17 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 18 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 19 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 7, 20 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 1, 17 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 3, 20 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 9, 11 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 9, 12 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 9, 19 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36418dae-f5ae-4c6f-8c71-d228d2dc6353");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7105a6b-13ae-45fd-bed1-404aa1121fe6");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5d9b0e7-b993-4742-a5dc-ab01f60da77d", "d5d9b0e7-b993-4742-a5dc-ab01f60da77d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3b92e96f-67c1-42b3-bee9-30a3ca39270c", 0, "2605a804-a0ba-443c-b53d-3fedcdd8e556", "user@izkustvolandia.com", true, "Иван", "Георгиев", false, null, "USER@IZKUSTVOLANDIA.COM", "USER@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEOE9yV4edi0djvWrSlEm32V4/eK65WyqerfQqDQ6k7jrceP2Xrv/tGYmogQNt8th0g==", null, false, "aeffc4d0-94a6-4cd4-8a67-ad2d28a5f6e3", false, "user@izkustvolandia.com" },
                    { "7ef5b586-3242-4639-ab16-4dba46c799c9", 0, "209a11f1-a708-4687-a3a2-065012cbbbfe", "admin@izkustvolandia.com", true, "Иван", "Иванов", false, null, "ADMIN@IZKUSTVOLANDIA.COM", "ADMIN@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEBoP411jTj82uSL5+kottt5AvK8TVmKWe/EmPcAcoeCcLmebZK09adqeuMk6gga45Q==", null, false, "1a83fd14-5e54-4499-a0d8-2bb7ba38b66c", false, "admin@izkustvolandia.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d5d9b0e7-b993-4742-a5dc-ab01f60da77d", "7ef5b586-3242-4639-ab16-4dba46c799c9" });
        }
    }
}
