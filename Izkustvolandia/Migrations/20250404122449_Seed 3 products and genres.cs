using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Izkustvolandia.Migrations
{
    /// <inheritdoc />
    public partial class Seed3productsandgenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "ProductDrawingTechniques",
                columns: new[] { "DrawingTechniqueId", "ProductId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 7 },
                    { 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "ProductGenres",
                columns: new[] { "GenreId", "ProductId" },
                values: new object[,]
                {
                    { 2, 5 },
                    { 2, 7 },
                    { 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d5d9b0e7-b993-4742-a5dc-ab01f60da77d", "7ef5b586-3242-4639-ab16-4dba46c799c9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ProductDrawingTechniques",
                keyColumns: new[] { "DrawingTechniqueId", "ProductId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ProductGenres",
                keyColumns: new[] { "GenreId", "ProductId" },
                keyValues: new object[] { 3, 6 });

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "94f56cc5-45eb-423a-86bc-487a697ae173", "7f3df201-e2bb-4e04-adfe-850e5e90e516" });
        }
    }
}
