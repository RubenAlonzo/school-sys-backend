using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_schedules_to_student_teacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Schedules_ScheduleEntityId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ScheduleEntityId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ScheduleEntityId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "ScheduleEntityStudentEntity",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleEntityStudentEntity", x => new { x.ScheduleId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ScheduleEntityStudentEntity_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleEntityStudentEntity_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntityStudentEntity_StudentsId",
                table: "ScheduleEntityStudentEntity",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleEntityStudentEntity");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleEntityId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ScheduleEntityId",
                table: "Students",
                column: "ScheduleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Schedules_ScheduleEntityId",
                table: "Students",
                column: "ScheduleEntityId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }
    }
}
