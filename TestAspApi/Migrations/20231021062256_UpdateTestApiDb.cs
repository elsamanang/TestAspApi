using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAspApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTestApiDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Livres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livres_GenreId",
                table: "Livres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_Genres_GenreId",
                table: "Livres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livres_Genres_GenreId",
                table: "Livres");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Livres_GenreId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Livres");
        }
    }
}
