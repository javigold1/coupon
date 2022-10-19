using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeltExamCSharp.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Association_Coupon_CouponId",
                table: "Association");

            migrationBuilder.DropForeignKey(
                name: "FK_Association_Users_UserId",
                table: "Association");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupon_Users_UserId",
                table: "Coupon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coupon",
                table: "Coupon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Association",
                table: "Association");

            migrationBuilder.RenameTable(
                name: "Coupon",
                newName: "Coupons");

            migrationBuilder.RenameTable(
                name: "Association",
                newName: "Associations");

            migrationBuilder.RenameIndex(
                name: "IX_Coupon_UserId",
                table: "Coupons",
                newName: "IX_Coupons_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Association_UserId",
                table: "Associations",
                newName: "IX_Associations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Association_CouponId",
                table: "Associations",
                newName: "IX_Associations_CouponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coupons",
                table: "Coupons",
                column: "CouponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Associations",
                table: "Associations",
                column: "AssociationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Coupons_CouponId",
                table: "Associations",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "CouponId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Users_UserId",
                table: "Associations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Users_UserId",
                table: "Coupons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Coupons_CouponId",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Users_UserId",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Users_UserId",
                table: "Coupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coupons",
                table: "Coupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Associations",
                table: "Associations");

            migrationBuilder.RenameTable(
                name: "Coupons",
                newName: "Coupon");

            migrationBuilder.RenameTable(
                name: "Associations",
                newName: "Association");

            migrationBuilder.RenameIndex(
                name: "IX_Coupons_UserId",
                table: "Coupon",
                newName: "IX_Coupon_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_UserId",
                table: "Association",
                newName: "IX_Association_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_CouponId",
                table: "Association",
                newName: "IX_Association_CouponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coupon",
                table: "Coupon",
                column: "CouponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Association",
                table: "Association",
                column: "AssociationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Association_Coupon_CouponId",
                table: "Association",
                column: "CouponId",
                principalTable: "Coupon",
                principalColumn: "CouponId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Association_Users_UserId",
                table: "Association",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupon_Users_UserId",
                table: "Coupon",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
