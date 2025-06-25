using ExercicioMVC.Models;

public interface IAlunoRepositorio
{
    int Inserir(Aluno aluno);
    IEnumerable<Aluno> BuscarTodos();
    void Atualizar(Aluno aluno);
    void Excluir(int id);

}