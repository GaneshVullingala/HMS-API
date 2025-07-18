using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApi.Migrations
{
    /// <inheritdoc />
    public partial class FixFrontDeskForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFrontDeskInfo_tblGeneralInfo_GeneralInfoGenid",
                table: "tblFrontDeskInfo");

            migrationBuilder.DropIndex(
                name: "IX_tblFrontDeskInfo_GeneralInfoGenid",
                table: "tblFrontDeskInfo");

            migrationBuilder.DropColumn(
                name: "GeneralInfoGenid",
                table: "tblFrontDeskInfo");

            migrationBuilder.CreateIndex(
                name: "IX_tblFrontDeskInfo_GenId",
                table: "tblFrontDeskInfo",
                column: "GenId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFrontDeskInfo_tblGeneralInfo_GenId",
                table: "tblFrontDeskInfo",
                column: "GenId",
                principalTable: "tblGeneralInfo",
                principalColumn: "Genid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFrontDeskInfo_tblGeneralInfo_GenId",
                table: "tblFrontDeskInfo");

            migrationBuilder.DropIndex(
                name: "IX_tblFrontDeskInfo_GenId",
                table: "tblFrontDeskInfo");

            migrationBuilder.AddColumn<int>(
                name: "GeneralInfoGenid",
                table: "tblFrontDeskInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblFrontDeskInfo_GeneralInfoGenid",
                table: "tblFrontDeskInfo",
                column: "GeneralInfoGenid");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFrontDeskInfo_tblGeneralInfo_GeneralInfoGenid",
                table: "tblFrontDeskInfo",
                column: "GeneralInfoGenid",
                principalTable: "tblGeneralInfo",
                principalColumn: "Genid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
