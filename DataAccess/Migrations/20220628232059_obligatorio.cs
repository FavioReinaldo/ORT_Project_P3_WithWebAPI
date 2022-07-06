using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class obligatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ImpuestoImportacion = table.Column<double>(nullable: true),
                    EsOrigenAmericaDelSur = table.Column<bool>(nullable: true),
                    PorcentajeDescuento = table.Column<double>(nullable: true),
                    MedidasSanitarias = table.Column<string>(nullable: true),
                    Iva = table.Column<double>(nullable: true),
                    Flete = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FichaCuidados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrecuenciaRiego = table.Column<string>(nullable: true),
                    Illuminacion = table.Column<string>(nullable: true),
                    Temperatura = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaCuidados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plantas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipo = table.Column<string>(nullable: true),
                    NombreCientifico = table.Column<string>(nullable: true),
                    NombresVulgares = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Ambiente = table.Column<string>(nullable: true),
                    AlturaMaxima = table.Column<int>(nullable: false),
                    FotoPlanta = table.Column<string>(nullable: true),
                    FichaCuidadosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantas_FichaCuidados_FichaCuidadosId",
                        column: x => x.FichaCuidadosId,
                        principalTable: "FichaCuidados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCompras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantaCompradaId = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioCompraUnidad = table.Column<decimal>(nullable: false),
                    CompraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCompras_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCompras_Plantas_PlantaCompradaId",
                        column: x => x.PlantaCompradaId,
                        principalTable: "Plantas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_CompraId",
                table: "ItemCompras",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_PlantaCompradaId",
                table: "ItemCompras",
                column: "PlantaCompradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_FichaCuidadosId",
                table: "Plantas",
                column: "FichaCuidadosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCompras");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Plantas");

            migrationBuilder.DropTable(
                name: "FichaCuidados");
        }
    }
}
