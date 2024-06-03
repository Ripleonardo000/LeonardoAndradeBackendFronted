using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeonardoAndradeBackendMVC.Migrations
{
    /// <inheritdoc />
    public partial class LA_Burgers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LA_Burger",
                columns: table => new
                {
                    BurgerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithCheese = table.Column<bool>(type: "bit", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LA_Burger", x => x.BurgerID);
                });

            migrationBuilder.CreateTable(
                name: "LA_Promo",
                columns: table => new
                {
                    PromoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPromo = table.Column<int>(type: "int", nullable: false),
                    BurgerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LA_Promo", x => x.PromoID);
                    table.ForeignKey(
                        name: "FK_LA_Promo_LA_Burger_BurgerID",
                        column: x => x.BurgerID,
                        principalTable: "LA_Burger",
                        principalColumn: "BurgerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LA_Promo_BurgerID",
                table: "LA_Promo",
                column: "BurgerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LA_Promo");

            migrationBuilder.DropTable(
                name: "LA_Burger");
        }
    }
}
