using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanySelfService.Pet.Migrations
{
    /// <inheritdoc />
    public partial class AddBuildingObjectsAndPasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessPasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BuildingObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IssuedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RevokedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IssuedByUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessPasses_BuildingObjects_BuildingObjectId",
                        column: x => x.BuildingObjectId,
                        principalTable: "BuildingObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessPasses_Users_IssuedByUserId",
                        column: x => x.IssuedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessPasses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessPasses_BuildingObjectId",
                table: "AccessPasses",
                column: "BuildingObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessPasses_IssuedByUserId",
                table: "AccessPasses",
                column: "IssuedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessPasses_UserId",
                table: "AccessPasses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessPasses");

            migrationBuilder.DropTable(
                name: "BuildingObjects");
        }
    }
}
