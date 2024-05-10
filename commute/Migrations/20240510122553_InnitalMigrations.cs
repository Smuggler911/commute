using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace commute.Migrations
{
    /// <inheritdoc />
    public partial class InnitalMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    location_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    location_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "transport",
                columns: table => new
                {
                    transport_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transport_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    location_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transport", x => x.transport_id);
                    table.ForeignKey(
                        name: "FK_transport_location_location_id",
                        column: x => x.location_id,
                        principalTable: "location",
                        principalColumn: "location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "location",
                columns: new[] { "location_id", "Latitude", "location_name", "Longitude" },
                values: new object[,]
                {
                    { 1, 19.045764999999999, "CityA", 10.4636 },
                    { 2, 20.045764999999999, "CityB", 9.5635999999999992 },
                    { 3, 18.67765, "CityC", 11.467460000000001 },
                    { 4, 30.065576499999999, "CityD", 8.6636000000000006 }
                });

            migrationBuilder.InsertData(
                table: "transport",
                columns: new[] { "transport_id", "location_id", "transport_name" },
                values: new object[,]
                {
                    { 1, 1, "Airplane" },
                    { 2, 2, "Airplane" },
                    { 3, 1, "Bus" },
                    { 4, 3, "Bus" },
                    { 5, 3, "Train" },
                    { 6, 4, "Bus" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_transport_location_id",
                table: "transport",
                column: "location_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transport");

            migrationBuilder.DropTable(
                name: "location");
        }
    }
}
