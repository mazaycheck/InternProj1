using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class modif2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annoucements_Categories_CategoryId",
                table: "Annoucements");

            migrationBuilder.DropForeignKey(
                name: "FK_Annoucements_Users_UserId",
                table: "Annoucements");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Annoucements",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Annoucements",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Title" },
                values: new object[,]
                {
                    { 1, "Vehicles" },
                    { 2, "Electronics" },
                    { 3, "Clothes" }
                });

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 1,
                columns: new[] { "CoordX", "CoordY" },
                values: new object[] { 199, 250 });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "TownId", "CoordX", "CoordY", "Title" },
                values: new object[,]
                {
                    { 2, 250, 300, "Balti" },
                    { 3, 100, 115, "Cahul" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "TownId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "TownId",
                value: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_Annoucements_Categories_CategoryId",
                table: "Annoucements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Annoucements_Users_UserId",
                table: "Annoucements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annoucements_Categories_CategoryId",
                table: "Annoucements");

            migrationBuilder.DropForeignKey(
                name: "FK_Annoucements_Users_UserId",
                table: "Annoucements");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Annoucements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Annoucements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 1,
                columns: new[] { "CoordX", "CoordY" },
                values: new object[] { 0, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "PasswordSalt", "PhoneNumber", "TownId" },
                values: new object[] { 3, "Iura@gmail.com", "Iura", null, null, "06546876", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "PasswordSalt", "PhoneNumber", "TownId" },
                values: new object[] { 2, "Olga@gmail.com", "Olga", null, null, "06546876", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Annoucements_Categories_CategoryId",
                table: "Annoucements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Annoucements_Users_UserId",
                table: "Annoucements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
