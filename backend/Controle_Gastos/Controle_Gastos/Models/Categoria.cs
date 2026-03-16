namespace Controle_Gastos.Models
{

    public class Categoria
    {
        // Identificador único para a categoria
        public int Id { get; set; }

        // Descrição da categoria
        public string Descricao { get; set; }

        // Finalidade da categoria
        public FinalidadeCategoria Finalidade { get; set; }
    }
}
