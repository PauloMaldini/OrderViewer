using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderViewer.Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    OrderRefId = table.Column<long>(nullable: false),
                    ProductRefId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderRefId",
                        column: x => x.OrderRefId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductRefId",
                        column: x => x.ProductRefId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Author", "Deleted", "OrderStatus", "RowVersion", "Timestamp" },
                values: new object[] { 1L, null, false, 2, null, new DateTime(2020, 3, 15, 10, 34, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Author", "Deleted", "OrderStatus", "RowVersion", "Timestamp" },
                values: new object[] { 2L, null, false, 2, null, new DateTime(2020, 6, 24, 20, 1, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Author", "Deleted", "OrderStatus", "RowVersion", "Timestamp" },
                values: new object[] { 3L, null, false, 2, null, new DateTime(2020, 8, 27, 14, 59, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Author", "Deleted", "OrderStatus", "RowVersion", "Timestamp" },
                values: new object[] { 4L, null, false, 1, null, new DateTime(2020, 9, 7, 11, 14, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Author", "Deleted", "OrderStatus", "RowVersion", "Timestamp" },
                values: new object[] { 5L, null, false, 1, null, new DateTime(2020, 9, 8, 21, 33, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "Price", "RowVersion" },
                values: new object[] { 1L, null, "1", false, "", "Laptop", 1300m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "Price", "RowVersion" },
                values: new object[] { 2L, null, "2", false, "", "Web camera", 53.23m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "Price", "RowVersion" },
                values: new object[] { 3L, null, "3", false, "", "Router", 120m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "Price", "RowVersion" },
                values: new object[] { 4L, null, "4", false, "", "Commutator", 5500m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "Price", "RowVersion" },
                values: new object[] { 5L, null, "5", false, "", "Printer", 217m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "Price", "RowVersion" },
                values: new object[] { 6L, null, "6", false, "", "Display", 528m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "Price", "RowVersion" },
                values: new object[] { 7L, null, "7", false, "", "Phone", 790m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "Price", "RowVersion" },
                values: new object[] { 8L, null, "8", false, "", "Headphones", 34.77m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "Price", "RowVersion" },
                values: new object[] { 9L, null, "9", false, "", "SSD", 115m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "Price", "RowVersion" },
                values: new object[] { 10L, null, "10", false, "", "RAM", 91m, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 1L, null, false, 1L, 1L, 1, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 3L, null, false, 1L, 10L, 1, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 16L, null, false, 4L, 9L, 6, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 12L, null, false, 3L, 9L, 4, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 6L, null, false, 2L, 8L, 5, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 15L, null, false, 4L, 7L, 1, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 9L, null, false, 2L, 7L, 1, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 4L, null, false, 1L, 7L, 5, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 11L, null, false, 3L, 10L, 1, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 14L, null, false, 4L, 6L, 1, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 13L, null, false, 4L, 3L, 1, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 8L, null, false, 2L, 3L, 3, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 2L, null, false, 1L, 3L, 3, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 5L, null, false, 2L, 2L, 10, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 19L, null, false, 5L, 1L, 5, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 17L, null, false, 4L, 1L, 9, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 10L, null, false, 3L, 1L, 2, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 7L, null, false, 2L, 6L, 2, null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Author", "Deleted", "OrderRefId", "ProductRefId", "Quantity", "RowVersion" },
                values: new object[] { 18L, null, false, 4L, 10L, 2, null });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderRefId",
                table: "OrderItems",
                column: "OrderRefId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductRefId",
                table: "OrderItems",
                column: "ProductRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
