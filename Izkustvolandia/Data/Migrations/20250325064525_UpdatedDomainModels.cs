using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Izkustvolandia.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDomainModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55cba290-9862-49e8-aa29-194a3b72de77");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f4fd4648-f027-4b4d-8f5a-4b7219ac5a51");

            migrationBuilder.CreateTable(
                name: "ProductUser",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUser", x => new { x.ProductsProductId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProductUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUser_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32bad706-1877-40de-81e2-9064f5410346", "32bad706-1877-40de-81e2-9064f5410346", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5546350e-123c-4378-887a-f89a751969ef", 0, "1fb78f16-70b8-4f49-b4f5-3aa4d1c689e3", "User", "admin@izkustvolandia.com", true, "Иван", "Иванов", false, null, "ADMIN@IZKUSTVOLANDIA.COM", "ADMIN", "AQAAAAIAAYagAAAAEIshEIK1ONTK2ruES/9y4aXySVI69WSZ4/75oPfdfl4a7DNc/M+QHCgOjQ5c7eP7nA==", null, false, "f666cf38-3951-4f86-a201-43c818feccf3", false, "admin" },
                    { "b36af3bb-4cbf-4bd1-9a5d-9d64cf315661", 0, "63ab2f82-370d-40fa-b744-177072b877e3", "User", "user@izkustvolandia.com", true, "Иван", "Георгиев", false, null, "USER@IZKUSTVOLANDIA.COM", "USER", "AQAAAAIAAYagAAAAEBFVdTbPF4kk62snMPxA+/QsmqZdA1646TBmAD92L3R2uuQ4LsLOKCOc38c1qEhOvQ==", null, false, "f528625c-2b51-4337-82da-40d6fc246632", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "32bad706-1877-40de-81e2-9064f5410346", "5546350e-123c-4378-887a-f89a751969ef" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductUser_UsersId",
                table: "ProductUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductUser");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "32bad706-1877-40de-81e2-9064f5410346", "5546350e-123c-4378-887a-f89a751969ef" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b36af3bb-4cbf-4bd1-9a5d-9d64cf315661");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32bad706-1877-40de-81e2-9064f5410346");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5546350e-123c-4378-887a-f89a751969ef");

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "55cba290-9862-49e8-aa29-194a3b72de77", "f4fd4648-f027-4b4d-8f5a-4b7219ac5a51" });
        }
    }
}
