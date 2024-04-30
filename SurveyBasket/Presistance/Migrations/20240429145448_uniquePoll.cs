﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class uniquePoll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Polls_Title",
                table: "Polls");

            migrationBuilder.CreateIndex(
                name: "IX_Polls_Title",
                table: "Polls",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Polls_Title",
                table: "Polls");

            migrationBuilder.CreateIndex(
                name: "IX_Polls_Title",
                table: "Polls",
                column: "Title");
        }
    }
}
