using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_34_GymWebsite_MVC_Core.Migrations
{
    public partial class UsersAddInductionAndJoiningDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InductionCompleted",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InductionCompleted",
                table: "Users");
        }
    }
}
