using ExercicioMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ExercicioMVC.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly string _connectionString;

        public AlunoRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public int Inserir(Aluno aluno)
        {
            const string sql = @"
                INSERT INTO Alunos (Nome, Idade, Turma)
                VALUES (@Nome, @Idade, @Turma);
                SELECT SCOPE_IDENTITY();";
            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(sql, connection) { CommandType = CommandType.Text };
            command.Parameters.AddWithValue("@Nome", aluno.Nome);
            command.Parameters.AddWithValue("@Idade", aluno.Idade);
            command.Parameters.AddWithValue("@Turma", aluno.Turma);
            connection.Open();
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public IEnumerable<Aluno> BuscarTodos()
        {
            var lista = new List<Aluno>();
            const string sql = "SELECT Id, Nome, Idade, Turma FROM Alunos";
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Aluno
                {
                    Id = (int)reader["Id"],
                    Nome = reader["Nome"].ToString()!,
                    Idade = (int)reader["Idade"],
                    Turma = reader["Turma"].ToString()!
                });
            }
            return lista;
        }

        public void Atualizar(Aluno aluno)
        {
            const string sql = @"
                UPDATE Alunos
                SET Nome=@Nome, Idade=@Idade, Turma=@Turma
                WHERE Id=@Id";
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", aluno.Nome);
            command.Parameters.AddWithValue("@Idade", aluno.Idade);
            command.Parameters.AddWithValue("@Turma", aluno.Turma);
            command.Parameters.AddWithValue("@Id", aluno.Id);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            const string sql = "DELETE FROM Alunos WHERE Id=@Id";
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}

