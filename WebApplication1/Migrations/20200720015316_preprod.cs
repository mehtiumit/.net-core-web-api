using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class preprod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    UserSurname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Adds",
                columns: table => new
                {
                    AddId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddInfo = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adds", x => x.AddId);
                    table.ForeignKey(
                        name: "FK_Adds_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddAndCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    AddId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddAndCategories", x => new { x.CategoryId, x.AddId });
                    table.ForeignKey(
                        name: "FK_AddAndCategories_Adds_AddId",
                        column: x => x.AddId,
                        principalTable: "Adds",
                        principalColumn: "AddId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddAndCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavAds",
                columns: table => new
                {
                    AddId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavAds", x => new { x.AddId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavAds_Adds_AddId",
                        column: x => x.AddId,
                        principalTable: "Adds",
                        principalColumn: "AddId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavAds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    AddsAddId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Adds_AddsAddId",
                        column: x => x.AddsAddId,
                        principalTable: "Adds",
                        principalColumn: "AddId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddAndCategories_AddId",
                table: "AddAndCategories",
                column: "AddId");

            migrationBuilder.CreateIndex(
                name: "IX_Adds_CategoryId",
                table: "Adds",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Adds_UserId",
                table: "Adds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavAds_UserId",
                table: "FavAds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AddsAddId",
                table: "Photos",
                column: "AddsAddId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddAndCategories");

            migrationBuilder.DropTable(
                name: "FavAds");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Adds");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
