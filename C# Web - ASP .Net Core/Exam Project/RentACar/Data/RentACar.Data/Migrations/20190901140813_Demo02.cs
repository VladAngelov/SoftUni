using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.Data.Migrations
{
    public partial class Demo02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "BookedId",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IsBookeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsBookeds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BookedId",
                table: "Cars",
                column: "BookedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_IsBookeds_BookedId",
                table: "Cars",
                column: "BookedId",
                principalTable: "IsBookeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_IsBookeds_BookedId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "IsBookeds");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BookedId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BookedId",
                table: "Cars");

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Cars",
                nullable: false,
                defaultValue: false);
        }
    }
}
