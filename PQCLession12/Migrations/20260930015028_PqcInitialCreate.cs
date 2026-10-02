using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PQCLession12.Migrations
{
    /// <inheritdoc />
    public partial class PqcInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PqcCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqcName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PqcStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    PqcCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PqcCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PqcProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqcName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PqcImage = table.Column<string>(type: "varchar(150)", nullable: true),
                    PqcPrice = table.Column<float>(type: "real", nullable: false),
                    PqcSalePrice = table.Column<float>(type: "real", nullable: false),
                    PqcStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    PqcDescriptions = table.Column<string>(type: "ntext", maxLength: 1000, nullable: true),
                    PqcCategoryId = table.Column<int>(type: "int", nullable: false),
                    PqcCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PqcProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PqcProduct_PqcCategory_PqcCategoryId",
                        column: x => x.PqcCategoryId,
                        principalTable: "PqcCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PqcProduct_PqcCategoryId",
                table: "PqcProduct",
                column: "PqcCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PqcProduct");

            migrationBuilder.DropTable(
                name: "PqcCategory");
        }
    }
}
