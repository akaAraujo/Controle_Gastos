using System.ComponentModel.DataAnnotations;

namespace Controle_Gastos.DTO
{
    // DTO usado para receber dados ao criar uma nova pessoa
    public class CreatePessoaDTO
    {
        // Required indica que o campo é obrigatório
        [Required]
        // Comando que limita o tamanho máximo do texto
        [StringLength(200)]
        // Nome da pessoa
        public string Nome { get; set; }

        // Define um limite para a idade da pessoa cadastrada, impedindo valores negatívos ou idades irreais
        [Range(0, 120)]
        // Idade da pessoa
        public int Idade { get; set; }
    }
}
