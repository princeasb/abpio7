using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAut0mater.CoreService.Migrations
{
    /// <inheritdoc />
    public partial class AddMITCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MIT");

            migrationBuilder.CreateTable(
                name: "MITCatalogs",
                schema: "MIT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCatalogCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LinkedFeatures = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, defaultValue: "[\"*\"]"),
                    IsFactory = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MITCatalogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MITCatalogs",
                schema: "MIT");
        }
    }
}
