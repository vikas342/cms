using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task__007.Migrations
{
    /// <inheritdoc />
    public partial class qwerty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__hotels__cid__3E52440B",
                table: "hotels");

            migrationBuilder.RenameColumn(
                name: "id_id",
                table: "Getalldata_Sp",
                newName: "cadd");

            migrationBuilder.AlterColumn<int>(
                name: "cid",
                table: "hotels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hotels",
                table: "Getalldata_Sp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "speakers",
                table: "Getalldata_Sp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "conf_details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK__hotels__cid__3E52440B",
                table: "hotels",
                column: "cid",
                principalTable: "conf_details",
                principalColumn: "cid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__hotels__cid__3E52440B",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "hotels",
                table: "Getalldata_Sp");

            migrationBuilder.DropColumn(
                name: "speakers",
                table: "Getalldata_Sp");

            migrationBuilder.DropColumn(
                name: "status",
                table: "conf_details");

            migrationBuilder.RenameColumn(
                name: "cadd",
                table: "Getalldata_Sp",
                newName: "id_id");

            migrationBuilder.AlterColumn<int>(
                name: "cid",
                table: "hotels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK__hotels__cid__3E52440B",
                table: "hotels",
                column: "cid",
                principalTable: "conf_details",
                principalColumn: "cid");
        }
    }
}
