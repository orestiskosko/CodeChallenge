using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    HiringDate = table.Column<DateTime>(nullable: false),
                    LastSkillChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => new { x.EmployeeId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "HiringDate", "LastSkillChangeDate", "Surname" },
                values: new object[,]
                {
                    { new Guid("6e1ad796-006d-49e2-818a-e658c1d3c7ef"), "Orestis", new DateTime(2019, 2, 2, 14, 7, 2, 358, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koskoletos" },
                    { new Guid("db0a2230-07f9-4b4f-b4cb-30d6dbfba90d"), "Sila", new DateTime(2019, 2, 2, 14, 7, 2, 358, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sionti" },
                    { new Guid("ba9c8a89-d52c-4407-9b81-b308f0f7301d"), "Nick", new DateTime(2019, 2, 2, 14, 7, 2, 358, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halkidakis" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreationDate", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2d9bbb18-6807-43a5-b3ca-3520102c0c1e"), new DateTime(2019, 2, 2, 14, 7, 2, 356, DateTimeKind.Local), "", "C#" },
                    { new Guid("0aa59d45-5544-481e-a47f-9035e4d087e2"), new DateTime(2019, 2, 2, 14, 7, 2, 357, DateTimeKind.Local), "", "VB.NET" },
                    { new Guid("dcb6d0f4-a022-45de-91da-684529af59ae"), new DateTime(2019, 2, 2, 14, 7, 2, 357, DateTimeKind.Local), "", "ASP.NET MVC" },
                    { new Guid("a8f3caf7-1558-4227-add5-e8d8eba086d7"), new DateTime(2019, 2, 2, 14, 7, 2, 357, DateTimeKind.Local), "", "ASP.NET Core MVC" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("6e1ad796-006d-49e2-818a-e658c1d3c7ef"), new Guid("2d9bbb18-6807-43a5-b3ca-3520102c0c1e") },
                    { new Guid("db0a2230-07f9-4b4f-b4cb-30d6dbfba90d"), new Guid("2d9bbb18-6807-43a5-b3ca-3520102c0c1e") },
                    { new Guid("ba9c8a89-d52c-4407-9b81-b308f0f7301d"), new Guid("2d9bbb18-6807-43a5-b3ca-3520102c0c1e") },
                    { new Guid("6e1ad796-006d-49e2-818a-e658c1d3c7ef"), new Guid("0aa59d45-5544-481e-a47f-9035e4d087e2") },
                    { new Guid("db0a2230-07f9-4b4f-b4cb-30d6dbfba90d"), new Guid("0aa59d45-5544-481e-a47f-9035e4d087e2") },
                    { new Guid("6e1ad796-006d-49e2-818a-e658c1d3c7ef"), new Guid("dcb6d0f4-a022-45de-91da-684529af59ae") },
                    { new Guid("6e1ad796-006d-49e2-818a-e658c1d3c7ef"), new Guid("a8f3caf7-1558-4227-add5-e8d8eba086d7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillId",
                table: "EmployeeSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
