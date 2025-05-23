using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnaOkuluYS.Migrations
{
    /// <inheritdoc />
    public partial class DuyuruEtkinlikTemizleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Iletisim");

            migrationBuilder.DropTable(
                name: "Oneriler");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "Etkinlikler");

            migrationBuilder.DropColumn(
                name: "Konum",
                table: "Etkinlikler");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "Duyurular");

            migrationBuilder.DropColumn(
                name: "Onemli",
                table: "Duyurular");

            migrationBuilder.DropColumn(
                name: "ResimUrl",
                table: "Duyurular");

            migrationBuilder.DropColumn(
                name: "SonGecerlilikTarihi",
                table: "Duyurular");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "Etkinlikler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Konum",
                table: "Etkinlikler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "Duyurular",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Onemli",
                table: "Duyurular",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ResimUrl",
                table: "Duyurular",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonGecerlilikTarihi",
                table: "Duyurular",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GonderimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Okundu = table.Column<bool>(type: "bit", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oneriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mesaj = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Okundu = table.Column<bool>(type: "bit", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VeliAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VeliEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oneriler", x => x.Id);
                });
        }
    }
}
