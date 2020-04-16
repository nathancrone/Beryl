using Microsoft.EntityFrameworkCore.Migrations;

namespace Beryl.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Redirects",
                schema: "dbo",
                columns: table => new
                {
                    RedirectId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redirects", x => x.RedirectId);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Redirects",
                columns: new[] { "RedirectId", "Url" },
                values: new object[] { 1, "http://www.google.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Redirects",
                columns: new[] { "RedirectId", "Url" },
                values: new object[] { 2, "http://www.amazon.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Redirects",
                schema: "dbo");
        }
    }
}
