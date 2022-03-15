using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_management_Api.Data.Migrations
{
    public partial class booking2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RoomType",
                newName: "RoomTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomTypeName",
                table: "RoomType",
                newName: "Name");
        }
    }
}
