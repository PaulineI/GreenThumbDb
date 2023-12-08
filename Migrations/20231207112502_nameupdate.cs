using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    /// <inheritdoc />
    public partial class nameupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Plants_PlantId",
                table: "Instructions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructions",
                table: "Instructions");

            migrationBuilder.RenameTable(
                name: "Instructions",
                newName: "Instruction");

            migrationBuilder.RenameColumn(
                name: "Instructions",
                table: "Instruction",
                newName: "Instruction");

            migrationBuilder.RenameIndex(
                name: "IX_Instructions_PlantId",
                table: "Instruction",
                newName: "IX_Instruction_PlantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instruction",
                table: "Instruction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Plants_PlantId",
                table: "Instruction",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Plants_PlantId",
                table: "Instruction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instruction",
                table: "Instruction");

            migrationBuilder.RenameTable(
                name: "Instruction",
                newName: "Instructions");

            migrationBuilder.RenameColumn(
                name: "Instruction",
                table: "Instructions",
                newName: "Instructions");

            migrationBuilder.RenameIndex(
                name: "IX_Instruction_PlantId",
                table: "Instructions",
                newName: "IX_Instructions_PlantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructions",
                table: "Instructions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Plants_PlantId",
                table: "Instructions",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
