using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Delivery.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CargoWeigth",
                table: "Orders",
                newName: "CargoWeight");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CargoWeight", "DatePickup", "RecipientAddress", "RecipientCity", "SendersAddress", "SendersCity" },
                values: new object[,]
                {
                    { new Guid("29ca20e5-2dc8-40f5-ad64-5e681e859da4"), 55, new DateOnly(2024, 11, 28), "ул. Морская д. 66, кв. 6", "Хабаровск", "ул. Первомайская д. 4, кв. 111", "Южно-Сахалинск" },
                    { new Guid("4c55ff5d-cfda-492b-ac13-02c1f17b6e39"), 35, new DateOnly(2024, 4, 23), "ул. Дыбенко д. 11, кв. 103", "Санкт-Петербург", "ул. Водная д. 5, кв. 7", "Москва" },
                    { new Guid("b8528d7f-e4d0-4fb4-bee0-ccfab7642f1c"), 17, new DateOnly(2024, 2, 29), "ул. Смольная д. 22, кв. 11", "Челябинск", "ул. Грузчиков д. 1А, кв. 9", "Петрозаводск" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("29ca20e5-2dc8-40f5-ad64-5e681e859da4"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4c55ff5d-cfda-492b-ac13-02c1f17b6e39"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("b8528d7f-e4d0-4fb4-bee0-ccfab7642f1c"));

            migrationBuilder.RenameColumn(
                name: "CargoWeight",
                table: "Orders",
                newName: "CargoWeigth");
        }
    }
}
