using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyEats.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postcodes",
                columns: table => new
                {
                    PostcodeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostcodePrefix = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Town = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postcodes", x => x.PostcodeId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    PostcodeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_Restaurants_Postcodes_PostcodeId",
                        column: x => x.PostcodeId,
                        principalTable: "Postcodes",
                        principalColumn: "PostcodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StreetAddress = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Postcode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    PostcodeId = table.Column<int>(type: "integer", nullable: true),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    DateRegistered = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Postcodes_PostcodeId",
                        column: x => x.PostcodeId,
                        principalTable: "Postcodes",
                        principalColumn: "PostcodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuItemId = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    DateOrdered = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    OrderEntityOrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItems_Orders_OrderEntityOrderId",
                        column: x => x.OrderEntityOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InOrders",
                columns: table => new
                {
                    InOrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    MenuItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InOrders", x => x.InOrderId);
                    table.ForeignKey(
                        name: "FK_InOrders_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InOrders_MenuItemId",
                table: "InOrders",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InOrders_OrderId",
                table: "InOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_OrderEntityOrderId",
                table: "MenuItems",
                column: "OrderEntityOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantId",
                table: "MenuItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_PostcodeId",
                table: "Restaurants",
                column: "PostcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostcodeId",
                table: "Users",
                column: "PostcodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InOrders");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Postcodes");
        }
    }
}
