using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieData.Migrations
{
    public partial class InitialCheckoutMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieAssests",
                columns: table => new
                {
                    AssestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RefMovieId = table.Column<int>(nullable: false),
                    RefOfficeId = table.Column<int>(nullable: false),
                    LocationOfficeId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieAssests", x => x.AssestId);
                    table.ForeignKey(
                        name: "FK_MovieAssests_Offices_LocationOfficeId",
                        column: x => x.LocationOfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieAssests_Movies_RefMovieId",
                        column: x => x.RefMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    HoldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoldDate = table.Column<DateTime>(nullable: false),
                    RefAspNetUserId = table.Column<int>(nullable: false),
                    RefMovieAssestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.HoldId);
                    table.ForeignKey(
                        name: "FK_Holds_MovieAssests_RefMovieAssestId",
                        column: x => x.RefMovieAssestId,
                        principalTable: "MovieAssests",
                        principalColumn: "AssestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalCheckoutHistories",
                columns: table => new
                {
                    RentalHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckoutDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true),
                    RefAspNetUserId = table.Column<int>(nullable: false),
                    RefMovieAssestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalCheckoutHistories", x => x.RentalHistoryId);
                    table.ForeignKey(
                        name: "FK_RentalCheckoutHistories_MovieAssests_RefMovieAssestId",
                        column: x => x.RefMovieAssestId,
                        principalTable: "MovieAssests",
                        principalColumn: "AssestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalCheckouts",
                columns: table => new
                {
                    CheckoutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckoutDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    RefAspNetUserId = table.Column<int>(nullable: false),
                    RefMovieAssestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalCheckouts", x => x.CheckoutId);
                    table.ForeignKey(
                        name: "FK_RentalCheckouts_MovieAssests_RefMovieAssestId",
                        column: x => x.RefMovieAssestId,
                        principalTable: "MovieAssests",
                        principalColumn: "AssestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holds_RefMovieAssestId",
                table: "Holds",
                column: "RefMovieAssestId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieAssests_LocationOfficeId",
                table: "MovieAssests",
                column: "LocationOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieAssests_RefMovieId",
                table: "MovieAssests",
                column: "RefMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalCheckoutHistories_RefMovieAssestId",
                table: "RentalCheckoutHistories",
                column: "RefMovieAssestId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalCheckouts_RefMovieAssestId",
                table: "RentalCheckouts",
                column: "RefMovieAssestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "RentalCheckoutHistories");

            migrationBuilder.DropTable(
                name: "RentalCheckouts");

            migrationBuilder.DropTable(
                name: "MovieAssests");
        }
    }
}
