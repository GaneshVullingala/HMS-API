using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApi.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPatientInfo",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genid = table.Column<int>(type: "int", nullable: false),
                    FrontdeskId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresentProblem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatientInfo", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "tblRoleInfo",
                columns: table => new
                {
                    RoledId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoleInfo", x => x.RoledId);
                });

            migrationBuilder.CreateTable(
                name: "tblPatientVitalsInfo",
                columns: table => new
                {
                    VitalsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    BP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SPO2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatientVitalsInfo", x => x.VitalsId);
                    table.ForeignKey(
                        name: "FK_tblPatientVitalsInfo_tblPatientInfo_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tblPatientInfo",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblGeneralInfo",
                columns: table => new
                {
                    Genid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Roleid = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGeneralInfo", x => x.Genid);
                    table.ForeignKey(
                        name: "FK_tblGeneralInfo_tblRoleInfo_Roleid",
                        column: x => x.Roleid,
                        principalTable: "tblRoleInfo",
                        principalColumn: "RoledId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCommunicationInfo",
                columns: table => new
                {
                    CommId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCommunicationInfo", x => x.CommId);
                    table.ForeignKey(
                        name: "FK_tblCommunicationInfo_tblGeneralInfo_GenId",
                        column: x => x.GenId,
                        principalTable: "tblGeneralInfo",
                        principalColumn: "Genid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDoctorInfo",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    PhotoImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDoctorInfo", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_tblDoctorInfo_tblGeneralInfo_GenId",
                        column: x => x.GenId,
                        principalTable: "tblGeneralInfo",
                        principalColumn: "Genid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblFrontDeskInfo",
                columns: table => new
                {
                    FrontDeskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    PhotoImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFrontDeskInfo", x => x.FrontDeskId);
                    table.ForeignKey(
                        name: "FK_tblFrontDeskInfo_tblGeneralInfo_GenId",
                        column: x => x.GenId,
                        principalTable: "tblGeneralInfo",
                        principalColumn: "Genid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblLoginInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genid = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLoginInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblLoginInfo_tblGeneralInfo_Genid",
                        column: x => x.Genid,
                        principalTable: "tblGeneralInfo",
                        principalColumn: "Genid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblConsultationInfo",
                columns: table => new
                {
                    ConsultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    FrontDeskId = table.Column<int>(type: "int", nullable: false),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diognosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Advice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblConsultationInfo", x => x.ConsultId);
                    table.ForeignKey(
                        name: "FK_tblConsultationInfo_tblDoctorInfo_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "tblDoctorInfo",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblConsultationInfo_tblFrontDeskInfo_FrontDeskId",
                        column: x => x.FrontDeskId,
                        principalTable: "tblFrontDeskInfo",
                        principalColumn: "FrontDeskId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblConsultationInfo_tblPatientInfo_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tblPatientInfo",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPatientVisitInfo",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    LastVisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatientVisitInfo", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_tblPatientVisitInfo_tblConsultationInfo_ConsultId",
                        column: x => x.ConsultId,
                        principalTable: "tblConsultationInfo",
                        principalColumn: "ConsultId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPatientVisitInfo_tblDoctorInfo_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "tblDoctorInfo",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPatientVisitInfo_tblPatientInfo_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tblPatientInfo",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblprescriptionInfo",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Medicine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isMrngMedicine1 = table.Column<int>(type: "int", nullable: false),
                    isANoonMedicine1 = table.Column<int>(type: "int", nullable: false),
                    isNightMedicine1 = table.Column<int>(type: "int", nullable: false),
                    Medicine1Quantity = table.Column<int>(type: "int", nullable: false),
                    Medicine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isMrngMedicine2 = table.Column<int>(type: "int", nullable: false),
                    isANoonMedicine2 = table.Column<int>(type: "int", nullable: false),
                    isNightMedicine2 = table.Column<int>(type: "int", nullable: false),
                    Medicine2Quantity = table.Column<int>(type: "int", nullable: false),
                    Medicine3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isMrngMedicine3 = table.Column<int>(type: "int", nullable: false),
                    isANoonMedicine3 = table.Column<int>(type: "int", nullable: false),
                    isNightMedicine3 = table.Column<int>(type: "int", nullable: false),
                    Medicine3Quantity = table.Column<int>(type: "int", nullable: false),
                    Medicine4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isMrngMedicine4 = table.Column<int>(type: "int", nullable: false),
                    isANoonMedicine4 = table.Column<int>(type: "int", nullable: false),
                    isNightMedicine4 = table.Column<int>(type: "int", nullable: false),
                    Medicine4Quantity = table.Column<int>(type: "int", nullable: false),
                    Medicine5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isMrngMedicine5 = table.Column<int>(type: "int", nullable: false),
                    isANoonMedicine5 = table.Column<int>(type: "int", nullable: false),
                    isNightMedicine5 = table.Column<int>(type: "int", nullable: false),
                    Medicine5Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblprescriptionInfo", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_tblprescriptionInfo_tblConsultationInfo_ConsultId",
                        column: x => x.ConsultId,
                        principalTable: "tblConsultationInfo",
                        principalColumn: "ConsultId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblprescriptionInfo_tblDoctorInfo_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "tblDoctorInfo",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblprescriptionInfo_tblPatientInfo_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tblPatientInfo",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCommunicationInfo_GenId",
                table: "tblCommunicationInfo",
                column: "GenId");

            migrationBuilder.CreateIndex(
                name: "IX_tblConsultationInfo_DoctorId",
                table: "tblConsultationInfo",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblConsultationInfo_FrontDeskId",
                table: "tblConsultationInfo",
                column: "FrontDeskId");

            migrationBuilder.CreateIndex(
                name: "IX_tblConsultationInfo_PatientId",
                table: "tblConsultationInfo",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctorInfo_GenId",
                table: "tblDoctorInfo",
                column: "GenId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFrontDeskInfo_GenId",
                table: "tblFrontDeskInfo",
                column: "GenId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGeneralInfo_Roleid",
                table: "tblGeneralInfo",
                column: "Roleid");

            migrationBuilder.CreateIndex(
                name: "IX_tblLoginInfo_Genid",
                table: "tblLoginInfo",
                column: "Genid");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatientVisitInfo_ConsultId",
                table: "tblPatientVisitInfo",
                column: "ConsultId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatientVisitInfo_DoctorId",
                table: "tblPatientVisitInfo",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatientVisitInfo_PatientId",
                table: "tblPatientVisitInfo",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatientVitalsInfo_PatientId",
                table: "tblPatientVitalsInfo",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblprescriptionInfo_ConsultId",
                table: "tblprescriptionInfo",
                column: "ConsultId");

            migrationBuilder.CreateIndex(
                name: "IX_tblprescriptionInfo_DoctorId",
                table: "tblprescriptionInfo",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblprescriptionInfo_PatientId",
                table: "tblprescriptionInfo",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCommunicationInfo");

            migrationBuilder.DropTable(
                name: "tblLoginInfo");

            migrationBuilder.DropTable(
                name: "tblPatientVisitInfo");

            migrationBuilder.DropTable(
                name: "tblPatientVitalsInfo");

            migrationBuilder.DropTable(
                name: "tblprescriptionInfo");

            migrationBuilder.DropTable(
                name: "tblConsultationInfo");

            migrationBuilder.DropTable(
                name: "tblDoctorInfo");

            migrationBuilder.DropTable(
                name: "tblFrontDeskInfo");

            migrationBuilder.DropTable(
                name: "tblPatientInfo");

            migrationBuilder.DropTable(
                name: "tblGeneralInfo");

            migrationBuilder.DropTable(
                name: "tblRoleInfo");
        }
    }
}
