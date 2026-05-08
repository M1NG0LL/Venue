using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Venue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixingrelationbetweenvenuesandusersandreviewsandusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venues_AspNetUsers_CreatedById",
                table: "Venues");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_AspNetUsers_CreatedById",
                table: "Venues",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venues_AspNetUsers_CreatedById",
                table: "Venues");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_AspNetUsers_CreatedById",
                table: "Venues",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
