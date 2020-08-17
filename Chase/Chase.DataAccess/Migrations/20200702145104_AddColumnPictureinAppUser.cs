using Microsoft.EntityFrameworkCore.Migrations;

namespace Chase.DataAccess.Migrations
{
    public partial class AddColumnPictureinAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageProfile",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyAbout = table.Column<string>(nullable: true),
                    NumberOfEmployees = table.Column<string>(nullable: true),
                    Sector = table.Column<string>(nullable: true),
                    CompanyType = table.Column<string>(nullable: true),
                    EnterPrise = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.CompanyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropColumn(
                name: "ImageProfile",
                table: "AspNetUsers");
        }
    }
}
