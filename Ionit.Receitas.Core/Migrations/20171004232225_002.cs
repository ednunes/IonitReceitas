using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ionit.Receitas.Core.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receita_ReceitaCategoria_CategoriaId",
                table: "Receita");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaCurtida_Receita_ReceitaId",
                table: "ReceitaCurtida");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaIngrediente_Receita_ReceitaId",
                table: "ReceitaIngrediente");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaTag_Receita_ReceitaId",
                table: "ReceitaTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceitaCategoria",
                table: "ReceitaCategoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receita",
                table: "Receita");

            migrationBuilder.RenameTable(
                name: "ReceitaCategoria",
                newName: "Categorias");

            migrationBuilder.RenameTable(
                name: "Receita",
                newName: "Receitas");

            migrationBuilder.RenameIndex(
                name: "IX_Receita_CategoriaId",
                table: "Receitas",
                newName: "IX_Receitas_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receitas",
                table: "Receitas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaCurtida_Receitas_ReceitaId",
                table: "ReceitaCurtida",
                column: "ReceitaId",
                principalTable: "Receitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaIngrediente_Receitas_ReceitaId",
                table: "ReceitaIngrediente",
                column: "ReceitaId",
                principalTable: "Receitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Categorias_CategoriaId",
                table: "Receitas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaTag_Receitas_ReceitaId",
                table: "ReceitaTag",
                column: "ReceitaId",
                principalTable: "Receitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaCurtida_Receitas_ReceitaId",
                table: "ReceitaCurtida");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaIngrediente_Receitas_ReceitaId",
                table: "ReceitaIngrediente");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Categorias_CategoriaId",
                table: "Receitas");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaTag_Receitas_ReceitaId",
                table: "ReceitaTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receitas",
                table: "Receitas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Receitas",
                newName: "Receita");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "ReceitaCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_Receitas_CategoriaId",
                table: "Receita",
                newName: "IX_Receita_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receita",
                table: "Receita",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceitaCategoria",
                table: "ReceitaCategoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_ReceitaCategoria_CategoriaId",
                table: "Receita",
                column: "CategoriaId",
                principalTable: "ReceitaCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaCurtida_Receita_ReceitaId",
                table: "ReceitaCurtida",
                column: "ReceitaId",
                principalTable: "Receita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaIngrediente_Receita_ReceitaId",
                table: "ReceitaIngrediente",
                column: "ReceitaId",
                principalTable: "Receita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaTag_Receita_ReceitaId",
                table: "ReceitaTag",
                column: "ReceitaId",
                principalTable: "Receita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
