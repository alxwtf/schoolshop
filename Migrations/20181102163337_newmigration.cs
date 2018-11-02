using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyContacts_Companies_Companyid",
                table: "CompanyContacts");

            migrationBuilder.DropColumn(
                name: "compID",
                table: "CompanyContacts");

            migrationBuilder.RenameColumn(
                name: "site",
                table: "CompanyContacts",
                newName: "Site");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "CompanyContacts",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "mail",
                table: "CompanyContacts",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "Companyid",
                table: "CompanyContacts",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CompanyContacts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyContacts_Companyid",
                table: "CompanyContacts",
                newName: "IX_CompanyContacts_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "CompanyContacts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyContacts_Companies_CompanyId",
                table: "CompanyContacts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyContacts_Companies_CompanyId",
                table: "CompanyContacts");

            migrationBuilder.RenameColumn(
                name: "Site",
                table: "CompanyContacts",
                newName: "site");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "CompanyContacts",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "CompanyContacts",
                newName: "mail");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "CompanyContacts",
                newName: "Companyid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CompanyContacts",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyContacts_CompanyId",
                table: "CompanyContacts",
                newName: "IX_CompanyContacts_Companyid");

            migrationBuilder.AlterColumn<int>(
                name: "Companyid",
                table: "CompanyContacts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "compID",
                table: "CompanyContacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyContacts_Companies_Companyid",
                table: "CompanyContacts",
                column: "Companyid",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
