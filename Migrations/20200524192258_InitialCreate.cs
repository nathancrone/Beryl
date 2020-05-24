using Microsoft.EntityFrameworkCore.Migrations;

namespace Beryl.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Redirects",
                columns: table => new
                {
                    RedirectId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redirects", x => x.RedirectId);
                });

            migrationBuilder.InsertData(
                table: "Redirects",
                columns: new[] { "RedirectId", "Description", "Url" },
                values: new object[] { 1, null, "http://www.google.com" });

            migrationBuilder.InsertData(
                table: "Redirects",
                columns: new[] { "RedirectId", "Description", "Url" },
                values: new object[] { 2, null, "http://www.amazon.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Redirects");
        }
    }
}
