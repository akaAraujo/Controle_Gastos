using Controle_Gastos.Models;
using System.ComponentModel.DataAnnotations;

namespace Controle_Gastos.DTO
{
    // DTO usado para criar uma transação
    public class CreateTransacaoDTO
    {
        // Required indica que o campo é obrigatório

        [Required]
        // Comando que limita o tamanho máximo do texto
        [StringLength(400)]
        // Descrição da transação
        public string Descricao { get; set; }

        // Define que o valor precisa sempre ser positivo
        [Range(0.01, double.MaxValue)]
        // Valor da transação
        public decimal Valor { get; set; }

        // Tipo da transação
        public TipoTransacao Tipo { get; set; }

        // Id da categoria
        public int IdCategoria { get; set; }

        // Id da pessoa
        public int IdPessoa { get; set; }
    }
}
