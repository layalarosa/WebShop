using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    ImportantInformation = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageThumbnailUrl = table.Column<string>(nullable: true),
                    IsGameOfTheWeek = table.Column<bool>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "Accion Belico", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "Rol Accion", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "First Person Shotter", null });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "ImportantInformation", "InStock", "IsGameOfTheWeek", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, 1, "https://cdn.mos.cms.futurecdn.net/AC2X2VJaV48VcNv2FJiC23-320-80.jpg", "https://www.igyaan.in/wp-content/uploads/2015/10/CoD-2-1000x625.jpg", "", true, true, "La narrativa unificada de la campaña para un solo jugador de Vanguard abarca cuatro líneas de frente diferentes de la Segunda Guerra Mundial, centrándose en la Guerra del Pacífico, los frentes occidental y oriental y la campaña del norte de África.", "Call of Duty Vanguard", 75.95m, "Lorem Ipsum" },
                    { 2, 2, "https://us.cdn.eltribuno.com/092021/1631920503361/1366_2000%20(2).jpeg?&cw=320&ch=200", "https://img.8wallpapers.com/uploads/2021/04/ef60ccd081cb4de1b9acddf2-1000x625.jpg", "", true, false, "", "God of War", 60.95m, "Lorem Ipsum" },
                    { 4, 2, "https://cdn.mos.cms.futurecdn.net/E7RJm3PFysWPWq9sNYCij5-320-80.jpg", "https://sm.ign.com/ign_in/game/d/dark-souls/dark-souls-iii_19ft.jpg", "", true, false, "Es un videojuego de rol de acción desarrollado por FromSoftware y publicado por Bandai Namco Entertainment.", "Dark Souls", 70.95m, "Lorem Ipsum" },
                    { 3, 3, "https://us.cdn.eltribuno.com/072020/1596235960841.jpg?&cw=320&ch=200", "https://img.8wallpapers.com/uploads/2019/01/a1da12514cc1496a83be1783-1000x625.jpg", "", true, false, "El jefe Maestro el gran héroe de la humanidad y personaje principal de la saga se enfrentara a un grupo sanguinario y temible que alguna vez fueron parte del Covenant llamados los Desterrados, estos fueron integrados desde Halo Wars 2 y en las novelas del universo de Halo, ahora debutando como la amenaza principal en Halo Infinite.", "Halo Infinite", 55.95m, "Lorem Ipsum" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_CategoryId",
                table: "Games",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
