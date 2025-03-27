using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Izkustvolandia.Data.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c746d689-e53c-4a2b-86b5-3dbf740e78e1", "c746d689-e53c-4a2b-86b5-3dbf740e78e1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "50bd6775-85d1-4947-9bd8-359a4b4293ef", 0, "a56b6655-817e-47da-acd3-f053acda7ba0", "admin@izkustvolandia.com", true, "Иван", "Иванов", false, null, "ADMIN@IZKUSTVOLANDIA.COM", "ADMIN@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAENsGOeCxp4rMyJqopVTPEc42VJN8gJnvQ2hSDeZ6EEp7zULUDru0HKdJ88vMvWBLOw==", null, false, "96aa3ccb-128f-49af-81b8-1c2f8e6b3b74", false, "admin@izkustvolandia.com" },
                    { "e5814873-b2fb-4cfd-bce5-49982d64eadc", 0, "992b2384-10dc-4039-9fd0-528cabf2d1f8", "user@izkustvolandia.com", true, "Иван", "Георгиев", false, null, "USER@IZKUSTVOLANDIA.COM", "USER@IZKUSTVOLANDIA.COM", "AQAAAAIAAYagAAAAEESRWCXYspOSsrcEwI+OBag1v4TXTmKptUbudJuuG4h6AM1w5tIWWdEQQjjZfrFGCA==", null, false, "8b22cb7c-4fd9-4b2e-89cf-4b59e509d4d1", false, "user@izkustvolandia.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c746d689-e53c-4a2b-86b5-3dbf740e78e1", "50bd6775-85d1-4947-9bd8-359a4b4293ef" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c746d689-e53c-4a2b-86b5-3dbf740e78e1", "50bd6775-85d1-4947-9bd8-359a4b4293ef" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5814873-b2fb-4cfd-bce5-49982d64eadc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c746d689-e53c-4a2b-86b5-3dbf740e78e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "50bd6775-85d1-4947-9bd8-359a4b4293ef");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

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
        }
    }
}
