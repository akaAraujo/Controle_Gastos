using Controle_Gastos.Models;
using System.ComponentModel.DataAnnotations;

namespace Controle_Gastos.DTO
{
    // DTO usado para criar uma categoria
    public class CreateCategoriaDTO
    {
        // Informa que a informação é obrigatória
        [Required]
        // Define o tamanho máximo para a descrição da categoria
        [StringLength(400)]
        // Descrição da categoria
        public string Descricao { get; set; }

        // Finalidade da categoria
        public FinalidadeCategoria Finalidade { get; set; }
    }
}
