using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnaOkuluYS.Migrations
{
    /// <inheritdoc />
    public partial class EtkinlikTablosuYeniden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duyurular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YayinTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonGecerlilikTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Onemli = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etkinlikler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Konum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlikler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galeri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimYolu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YuklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galeri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GonderimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Okundu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menuler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SabahKahvaltisi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OgleYemegi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IkindiKahvaltisi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oneriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeliAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VeliEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Okundu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oneriler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duyurular");

            migrationBuilder.DropTable(
                name: "Etkinlikler");

            migrationBuilder.DropTable(
                name: "Galeri");

            migrationBuilder.DropTable(
                name: "Iletisim");

            migrationBuilder.DropTable(
                name: "Menuler");

            migrationBuilder.DropTable(
                name: "Oneriler");
        }
    }
}
