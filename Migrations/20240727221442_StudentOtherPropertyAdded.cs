using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class StudentOtherPropertyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherProperty",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "salam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherProperty",
                table: "Students");
        }
    }
}
