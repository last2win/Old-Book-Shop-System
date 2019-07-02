using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Migrations
{
    public partial class Initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderList_Order_Orderid",
                table: "OrderList");

            migrationBuilder.DropIndex(
                name: "IX_OrderList_Orderid",
                table: "OrderList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderList_Orderid",
                table: "OrderList",
                column: "Orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderList_Order_Orderid",
                table: "OrderList",
                column: "Orderid",
                principalTable: "Order",
                principalColumn: "Orderid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
