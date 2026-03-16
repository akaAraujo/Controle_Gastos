namespace Controle_Gastos.Models
{
    public class Pessoa
    {
        // Identificador único para a pessoa
        public int Id { get; set; }

        // Nome da pessoa cadastrada
        public string Nome { get; set; }

        // Idade da pessoa
        public int Idade { get; set; }

        // Lista de transações
        public List<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
