using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApi.Migrations
{
    /// <inheritdoc />
    public partial class FixDoctorForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblDoctorInfo_tblGeneralInfo_GeneralInfoGenid",
                table: "tblDoctorInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_tblGeneralInfo_tblRoleInfo_RoleInfoRoledId",
                table: "tblGeneralInfo");

            migrationBuilder.DropIndex(
                name: "IX_tblGeneralInfo_RoleInfoRoledId",
                table: "tblGeneralInfo");

            migrationBuilder.DropIndex(
                name: "IX_tblDoctorInfo_GeneralInfoGenid",
                table: "tblDoctorInfo");

            migrationBuilder.DropColumn(
                name: "RoleInfoRoledId",
                table: "tblGeneralInfo");

            migrationBuilder.DropColumn(
                name: "GeneralInfoGenid",
                table: "tblDoctorInfo");

            migrationBuilder.CreateIndex(
                name: "IX_tblGeneralInfo_Roleid",
                table: "tblGeneralInfo",
                column: "Roleid");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctorInfo_GenId",
                table: "tblDoctorInfo",
                column: "GenId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblDoctorInfo_tblGeneralInfo_GenId",
                table: "tblDoctorInfo",
                column: "GenId",
                principalTable: "tblGeneralInfo",
                principalColumn: "Genid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblGeneralInfo_tblRoleInfo_Roleid",
                table: "tblGeneralInfo",
                column: "Roleid",
                principalTable: "tblRoleInfo",
                principalColumn: "RoledId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblDoctorInfo_tblGeneralInfo_GenId",
                table: "tblDoctorInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_tblGeneralInfo_tblRoleInfo_Roleid",
                table: "tblGeneralInfo");

            migrationBuilder.DropIndex(
                name: "IX_tblGeneralInfo_Roleid",
                table: "tblGeneralInfo");

            migrationBuilder.DropIndex(
                name: "IX_tblDoctorInfo_GenId",
                table: "tblDoctorInfo");

            migrationBuilder.AddColumn<int>(
                name: "RoleInfoRoledId",
                table: "tblGeneralInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneralInfoGenid",
                table: "tblDoctorInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblGeneralInfo_RoleInfoRoledId",
                table: "tblGeneralInfo",
                column: "RoleInfoRoledId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctorInfo_GeneralInfoGenid",
                table: "tblDoctorInfo",
                column: "GeneralInfoGenid");

            migrationBuilder.AddForeignKey(
                name: "FK_tblDoctorInfo_tblGeneralInfo_GeneralInfoGenid",
                table: "tblDoctorInfo",
                column: "GeneralInfoGenid",
                principalTable: "tblGeneralInfo",
                principalColumn: "Genid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblGeneralInfo_tblRoleInfo_RoleInfoRoledId",
                table: "tblGeneralInfo",
                column: "RoleInfoRoledId",
                principalTable: "tblRoleInfo",
                principalColumn: "RoledId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
