using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAspApi.Migrations
{
    /// <inheritdoc />
    public partial class RevisionDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocks_LivreId",
                table: "Stocks");

            migrationBuilder.AddColumn<int>(
                name: "LivreId",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_LivreId",
                table: "Stocks",
                column: "LivreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operations_LivreId",
                table: "Operations",
                column: "LivreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Livres_LivreId",
                table: "Operations",
                column: "LivreId",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Livres_LivreId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_LivreId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Operations_LivreId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "LivreId",
                table: "Operations");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_LivreId",
                table: "Stocks",
                column: "LivreId");
        }
    }
}
