using Microsoft.EntityFrameworkCore.Migrations;

namespace App_web.Migrations
{
    public partial class Student_Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NamePhoto",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamePhoto",
                table: "Students");
        }
    }
}
