using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendClain.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clain",
                columns: table => new
                {
                    Dieta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreDieta = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", maxLength: 999999999, nullable: false),
                    Menu = table.Column<string>(type: "nvarchar(max)", maxLength: 999999999, nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clain", x => x.Dieta);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clain");
        }
    }
}
