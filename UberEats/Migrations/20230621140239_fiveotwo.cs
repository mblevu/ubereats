using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UberEats.Migrations
{
    /// <inheritdoc />
    public partial class fiveotwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    PartnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.PartnerID);
                    table.ForeignKey(
                        name: "FK_Partners_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Restaurant" },
                    { 2, "Grocery" },
                    { 3, "Alcohol" },
                    { 4, "Convenience" },
                    { 5, "Flowers" },
                    { 6, "Petstore" },
                    { 7, "Retail" }
                });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "Address", "CategoryID", "Email", "Name", "Phone", "Status" },
                values: new object[,]
                {
                    { 1, "Ash Road", 2, "iharvd@mail.com", "Indian Harvest", 793648292, false },
                    { 2, "Ash Road", 4, "celicreate@email.com", "Celidan creation", 793657592, false },
                    { 3, "Spruce Street", 1, "chicks@email.com", "CHicken Inn", 795849292, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partners_CategoryID",
                table: "Partners",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
