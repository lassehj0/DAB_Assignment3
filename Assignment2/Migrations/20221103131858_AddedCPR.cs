using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2.Migrations
{
    public partial class AddedCPR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPR",
                columns: table => new
                {
                    CPRID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPRs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPR", x => x.CPRID);
                    table.ForeignKey(
                        name: "FK_CPR_Bookings_bookingID",
                        column: x => x.bookingID,
                        principalTable: "Bookings",
                        principalColumn: "bookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CPR",
                columns: new[] { "CPRID", "CPRs", "bookingID" },
                values: new object[,]
                {
                    { 1, "010101-1111", 1 },
                    { 2, "020202-2", 1 },
                    { 3, "030303-3333", 1 },
                    { 4, "040404-4", 1 },
                    { 5, "050505-5555", 1 },
                    { 6, "060606-6", 2 },
                    { 7, "070707-7777", 2 },
                    { 8, "080808-8888", 2 },
                    { 9, "090909-9999", 3 },
                    { 10, "101010-1010", 3 },
                    { 11, "111110-1110", 4 },
                    { 12, "121212-1212", 4 },
                    { 13, "131313-1313", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CPR_bookingID",
                table: "CPR",
                column: "bookingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPR");
        }
    }
}
