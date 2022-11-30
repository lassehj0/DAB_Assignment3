using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    facilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maxOccupants = table.Column<int>(type: "int", nullable: false),
                    reservable = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    utilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    closestAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kind = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    facilityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.facilityID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVR = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    facilityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_Items_Facilities_facilityID",
                        column: x => x.facilityID,
                        principalTable: "Facilities",
                        principalColumn: "facilityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    bookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hourInterval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    participants = table.Column<int>(type: "int", nullable: false),
                    authentication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    facilityID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.bookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Facilities_facilityID",
                        column: x => x.facilityID,
                        principalTable: "Facilities",
                        principalColumn: "facilityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintainances",
                columns: table => new
                {
                    maintainanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintainances", x => x.maintainanceID);
                    table.ForeignKey(
                        name: "FK_Maintainances_Items_itemID",
                        column: x => x.itemID,
                        principalTable: "Items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "facilityID", "closestAddress", "description", "facilityName", "kind", "maxOccupants", "reservable", "utilities" },
                values: new object[,]
                {
                    { 1, "Børglumvej 21, 8240 Risskov", "A shelter located in Risskov forest", "Risskov shelter", "Shelter", 5, true, "Sink" },
                    { 2, "Spejlvej 33, 8000 Aarhus C", null, "Aarhus central forest fireplace", "Firplace", 3, true, null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "userID", "CVR", "category", "email", "name", "phoneNumber" },
                values: new object[,]
                {
                    { 1, 12345678, "school", "sdbck@mail.com", "Lasse", 12345678 },
                    { 2, null, "private", "dasd@mail.com", "Aske", 12345678 },
                    { 3, null, "private", "adsd@mail.com", "Marcus", 12345678 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "bookingID", "authentication", "category", "facilityID", "hourInterval", "note", "participants", "userID" },
                values: new object[,]
                {
                    { 1, "AA8B420OP69", "school", 1, "10:00-15:00", "We might be done early", 5, 1 },
                    { 2, "HHSV7728JJD", "school", 1, "12:00-13:00", null, 3, 1 },
                    { 3, "UUA0339JDBN", "private", 2, "09:00-11:30", null, 2, 2 },
                    { 4, "UBDJA8AB659", "private", 2, "14:30-16:00", null, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "itemId", "facilityID", "name" },
                values: new object[,]
                {
                    { 1, 1, "Shovel" },
                    { 2, 1, "Pan" },
                    { 3, 2, "Shovel" }
                });

            migrationBuilder.InsertData(
                table: "Maintainances",
                columns: new[] { "maintainanceID", "date", "description", "itemID" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Is getting a bit rusty, might need replacing soon", 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A bit bent but still fine", 2 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The handle had fallen off but is reattached", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_facilityID",
                table: "Bookings",
                column: "facilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_userID",
                table: "Bookings",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_facilityID",
                table: "Items",
                column: "facilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintainances_itemID",
                table: "Maintainances",
                column: "itemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Maintainances");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Facilities");
        }
    }
}
