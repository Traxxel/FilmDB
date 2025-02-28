using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FilmDB.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddGesehenEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gesehen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titel = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    GesehenAm = table.Column<DateTime>(type: "date", nullable: false),
                    Bewertung = table.Column<int>(type: "integer", nullable: false),
                    Kommentar = table.Column<string>(type: "text", nullable: true),
                    GesehenBeiID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gesehen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gesehen_Sender_GesehenBeiID",
                        column: x => x.GesehenBeiID,
                        principalTable: "Sender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gesehen_GesehenBeiID",
                table: "Gesehen",
                column: "GesehenBeiID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gesehen");
        }
    }
}
