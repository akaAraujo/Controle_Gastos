namespace Controle_Gastos.Models
{

    public class Transacao
    {
        //Identificador único para a transação
        public int Id { get; set; }

        // Descrição da transação cadastrada
        public string Descricao { get; set; }

        // Valor da transação lançada
        public decimal Valor { get; set; }

        // Tipo da transação
        public TipoTransacao Tipo {  get; set; }

        // Relacionamento com a categoria
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        // Relacionamento com a pessoa
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
