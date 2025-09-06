using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Web.Migrations
{
    /// <inheritdoc />
    public partial class mig_education_edit_schoolName_prop_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameUsename",
                table: "Banners",
                newName: "NameUserName");

            migrationBuilder.AddColumn<string>(
                name: "SchoolName",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolName",
                table: "Educations");

            migrationBuilder.RenameColumn(
                name: "NameUserName",
                table: "Banners",
                newName: "NameUsename");
        }
    }
}
