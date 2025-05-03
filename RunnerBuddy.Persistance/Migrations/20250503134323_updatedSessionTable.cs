using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunnerBuddy.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updatedSessionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "Sessions",
                newName: "PlannedDistance");

            migrationBuilder.AddColumn<float>(
                name: "ActualDistance",
                table: "Sessions",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AveragePace",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Sessions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualDistance",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "AveragePace",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "PlannedDistance",
                table: "Sessions",
                newName: "Distance");
        }
    }
}
