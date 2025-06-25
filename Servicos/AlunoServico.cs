using ExercicioMVC.Models;

namespace ExercicioMVC.Servicos
{
    public class AlunoServico : IAlunoServico
    {
        private readonly IAlunoRepositorio _repositorio;

        public AlunoServico(IAlunoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public int CriarAluno(string nome, int idade, string turma)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome obrigatório");
            if (idade <= 0)
                throw new ArgumentException("Idade inválida");

            var aluno = new Aluno { Nome = nome, Idade = idade, Turma = turma };
            return _repositorio.Inserir(aluno);
        }

        public IEnumerable<Aluno> ListarAlunos() => _repositorio.BuscarTodos();

        public void AtualizarAluno(int id, string nome, int idade, string turma)
        {
            if (id <= 0) throw new ArgumentException("Id inválido");
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome obrigatório");
            if (idade <= 0) throw new ArgumentException("Idade inválida");

            var aluno = new Aluno { Id = id, Nome = nome, Idade = idade, Turma = turma };
            _repositorio.Atualizar(aluno);
        }

        public void RemoverAluno(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido");
            _repositorio.Excluir(id);
        }
    }
}
