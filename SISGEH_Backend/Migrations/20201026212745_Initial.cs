using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SISGEH_Backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolPersonal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoDelRol = table.Column<string>(nullable: true),
                    NombreDelRol = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPersonal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeSolicitud",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeSolicitud", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDeLaEmpresa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Pass = table.Column<string>(nullable: false),
                    FechaDeIngreso = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    RolPersonalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDeLaEmpresa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonalDeLaEmpresa_RolPersonal_RolPersonalId",
                        column: x => x.RolPersonalId,
                        principalTable: "RolPersonal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagenesDelPersonal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalDeLaEmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenesDelPersonal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImagenesDelPersonal_PersonalDeLaEmpresa_PersonalDeLaEmpresaId",
                        column: x => x.PersonalDeLaEmpresaId,
                        principalTable: "PersonalDeLaEmpresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudDelPersonal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDeSolicitudId = table.Column<int>(nullable: false),
                    PersonalDeLaEmpresaId = table.Column<int>(nullable: false),
                    DescripcionDeLaSolicitud = table.Column<string>(nullable: true),
                    TiempoRequerido = table.Column<int>(nullable: false),
                    FechaDeSolicitud = table.Column<DateTime>(nullable: false),
                    FechaDeRespuesta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudDelPersonal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SolicitudDelPersonal_PersonalDeLaEmpresa_PersonalDeLaEmpresaId",
                        column: x => x.PersonalDeLaEmpresaId,
                        principalTable: "PersonalDeLaEmpresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudDelPersonal_TipoDeSolicitud_TipoDeSolicitudId",
                        column: x => x.TipoDeSolicitudId,
                        principalTable: "TipoDeSolicitud",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelefonosDelPersonal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTelefonico = table.Column<string>(maxLength: 11, nullable: false),
                    PersonalDeLaEmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonosDelPersonal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TelefonosDelPersonal_PersonalDeLaEmpresa_PersonalDeLaEmpresaId",
                        column: x => x.PersonalDeLaEmpresaId,
                        principalTable: "PersonalDeLaEmpresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagenesDelPersonal_PersonalDeLaEmpresaId",
                table: "ImagenesDelPersonal",
                column: "PersonalDeLaEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDeLaEmpresa_RolPersonalId",
                table: "PersonalDeLaEmpresa",
                column: "RolPersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudDelPersonal_PersonalDeLaEmpresaId",
                table: "SolicitudDelPersonal",
                column: "PersonalDeLaEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudDelPersonal_TipoDeSolicitudId",
                table: "SolicitudDelPersonal",
                column: "TipoDeSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonosDelPersonal_PersonalDeLaEmpresaId",
                table: "TelefonosDelPersonal",
                column: "PersonalDeLaEmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenesDelPersonal");

            migrationBuilder.DropTable(
                name: "SolicitudDelPersonal");

            migrationBuilder.DropTable(
                name: "TelefonosDelPersonal");

            migrationBuilder.DropTable(
                name: "TipoDeSolicitud");

            migrationBuilder.DropTable(
                name: "PersonalDeLaEmpresa");

            migrationBuilder.DropTable(
                name: "RolPersonal");
        }
    }
}
