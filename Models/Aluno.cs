using System.ComponentModel.DataAnnotations;

namespace ExercicioMVC.Models
{
    public class Aluno

    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Range(1, 120, ErrorMessage = "Idade deve ser entre 1 e 120")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "A turma é obrigatória")]
        public string Turma { get; set; }
    }
}