using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiring.Infra.Data.Migrations
{
    public partial class AdicaoDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividade_Vaga_VagaId",
                table: "Atividade");

            migrationBuilder.DropForeignKey(
                name: "FK_Desejavel_Vaga_VagaId",
                table: "Desejavel");

            migrationBuilder.DropForeignKey(
                name: "FK_Obrigatorio_Vaga_VagaId",
                table: "Obrigatorio");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Vaga",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_Vaga_VagaId",
                table: "Atividade",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Desejavel_Vaga_VagaId",
                table: "Desejavel",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obrigatorio_Vaga_VagaId",
                table: "Obrigatorio",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividade_Vaga_VagaId",
                table: "Atividade");

            migrationBuilder.DropForeignKey(
                name: "FK_Desejavel_Vaga_VagaId",
                table: "Desejavel");

            migrationBuilder.DropForeignKey(
                name: "FK_Obrigatorio_Vaga_VagaId",
                table: "Obrigatorio");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Vaga");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_Vaga_VagaId",
                table: "Atividade",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Desejavel_Vaga_VagaId",
                table: "Desejavel",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Obrigatorio_Vaga_VagaId",
                table: "Obrigatorio",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
