using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET6AspNetCoreMvc_v2.Migrations
{
    public partial class UserUpdated_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageFileName",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValue:"no-image.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageFileName",
                table: "Users");
        }
    }
}
