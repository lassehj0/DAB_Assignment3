using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Assignment2.Migrations
{
    public partial class AddedCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "closestAddress",
                table: "Facilities");

            migrationBuilder.AddColumn<Point>(
                name: "coordinates",
                table: "Facilities",
                type: "geography",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "facilityID",
                keyValue: 1,
                column: "coordinates",
                value: (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-122.333 47.6097)"));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "facilityID",
                keyValue: 2,
                column: "coordinates",
                value: (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-10.2454 88.2342)"));

            migrationBuilder.AlterColumn<Point>(
                name: "coordinates",
                table: "Facilities",
                type: "geography",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coordinates",
                table: "Facilities");

            migrationBuilder.AddColumn<string>(
                name: "closestAddress",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "facilityID",
                keyValue: 1,
                column: "closestAddress",
                value: "Børglumvej 21, 8240 Risskov");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "facilityID",
                keyValue: 2,
                column: "closestAddress",
                value: "Spejlvej 33, 8000 Aarhus C");
        }
    }
}
