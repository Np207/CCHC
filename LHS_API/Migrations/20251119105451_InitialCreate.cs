using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LHS_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authorized",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorized", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerCatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionBanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Departments_DepId",
                        column: x => x.DepId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionBankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionBanks_QuestionBankId",
                        column: x => x.QuestionBankId,
                        principalTable: "QuestionBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestHandlers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestTimeCountdown = table.Column<float>(type: "real", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestHandlers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestHandlers_QuestionBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "QuestionBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestHandlerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRecords_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestRecords_TestHandlers_TestHandlerId",
                        column: x => x.TestHandlerId,
                        principalTable: "TestHandlers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("196eb711-24b2-4003-bd05-624e5f552640"), new Guid("186eb711-24b2-4003-bd05-624e5f552640"), new Guid("fb776600-cf93-4411-8c39-ddc68682b72a") },
                    { new Guid("196eb711-24b2-4003-bd05-624e5f552641"), new Guid("186eb711-24b2-4003-bd05-624e5f552641"), new Guid("fb776600-cf93-4411-8c39-ddc68682b72a") }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("826eb711-24b2-4003-bd05-624e5f552640"), "Sở Nội vụ tỉnh Cà Mau" },
                    { new Guid("826eb711-24b2-4003-bd05-624e5f552641"), "Hội đồng Nhân dân tỉnh Cà Mau" }
                });

            migrationBuilder.InsertData(
                table: "PermissionCategories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("176eb711-24b2-4003-bd05-624e5f552640"), "Trang Admin", null },
                    { new Guid("176eb711-24b2-4003-bd05-624e5f552641"), "Trang Profile", null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "Name", "PerCatId" },
                values: new object[,]
                {
                    { new Guid("186eb711-24b2-4003-bd05-624e5f552640"), "view-profile-list", "Xem list profiles", new Guid("176eb711-24b2-4003-bd05-624e5f552641") },
                    { new Guid("186eb711-24b2-4003-bd05-624e5f552641"), "create-profile", "Tạo profile", new Guid("176eb711-24b2-4003-bd05-624e5f552641") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "DateOfBirth", "DepId", "IdNumber", "Name", "PhoneNumber" },
                values: new object[] { new Guid("856eb7d9-24b2-4743-bd05-624e5f272640"), null, null, "000000000000", "ADMINISTRATOR", "012345678" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleCode", "RoleName" },
                values: new object[,]
                {
                    { new Guid("fb776600-cf93-4411-8c39-ddc68682b72a"), "TNCM_ADM", "Admin" },
                    { new Guid("fb776600-cf93-4411-8c39-ddc68682b72b"), "TNCM_CONGCHUC", "Công chức" },
                    { new Guid("fb776600-cf93-4411-8c39-ddc68682b72c"), "TNCM_VIENCHUC", "Viên chức" },
                    { new Guid("fb776600-cf93-4411-8c39-ddc68682b72d"), "TNCM_OTHER", "Khác" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedDate", "IsActived", "Password", "ProfileId", "RoleId", "Username" },
                values: new object[] { new Guid("74dcce23-2377-4e91-8990-a7c85ab64630"), new DateTime(2025, 11, 19, 17, 54, 51, 220, DateTimeKind.Local).AddTicks(5804), true, "123456", new Guid("856eb7d9-24b2-4743-bd05-624e5f272640"), new Guid("fb776600-cf93-4411-8c39-ddc68682b72a"), "admin" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "DateOfBirth", "DepId", "IdNumber", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("856eb7d9-24b2-4743-bd05-624e5f272641"), new DateOnly(2001, 10, 20), new Guid("826eb711-24b2-4003-bd05-624e5f552640"), "000000000000", "Pu Bu", "012345678" },
                    { new Guid("856eb7d9-24b2-4743-bd05-624e5f272642"), new DateOnly(2002, 11, 17), new Guid("826eb711-24b2-4003-bd05-624e5f552641"), "000000000000", "Nghi Nghi", "012345678" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedDate", "IsActived", "Password", "ProfileId", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("74dcce23-2377-4e91-8990-a7c85ab64631"), new DateTime(2025, 11, 19, 17, 54, 51, 220, DateTimeKind.Local).AddTicks(5817), true, "123456", new Guid("856eb7d9-24b2-4743-bd05-624e5f272641"), new Guid("fb776600-cf93-4411-8c39-ddc68682b72b"), "pubu" },
                    { new Guid("74dcce23-2377-4e91-8990-a7c85ab64632"), new DateTime(2025, 11, 19, 17, 54, 51, 220, DateTimeKind.Local).AddTicks(5820), true, "123456", new Guid("856eb7d9-24b2-4743-bd05-624e5f272642"), new Guid("fb776600-cf93-4411-8c39-ddc68682b72b"), "nghi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ProfileId",
                table: "Accounts",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_DepId",
                table: "Profiles",
                column: "DepId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionBankId",
                table: "Questions",
                column: "QuestionBankId");

            migrationBuilder.CreateIndex(
                name: "IX_TestHandlers_BankId",
                table: "TestHandlers",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_AccountId",
                table: "TestRecords",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_TestHandlerId",
                table: "TestRecords",
                column: "TestHandlerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authorized");

            migrationBuilder.DropTable(
                name: "PermissionCategories");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "TestRecords");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "TestHandlers");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "QuestionBanks");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
