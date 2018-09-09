using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieData.Migrations
{
    public partial class dbContextChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holds_MovieAssests_RefMovieAssestId",
                table: "Holds");

            migrationBuilder.DropIndex(
                name: "IX_Holds_RefMovieAssestId",
                table: "Holds");

            migrationBuilder.DropColumn(
                name: "RefMovieAssestId",
                table: "Holds");

            migrationBuilder.AddColumn<bool>(
                name: "Checkedout",
                table: "MovieAssests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DiskType",
                table: "Holds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieTitle",
                table: "Holds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checkedout",
                table: "MovieAssests");

            migrationBuilder.DropColumn(
                name: "DiskType",
                table: "Holds");

            migrationBuilder.DropColumn(
                name: "MovieTitle",
                table: "Holds");

            migrationBuilder.AddColumn<int>(
                name: "RefMovieAssestId",
                table: "Holds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Holds_RefMovieAssestId",
                table: "Holds",
                column: "RefMovieAssestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_MovieAssests_RefMovieAssestId",
                table: "Holds",
                column: "RefMovieAssestId",
                principalTable: "MovieAssests",
                principalColumn: "AssestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
