using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedOrder_Orders_OrderId",
                table: "CompletedOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedOrder",
                table: "CompletedOrder");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "CompletedOrder",
                newName: "CompletedOrders");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedOrder_OrderId",
                table: "CompletedOrders",
                newName: "IX_CompletedOrders_OrderId");

            migrationBuilder.AddColumn<bool>(
                name: "Showcase",
                table: "Files",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedOrders",
                table: "CompletedOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedOrders_Orders_OrderId",
                table: "CompletedOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedOrders_Orders_OrderId",
                table: "CompletedOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedOrders",
                table: "CompletedOrders");

            migrationBuilder.DropColumn(
                name: "Showcase",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "CompletedOrders",
                newName: "CompletedOrder");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedOrders_OrderId",
                table: "CompletedOrder",
                newName: "IX_CompletedOrder_OrderId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedOrder",
                table: "CompletedOrder",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedOrder_Orders_OrderId",
                table: "CompletedOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
