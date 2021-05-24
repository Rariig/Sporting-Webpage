using Microsoft.EntityFrameworkCore.Migrations;

namespace SportEU.Infra.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Person_Id",
                table: "Athletes");

            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Person_Id",
                table: "Coaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupAssignments",
                table: "GroupAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Athletes",
                table: "Athletes");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "GroupAssignments",
                newName: "GroupAssignment");

            migrationBuilder.RenameTable(
                name: "Coaches",
                newName: "Coach");

            migrationBuilder.RenameTable(
                name: "Athletes",
                newName: "Athlete");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupAssignment",
                table: "GroupAssignment",
                columns: new[] { "GroupId", "AthleteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coach",
                table: "Coach",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Athlete",
                table: "Athlete",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Athlete_Person_Id",
                table: "Athlete",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Person_Id",
                table: "Coach",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athlete_Person_Id",
                table: "Athlete");

            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Person_Id",
                table: "Coach");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupAssignment",
                table: "GroupAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coach",
                table: "Coach");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Athlete",
                table: "Athlete");

            migrationBuilder.RenameTable(
                name: "GroupAssignment",
                newName: "GroupAssignments");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "Coach",
                newName: "Coaches");

            migrationBuilder.RenameTable(
                name: "Athlete",
                newName: "Athletes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupAssignments",
                table: "GroupAssignments",
                columns: new[] { "GroupId", "AthleteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Athletes",
                table: "Athletes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Person_Id",
                table: "Athletes",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Person_Id",
                table: "Coaches",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
