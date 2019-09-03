using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.Data.Migrations
{
    public partial class AddedStatusId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_AspNetUsers_UserId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "DaysBeforeStart",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "RrentDays",
                table: "Rents");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Rents",
                newName: "StatusId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Rents",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "RentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_StatusId",
                table: "Rents",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_RentStatuses_StatusId",
                table: "Rents",
                column: "StatusId",
                principalTable: "RentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_AspNetUsers_UserId",
                table: "Rents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_RentStatuses_StatusId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_AspNetUsers_UserId",
                table: "Rents");

            migrationBuilder.DropTable(
                name: "RentStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Rents_StatusId",
                table: "Rents");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Rents",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Rents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DaysBeforeStart",
                table: "Rents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "Rents",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RrentDays",
                table: "Rents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_AspNetUsers_UserId",
                table: "Rents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
