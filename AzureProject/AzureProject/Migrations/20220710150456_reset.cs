using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureProject.Migrations
{
    public partial class reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Q1",
                table: "UserMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Q2",
                table: "UserMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Q1",
                table: "UserMasters");

            migrationBuilder.DropColumn(
                name: "Q2",
                table: "UserMasters");
        }
    }
}
