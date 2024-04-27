using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3.Migrations
{
    /// <inheritdoc />
    public partial class addedfksssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLists_Links_FK_LinkId",
                table: "InterestLists");

            migrationBuilder.AlterColumn<int>(
                name: "FK_LinkId",
                table: "InterestLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLists_Links_FK_LinkId",
                table: "InterestLists",
                column: "FK_LinkId",
                principalTable: "Links",
                principalColumn: "LinkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLists_Links_FK_LinkId",
                table: "InterestLists");

            migrationBuilder.AlterColumn<int>(
                name: "FK_LinkId",
                table: "InterestLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLists_Links_FK_LinkId",
                table: "InterestLists",
                column: "FK_LinkId",
                principalTable: "Links",
                principalColumn: "LinkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
