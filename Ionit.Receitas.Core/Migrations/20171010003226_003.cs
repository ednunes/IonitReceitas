using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ionit.Receitas.Core.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaIngrediente_Receitas_ReceitaId",
                table: "ReceitaIngrediente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceitaIngrediente",
                table: "ReceitaIngrediente");

            migrationBuilder.RenameTable(
                name: "ReceitaIngrediente",
                newName: "Ingredientes");

            migrationBuilder.RenameIndex(
                name: "IX_ReceitaIngrediente_ReceitaId",
                table: "Ingredientes",
                newName: "IX_Ingredientes_ReceitaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredientes",
                table: "Ingredientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Receitas_ReceitaId",
                table: "Ingredientes",
                column: "ReceitaId",
                principalTable: "Receitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Receitas_ReceitaId",
                table: "Ingredientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredientes",
                table: "Ingredientes");

            migrationBuilder.RenameTable(
                name: "Ingredientes",
                newName: "ReceitaIngrediente");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredientes_ReceitaId",
                table: "ReceitaIngrediente",
                newName: "IX_ReceitaIngrediente_ReceitaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceitaIngrediente",
                table: "ReceitaIngrediente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaIngrediente_Receitas_ReceitaId",
                table: "ReceitaIngrediente",
                column: "ReceitaId",
                principalTable: "Receitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
