using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ChangesLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("6e1ad796-006d-49e2-818a-e658c1d3c7ef"), new Guid("0aa59d45-5544-481e-a47f-9035e4d087e2") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("6e1ad796-006d-49e2-818a-e658c1d3c7ef"), new Guid("2d9bbb18-6807-43a5-b3ca-3520102c0c1e") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("6e1ad796-006d-49e2-818a-e658c1d3c7ef"), new Guid("a8f3caf7-1558-4227-add5-e8d8eba086d7") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("6e1ad796-006d-49e2-818a-e658c1d3c7ef"), new Guid("dcb6d0f4-a022-45de-91da-684529af59ae") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("ba9c8a89-d52c-4407-9b81-b308f0f7301d"), new Guid("2d9bbb18-6807-43a5-b3ca-3520102c0c1e") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("db0a2230-07f9-4b4f-b4cb-30d6dbfba90d"), new Guid("0aa59d45-5544-481e-a47f-9035e4d087e2") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("db0a2230-07f9-4b4f-b4cb-30d6dbfba90d"), new Guid("2d9bbb18-6807-43a5-b3ca-3520102c0c1e") });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("6e1ad796-006d-49e2-818a-e658c1d3c7ef"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ba9c8a89-d52c-4407-9b81-b308f0f7301d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("db0a2230-07f9-4b4f-b4cb-30d6dbfba90d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("0aa59d45-5544-481e-a47f-9035e4d087e2"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2d9bbb18-6807-43a5-b3ca-3520102c0c1e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a8f3caf7-1558-4227-add5-e8d8eba086d7"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("dcb6d0f4-a022-45de-91da-684529af59ae"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeChangesLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogStamp = table.Column<DateTime>(nullable: false),
                    Entity = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeChangesLogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "HiringDate", "LastSkillChangeDate", "Surname" },
                values: new object[,]
                {
                    { new Guid("8a2d2062-17df-4ed1-92ea-cf4969cc65a7"), "Orestis", new DateTime(2019, 2, 7, 18, 54, 25, 723, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koskoletos" },
                    { new Guid("5fb4d3e0-d6ec-4eef-afd4-40c760196ac6"), "John", new DateTime(2019, 2, 7, 18, 54, 25, 723, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe" },
                    { new Guid("7372bc8b-1492-4fe8-8370-fba1e40278b6"), "Jane", new DateTime(2019, 2, 7, 18, 54, 25, 723, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreationDate", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("e19105bc-f055-4a41-8329-d2eceab90ae3"), new DateTime(2019, 2, 7, 18, 54, 25, 722, DateTimeKind.Local), "Programming language", "C#" },
                    { new Guid("c5826822-59e7-4380-9189-a08adc5b6b8a"), new DateTime(2019, 2, 7, 18, 54, 25, 723, DateTimeKind.Local), "Programming language", "VB.NET" },
                    { new Guid("c69cff2f-74e6-4f47-bc74-6658167491ae"), new DateTime(2019, 2, 7, 18, 54, 25, 723, DateTimeKind.Local), "Framework", "ASP.NET MVC" },
                    { new Guid("3faa7f05-b454-4f12-acbc-87f26978f7a4"), new DateTime(2019, 2, 7, 18, 54, 25, 723, DateTimeKind.Local), "Framework", "ASP.NET Core MVC" },
                    { new Guid("1cfcc2fe-20e9-420d-b331-dc045ebb9c5a"), new DateTime(2019, 2, 7, 18, 54, 25, 723, DateTimeKind.Local), "Programming language", "Python" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("8a2d2062-17df-4ed1-92ea-cf4969cc65a7"), new Guid("e19105bc-f055-4a41-8329-d2eceab90ae3") },
                    { new Guid("5fb4d3e0-d6ec-4eef-afd4-40c760196ac6"), new Guid("e19105bc-f055-4a41-8329-d2eceab90ae3") },
                    { new Guid("7372bc8b-1492-4fe8-8370-fba1e40278b6"), new Guid("e19105bc-f055-4a41-8329-d2eceab90ae3") },
                    { new Guid("8a2d2062-17df-4ed1-92ea-cf4969cc65a7"), new Guid("c5826822-59e7-4380-9189-a08adc5b6b8a") },
                    { new Guid("5fb4d3e0-d6ec-4eef-afd4-40c760196ac6"), new Guid("c5826822-59e7-4380-9189-a08adc5b6b8a") },
                    { new Guid("8a2d2062-17df-4ed1-92ea-cf4969cc65a7"), new Guid("c69cff2f-74e6-4f47-bc74-6658167491ae") },
                    { new Guid("8a2d2062-17df-4ed1-92ea-cf4969cc65a7"), new Guid("3faa7f05-b454-4f12-acbc-87f26978f7a4") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeChangesLogs");

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("5fb4d3e0-d6ec-4eef-afd4-40c760196ac6"), new Guid("c5826822-59e7-4380-9189-a08adc5b6b8a") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("5fb4d3e0-d6ec-4eef-afd4-40c760196ac6"), new Guid("e19105bc-f055-4a41-8329-d2eceab90ae3") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("7372bc8b-1492-4fe8-8370-fba1e40278b6"), new Guid("e19105bc-f055-4a41-8329-d2eceab90ae3") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("8a2d2062-17df-4ed1-92ea-cf4969cc65a7"), new Guid("3faa7f05-b454-4f12-acbc-87f26978f7a4") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("8a2d2062-17df-4ed1-92ea-cf4969cc65a7"), new Guid("c5826822-59e7-4380-9189-a08adc5b6b8a") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("8a2d2062-17df-4ed1-92ea-cf4969cc65a7"), new Guid("c69cff2f-74e6-4f47-bc74-6658167491ae") });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumns: new[] { "EmployeeId", "SkillId" },
                keyValues: new object[] { new Guid("8a2d2062-17df-4ed1-92ea-cf4969cc65a7"), new Guid("e19105bc-f055-4a41-8329-d2eceab90ae3") });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("1cfcc2fe-20e9-420d-b331-dc045ebb9c5a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("5fb4d3e0-d6ec-4eef-afd4-40c760196ac6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7372bc8b-1492-4fe8-8370-fba1e40278b6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("8a2d2062-17df-4ed1-92ea-cf4969cc65a7"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("3faa7f05-b454-4f12-acbc-87f26978f7a4"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c5826822-59e7-4380-9189-a08adc5b6b8a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c69cff2f-74e6-4f47-bc74-6658167491ae"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e19105bc-f055-4a41-8329-d2eceab90ae3"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string));

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
        }
    }
}
