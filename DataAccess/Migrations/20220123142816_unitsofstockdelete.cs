using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class unitsofstockdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitsInStock",
                schema: "Movie",
                table: "Movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "UnitsInStock",
                schema: "Movie",
                table: "Movie",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
