using ExercicioMVC.Models;
using System;

public interface IAlunoServico
{
    int CriarAluno(string nome, int idade, string turma);
    IEnumerable<Aluno> ListarAlunos();
    void AtualizarAluno(int id, string nome, int idade, string turma);
    void RemoverAluno(int id);
}
