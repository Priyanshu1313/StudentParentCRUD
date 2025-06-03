using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student2.Migrations
{
    /// <inheritdoc />
    public partial class parentpartialII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Students_ParentID",
                table: "Parents");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                table: "Parents",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_ParentID",
                table: "Parents",
                newName: "IX_Parents_StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Students_StudentID",
                table: "Parents",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Students_StudentID",
                table: "Parents");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Parents",
                newName: "ParentID");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_StudentID",
                table: "Parents",
                newName: "IX_Parents_ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Students_ParentID",
                table: "Parents",
                column: "ParentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
