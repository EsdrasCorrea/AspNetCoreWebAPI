﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    DataInit = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataInit = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataInit = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PreRequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PreRequisitoId",
                        column: x => x.PreRequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataInit = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInit", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(1081), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(3869), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(3967), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(3977), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(3986), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(3998), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(4008), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistema de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInit", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 825, DateTimeKind.Local).AddTicks(3765), "Lauro", 1, "Oliveira", "" },
                    { 2, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 826, DateTimeKind.Local).AddTicks(5608), "Roberto", 2, "Soares", "" },
                    { 3, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 826, DateTimeKind.Local).AddTicks(5700), "Ronaldo", 3, "Marconi", "" },
                    { 4, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 826, DateTimeKind.Local).AddTicks(5705), "Rodrigo", 4, "Carvalho", "" },
                    { 5, true, null, new DateTime(2023, 7, 6, 15, 47, 4, 826, DateTimeKind.Local).AddTicks(5707), "Alexandre", 5, "Montanha", "" }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 2 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInit", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7072), null },
                    { 4, 5, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7098), null },
                    { 2, 5, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7081), null },
                    { 1, 5, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7069), null },
                    { 7, 4, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7122), null },
                    { 6, 4, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7113), null },
                    { 5, 4, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7100), null },
                    { 4, 4, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7096), null },
                    { 1, 4, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7035), null },
                    { 7, 3, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7120), null },
                    { 5, 5, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7102), null },
                    { 6, 3, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7109), null },
                    { 7, 2, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7118), null },
                    { 6, 2, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7107), null },
                    { 3, 2, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7086), null },
                    { 2, 2, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7075), null },
                    { 1, 2, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(6144), null },
                    { 7, 1, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7116), null },
                    { 6, 1, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7105), null },
                    { 4, 1, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7094), null },
                    { 3, 1, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7083), null },
                    { 3, 3, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7089), null },
                    { 7, 5, null, new DateTime(2023, 7, 6, 15, 47, 4, 831, DateTimeKind.Local).AddTicks(7124), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PreRequisitoId",
                table: "Disciplinas",
                column: "PreRequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
