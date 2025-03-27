using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Izkustvolandia.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff5ce3de-2e8c-4c6e-b696-0ba2630bea80", "ff5ce3de-2e8c-4c6e-b696-0ba2630bea80", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "03c04ede-9294-4454-8ad2-a3163373e944", 0, "e17a5ef3-3cbe-4887-91b7-cd3058aba214", "User", "admin@izkustvolandia.com", true, "Иван", "Иванов", false, null, "ADMIN@IZKUSTVOLANDIA.COM", "ADMIN", "AQAAAAIAAYagAAAAED7i/gjKEgHFrWskEAWMrY2n6EsKL2HhjYkZWER3zg3IMLBmrfIrozgOObXPtBCB5w==", null, false, "6893683e-3610-4031-9506-3dc51f6a5adf", false, "admin" },
                    { "5ff55d25-7e62-476a-b94f-2ea20d70d369", 0, "d074d5d7-056c-458d-bb0b-e8d00c6cb2a0", "User", "user@izkustvolandia.com", true, "Иван", "Георгиев", false, null, "USER@IZKUSTVOLANDIA.COM", "USER", "AQAAAAIAAYagAAAAENWCnwZJqH4rHM2/ukvDTHJxOXKroIQpgcDZF0WFfirWEnhqzj2pnxoHHk6CRqxNYg==", null, false, "9938d157-fbd9-4966-ab1e-6ab75af5945b", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ff5ce3de-2e8c-4c6e-b696-0ba2630bea80", "03c04ede-9294-4454-8ad2-a3163373e944" });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ff5ce3de-2e8c-4c6e-b696-0ba2630bea80", "03c04ede-9294-4454-8ad2-a3163373e944" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ff55d25-7e62-476a-b94f-2ea20d70d369");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff5ce3de-2e8c-4c6e-b696-0ba2630bea80");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03c04ede-9294-4454-8ad2-a3163373e944");

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
    }
}
