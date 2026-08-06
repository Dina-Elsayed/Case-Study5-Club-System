using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Case5_ClubSystem.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Capacity", "HourlyPrice", "Name" },
                values: new object[,]
                {
                    { 1, 30, 200m, "Swimming Pool" },
                    { 2, 22, 600m, "Football Court" },
                    { 3, 15, 400m, "Basketball Court" },
                    { 4, 4, 300m, "Tennis Court" },
                    { 5, 80, 150m, "Fitness Hall" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@gmail.com", "Ahmed Ali", "01012345678" },
                    { 2, new DateTime(1998, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@gmail.com", "Sara Mohamed", "01198765432" },
                    { 3, new DateTime(2002, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar@gmail.com", "Omar Hassan", "01234567890" },
                    { 4, new DateTime(1999, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mona@gmail.com", "Mona Adel", "01511112222" },
                    { 5, new DateTime(1997, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef@gmail.com", "Youssef Mahmoud", "01099998888" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "EndTime", "FacilityId", "GroupSize", "MemberId", "StartTime", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), 1, 5, 1, new TimeSpan(0, 10, 0, 0, 0), "Confirmed" },
                    { 2, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 30, 0, 0), 2, 10, 2, new TimeSpan(0, 12, 0, 0, 0), "Confirmed" },
                    { 3, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), 4, 4, 3, new TimeSpan(0, 15, 0, 0, 0), "Completed" },
                    { 4, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 30, 0, 0), 3, 12, 4, new TimeSpan(0, 17, 0, 0, 0), "Confirmed" },
                    { 5, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0), 5, 8, 5, new TimeSpan(0, 19, 0, 0, 0), "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "EndDate", "MemberId", "Price", "StartDate", "Status", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 500m, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Monthly" },
                    { 2, new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1200m, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Quarterly" },
                    { 3, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4500m, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Yearly" },
                    { 4, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 500m, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Expired", "Monthly" },
                    { 5, new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5000m, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Yearly" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "MembershipId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, 500m, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" },
                    { 2, 1200m, 2, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit Card" },
                    { 3, 4500m, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visa" },
                    { 4, 500m, 4, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" },
                    { 5, 5000m, 5, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit Card" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
