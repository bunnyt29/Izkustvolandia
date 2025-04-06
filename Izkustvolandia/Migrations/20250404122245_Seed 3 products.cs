using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Izkustvolandia.Migrations
{
    /// <inheritdoc />
    public partial class Seed3products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c5648487-4ec0-4fde-8724-12688ff51672", "d32a0d85-831e-4d35-bbf2-c0329bd0f94c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "390c4603-9f7a-412b-8c86-316f484e3229");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5648487-4ec0-4fde-8724-12688ff51672");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d32a0d85-831e-4d35-bbf2-c0329bd0f94c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94f56cc5-45eb-423a-86bc-487a697ae173", "94f56cc5-45eb-423a-86bc-487a697ae173", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7f3df201-e2bb-4e04-adfe-850e5e90e516", 0, "aca7f32e-74b8-4b79-b8c1-381c20dfe410", "admin@izkustvolandia.com", true, "Иван", "Иванов", false, null, "ADMIN@IZKUSTVOLANDIA.COM", "ADMIN@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEF9jVs79xpq8M5GcG2uCeGxGcrqKcQ9gcdhVeuwGXFp36NXdCPOANhSWLIo+lQQDQQ==", null, false, "e5c5138f-9422-4b37-95ad-02fdede5a16a", false, "admin@izkustvolandia.com" },
                    { "a47104f0-5e37-4158-ab05-6c7e98a3ec94", 0, "aa84e89c-eb96-4266-9485-959ec3fbe488", "user@izkustvolandia.com", true, "Иван", "Георгиев", false, null, "USER@IZKUSTVOLANDIA.COM", "USER@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEJCb3k/XRiErwSmhYD+QUQi127M0frgLeEpeNiz5pLjZ6/l9IpY7OA4/+5kGLpywow==", null, false, "25f38192-6cbc-4f35-9c90-40ee9006a790", false, "user@izkustvolandia.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Author", "CreatedOn", "Description", "Height", "ImageUrls", "IsDeleted", "Name", "Price", "Width" },
                values: new object[,]
                {
                    { 5, "Елеонора Костова", new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Ти и аз“ 6 е нежна и хармонична картина, изразяваща силата на връзката между две души. Нарисувана с акрилни бои върху платно, използвайки фини четки, тя създава усещане за близост и топлина. Композицията е с квадратна форма – 20х20 см – и се предлага с елегантна рамка с дебелина 2 см, която допълва усещането за завършеност.", 20.0, "[\"you-and-me-product-5-1.jpg\",\"you-and-me-product-5-2.jpg\",\"you-and-me-product-5-3.jpg\",\"you-and-me-product-5-4.jpg\",\"you-and-me-product-5-5.jpg\",\"you-and-me-product-5-6.jpg\"]", false, "Ти и аз 6", 135.00m, 20.0 },
                    { 6, "Стефан Велинов", new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Релакс“ 2 е съвременна композиция, която улавя спокойствието на един миг на уединение. Картината е изпълнена с акрилни бои върху платно, използвайки изразителни движения на шпаклата, което ѝ придава характер и дълбочина. С размер 20х25 см и стилна рамка с дебелина 2 см, творбата е подходящ акцент за всеки уютен интериор.", 25.0, "[\"relax-product-6-1.jpg\",\"relax-product-6-2.jpg\",\"relax-product-6-3.jpg\",\"relax-product-6-4.jpg\",\"relax-product-6-5.jpg\",\"relax-product-6-6.jpg\"]", false, "Релакс 2", 145.00m, 20.0 },
                    { 7, "Валери Димитров", new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "„В гората“ 2 е живописен пейзаж, който пренася зрителя в сърцето на природата. Нарисувана с акрилни бои върху платно с помощта на четка и шпакли, картината комбинира фини детайли с богата текстура, за да улови магията на горската тишина. С размер 30х40 см и елегантна рамка с дебелина 2 см, творбата е идеален избор за любителите на природата и уюта.", 40.0, "[\"in-the-forest-product-7-1.jpg\",\"in-the-forest-product-7-2.jpg\",\"in-the-forest-product-7-3.jpg\",\"in-the-forest-product-7-4.jpg\",\"in-the-forest-product-7-5.jpg\",\"in-the-forest-product-7-6.jpg\"]", false, "В гората 2", 180.00m, 30.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "94f56cc5-45eb-423a-86bc-487a697ae173", "7f3df201-e2bb-4e04-adfe-850e5e90e516" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94f56cc5-45eb-423a-86bc-487a697ae173", "7f3df201-e2bb-4e04-adfe-850e5e90e516" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a47104f0-5e37-4158-ab05-6c7e98a3ec94");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94f56cc5-45eb-423a-86bc-487a697ae173");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f3df201-e2bb-4e04-adfe-850e5e90e516");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5648487-4ec0-4fde-8724-12688ff51672", "c5648487-4ec0-4fde-8724-12688ff51672", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "390c4603-9f7a-412b-8c86-316f484e3229", 0, "4970e0a6-5f33-4dc0-b1d8-4a363af72352", "user@izkustvolandia.com", true, "Иван", "Георгиев", false, null, "USER@IZKUSTVOLANDIA.COM", "USER@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEH/E7ttReF9kSlWtj0JacS0Eu4XrWnxhj3ZgMucLczF0MtGbHsjR5hSHMW7oZ90fZQ==", null, false, "63929e05-3d97-45d2-92c7-c4937317ead7", false, "user@izkustvolandia.com" },
                    { "d32a0d85-831e-4d35-bbf2-c0329bd0f94c", 0, "ea043563-56ab-4d12-a83d-ce9f14af20a1", "admin@izkustvolandia.com", true, "Иван", "Иванов", false, null, "ADMIN@IZKUSTVOLANDIA.COM", "ADMIN@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEO41pa0R8PbKZQXEs0/7EL71RnANAG50YR+zSULcbr5CTxr4ehlN5C45qDQlpC8ZBw==", null, false, "63766695-3d8e-4e9a-ab11-6ff36097b3f2", false, "admin@izkustvolandia.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c5648487-4ec0-4fde-8724-12688ff51672", "d32a0d85-831e-4d35-bbf2-c0329bd0f94c" });
        }
    }
}
