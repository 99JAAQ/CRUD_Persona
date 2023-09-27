using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Proyecto.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTable_person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Person");
        }
    }
}
