using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    UserOneId = table.Column<int>(nullable: false),
                    UserTwoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => new { x.UserOneId, x.UserTwoId });
                    table.ForeignKey(
                        name: "FK_Chats_Users_UserOneId",
                        column: x => x.UserOneId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_Users_UserTwoId",
                        column: x => x.UserTwoId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<int>(nullable: false),
                    ChatUserOneId = table.Column<int>(nullable: false),
                    ChatUserTwoId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    UserSentId = table.Column<int>(nullable: false),
                    UserRecievedId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserRecievedId",
                        column: x => x.UserRecievedId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserSentId",
                        column: x => x.UserSentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatUserOneId_ChatUserTwoId",
                        columns: x => new { x.ChatUserOneId, x.ChatUserTwoId },
                        principalTable: "Chats",
                        principalColumns: new[] { "UserOneId", "UserTwoId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Annoucements",
                columns: new[] { "AnnoucementId", "CategoryId", "CreateDate", "Description", "ExpireDate", "IsActive", "Negotiable", "Price", "Title", "UserId" },
                values: new object[] { 1, 1, new DateTime(2020, 3, 25, 20, 15, 51, 555, DateTimeKind.Local).AddTicks(4971), "Brand new BMW", new DateTime(2020, 4, 24, 20, 15, 51, 558, DateTimeKind.Local).AddTicks(8305), false, null, 5000, "New car", 1 });

            migrationBuilder.InsertData(
                table: "Annoucements",
                columns: new[] { "AnnoucementId", "CategoryId", "CreateDate", "Description", "ExpireDate", "IsActive", "Negotiable", "Price", "Title", "UserId" },
                values: new object[] { 2, 2, new DateTime(2020, 3, 25, 20, 15, 51, 558, DateTimeKind.Local).AddTicks(9857), "Used phone", new DateTime(2020, 4, 24, 20, 15, 51, 558, DateTimeKind.Local).AddTicks(9906), false, null, 250, "Iphone 6", 2 });

            migrationBuilder.InsertData(
                table: "Annoucements",
                columns: new[] { "AnnoucementId", "CategoryId", "CreateDate", "Description", "ExpireDate", "IsActive", "Negotiable", "Price", "Title", "UserId" },
                values: new object[] { 3, 3, new DateTime(2020, 3, 25, 20, 15, 51, 558, DateTimeKind.Local).AddTicks(9943), "From 2020 Collection", new DateTime(2020, 4, 24, 20, 15, 51, 558, DateTimeKind.Local).AddTicks(9949), false, null, 5000, "Adidas Sneackers", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserTwoId",
                table: "Chats",
                column: "UserTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserRecievedId",
                table: "Messages",
                column: "UserRecievedId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserSentId",
                table: "Messages",
                column: "UserSentId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatUserOneId_ChatUserTwoId",
                table: "Messages",
                columns: new[] { "ChatUserOneId", "ChatUserTwoId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DeleteData(
                table: "Annoucements",
                keyColumn: "AnnoucementId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Annoucements",
                keyColumn: "AnnoucementId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Annoucements",
                keyColumn: "AnnoucementId",
                keyValue: 3);
        }
    }
}
