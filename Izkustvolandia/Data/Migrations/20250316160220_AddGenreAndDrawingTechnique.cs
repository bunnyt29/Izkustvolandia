using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Izkustvolandia.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGenreAndDrawingTechnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dbae7401-5c00-4ab9-9e3e-7eda5ccc71d2", "22c680fb-3f08-47b1-9d09-2462d9e931a9" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3402b8c-7ca4-4b7d-83ca-4e86ae6c51b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbae7401-5c00-4ab9-9e3e-7eda5ccc71d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22c680fb-3f08-47b1-9d09-2462d9e931a9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55cba290-9862-49e8-aa29-194a3b72de77", "55cba290-9862-49e8-aa29-194a3b72de77", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "dd25c531-a9ae-4419-87c6-b1de3d202677", 0, "6775ba70-f430-4d06-876b-063f7018020e", "User", "user@izkustvolandia.com", true, "Иван", "Георгиев", false, null, "USER@IZKUSTVOLANDIA.COM", "USER", "AQAAAAIAAYagAAAAECK6a/EQXmGzv54b7Fp4nPdW2S8YIpyYlbS8l0YsYLiLuI7DmxTfaeUXXnl24JlFbA==", null, false, "00df0834-6591-4f65-b2d7-1ecf4174f9f7", false, "user" },
                    { "f4fd4648-f027-4b4d-8f5a-4b7219ac5a51", 0, "f1f7e79b-2488-4b5d-afec-7f88212d1329", "User", "admin@izkustvolandia.com", true, "Иван", "Иванов", false, null, "ADMIN@IZKUSTVOLANDIA.COM", "ADMIN", "AQAAAAIAAYagAAAAEMXoyvBfXTml3/fO8h0BkwhJ+7OOOhYGTU5J8cQ3akcmFyOCw3e7zUw0Q43WeEWrDQ==", null, false, "bf9c3c82-0841-4826-9927-494674fb6df0", false, "admin" }
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "55cba290-9862-49e8-aa29-194a3b72de77", "f4fd4648-f027-4b4d-8f5a-4b7219ac5a51" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "55cba290-9862-49e8-aa29-194a3b72de77", "f4fd4648-f027-4b4d-8f5a-4b7219ac5a51" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dd25c531-a9ae-4419-87c6-b1de3d202677");

            migrationBuilder.DeleteData(
                table: "DrawingTechniques",
                keyColumn: "DrawingTechniqueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DrawingTechniques",
                keyColumn: "DrawingTechniqueId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DrawingTechniques",
                keyColumn: "DrawingTechniqueId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DrawingTechniques",
                keyColumn: "DrawingTechniqueId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DrawingTechniques",
                keyColumn: "DrawingTechniqueId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DrawingTechniques",
                keyColumn: "DrawingTechniqueId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DrawingTechniques",
                keyColumn: "DrawingTechniqueId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DrawingTechniques",
                keyColumn: "DrawingTechniqueId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DrawingTechniques",
                keyColumn: "DrawingTechniqueId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55cba290-9862-49e8-aa29-194a3b72de77");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f4fd4648-f027-4b4d-8f5a-4b7219ac5a51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dbae7401-5c00-4ab9-9e3e-7eda5ccc71d2", "dbae7401-5c00-4ab9-9e3e-7eda5ccc71d2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "22c680fb-3f08-47b1-9d09-2462d9e931a9", 0, "4645c415-b2de-41e0-9a06-5aa9f03bccd0", "User", "admin@izkustvolandia.com", true, "Иван", "Иванов", false, null, "ADMIN@IZKUSTVOLANDIA.COM", "ADMIN", "AQAAAAIAAYagAAAAEKBFDJwwCGYtW4pWt3pgJmzH0N/7PXyg2l45u3zvjFDoFcVlttYX5vnnlfIlqwLFMQ==", null, false, "21d5827a-5b6f-4647-a3b5-b1a353920f15", false, "admin" },
                    { "b3402b8c-7ca4-4b7d-83ca-4e86ae6c51b0", 0, "9b6021bb-7df7-48ac-925c-a577b0f11b65", "User", "user@izkustvolandia.com", true, "Иван", "Георгиев", false, null, "USER@IZKUSTVOLANDIA.COM", "USER", "AQAAAAIAAYagAAAAEA3eLWR85RsmgsVlUasKvfeuVTjI/uF6Urh5XzRcnDrxdq7Ei83II5rZXD+/QvCmjQ==", null, false, "ed1a3b6b-0386-48e0-b931-0c871abd69ff", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dbae7401-5c00-4ab9-9e3e-7eda5ccc71d2", "22c680fb-3f08-47b1-9d09-2462d9e931a9" });
        }
    }
}
