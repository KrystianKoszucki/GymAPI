using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymAPI.Migrations
{
    /// <inheritdoc />
    public partial class TrainingCreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CreatedById",
                table: "Trainings",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Users_CreatedById",
                table: "Trainings",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Users_CreatedById",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_CreatedById",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Trainings");
        }
    }
}
