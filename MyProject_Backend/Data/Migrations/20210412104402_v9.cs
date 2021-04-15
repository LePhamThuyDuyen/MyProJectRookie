using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject_Backend.Data.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rates_AspNetUsers_UserId1",
                table: "rates");

            migrationBuilder.DropTable(
                name: "RateShare");

            migrationBuilder.DropIndex(
                name: "IX_rates_UserId1",
                table: "rates");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "rates");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "rates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "rates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "rates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RateShare",
                columns: table => new
                {
                    RateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateShare", x => x.RateId);
                    table.ForeignKey(
                        name: "FK_RateShare_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rates_UserId1",
                table: "rates",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_RateShare_UserId1",
                table: "RateShare",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_rates_AspNetUsers_UserId1",
                table: "rates",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
