using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddressId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Addresses_AdressId",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "Branches",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_AdressId",
                table: "Branches",
                newName: "IX_Branches_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Addresses_AddressId",
                table: "Branches",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Addresses_AddressId",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Branches",
                newName: "AdressId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_AddressId",
                table: "Branches",
                newName: "IX_Branches_AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Addresses_AdressId",
                table: "Branches",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
