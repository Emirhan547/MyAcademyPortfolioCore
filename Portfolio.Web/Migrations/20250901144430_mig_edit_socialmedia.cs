using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Web.Migrations
{
    /// <inheritdoc />
    public partial class mig_edit_socialmedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "SocialMedias",
                newName: "LinkedInUrl");

            migrationBuilder.RenameColumn(
                name: "Platform",
                table: "SocialMedias",
                newName: "InstagramUrl");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "SocialMedias",
                newName: "GithubUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkedInUrl",
                table: "SocialMedias",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "InstagramUrl",
                table: "SocialMedias",
                newName: "Platform");

            migrationBuilder.RenameColumn(
                name: "GithubUrl",
                table: "SocialMedias",
                newName: "Icon");
        }
    }
}
