using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorWASM_SignalR.Server.Data.Migrations
{
    public partial class webAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecordDetails",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SA_SN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SA_PN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordDetails", x => x.No);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordDetails");
        }
    }
}
