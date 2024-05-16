using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Migrations
{
    public partial class INITIAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMembers_ProjectRoles_DesignationId",
                table: "ProjectMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMembers_Projects_ProjectId",
                table: "ProjectMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMembers_Users_UserId",
                table: "ProjectMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskProjects_Tasks_TaskId",
                table: "TaskProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskProjects_Users_UserId",
                table: "TaskProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskProjects",
                table: "TaskProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectRoles",
                table: "ProjectRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectMembers",
                table: "ProjectMembers");

            migrationBuilder.RenameTable(
                name: "TaskProjects",
                newName: "TaskUser");

            migrationBuilder.RenameTable(
                name: "ProjectRoles",
                newName: "Designation");

            migrationBuilder.RenameTable(
                name: "ProjectMembers",
                newName: "ProjectUser");

            migrationBuilder.RenameIndex(
                name: "IX_TaskProjects_UserId",
                table: "TaskUser",
                newName: "IX_TaskUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskProjects_TaskId",
                table: "TaskUser",
                newName: "IX_TaskUser_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectMembers_UserId",
                table: "ProjectUser",
                newName: "IX_ProjectUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectMembers_ProjectId",
                table: "ProjectUser",
                newName: "IX_ProjectUser_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectMembers_DesignationId",
                table: "ProjectUser",
                newName: "IX_ProjectUser_DesignationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskUser",
                table: "TaskUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Designation",
                table: "Designation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectUser",
                table: "ProjectUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectClients", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Designation_DesignationId",
                table: "ProjectUser",
                column: "DesignationId",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Projects_ProjectId",
                table: "ProjectUser",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Users_UserId",
                table: "ProjectUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUser_Tasks_TaskId",
                table: "TaskUser",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUser_Users_UserId",
                table: "TaskUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Designation_DesignationId",
                table: "ProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Projects_ProjectId",
                table: "ProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Users_UserId",
                table: "ProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskUser_Tasks_TaskId",
                table: "TaskUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskUser_Users_UserId",
                table: "TaskUser");

            migrationBuilder.DropTable(
                name: "ProjectClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskUser",
                table: "TaskUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectUser",
                table: "ProjectUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Designation",
                table: "Designation");

            migrationBuilder.RenameTable(
                name: "TaskUser",
                newName: "TaskProjects");

            migrationBuilder.RenameTable(
                name: "ProjectUser",
                newName: "ProjectMembers");

            migrationBuilder.RenameTable(
                name: "Designation",
                newName: "ProjectRoles");

            migrationBuilder.RenameIndex(
                name: "IX_TaskUser_UserId",
                table: "TaskProjects",
                newName: "IX_TaskProjects_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskUser_TaskId",
                table: "TaskProjects",
                newName: "IX_TaskProjects_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectUser_UserId",
                table: "ProjectMembers",
                newName: "IX_ProjectMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectUser_ProjectId",
                table: "ProjectMembers",
                newName: "IX_ProjectMembers_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectUser_DesignationId",
                table: "ProjectMembers",
                newName: "IX_ProjectMembers_DesignationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskProjects",
                table: "TaskProjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectMembers",
                table: "ProjectMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectRoles",
                table: "ProjectRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMembers_ProjectRoles_DesignationId",
                table: "ProjectMembers",
                column: "DesignationId",
                principalTable: "ProjectRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMembers_Projects_ProjectId",
                table: "ProjectMembers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMembers_Users_UserId",
                table: "ProjectMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskProjects_Tasks_TaskId",
                table: "TaskProjects",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskProjects_Users_UserId",
                table: "TaskProjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
