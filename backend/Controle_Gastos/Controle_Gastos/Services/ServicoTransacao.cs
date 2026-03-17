using Controle_Gastos.Data;
using Controle_Gastos.Models;

namespace Controle_Gastos.Services
{
    public class ServicoTransacao
    {
        private readonly AppDbContext _appDbContext;

        public ServicoTransacao(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Transacao> Create(Transacao transacao)
        {
            // Variável para receber o ID da pessoa utilizada no lançamento da transação
            var pessoa = await _appDbContext.Pessoas.FindAsync(transacao.IdPessoa);

            // Verifica a pessoa, caso o resultado seja NULL uma exceção é lançada
            if (pessoa == null)
                throw new Exception("Pessoa não encontrada");

            // Variável para receber o ID da categoria utilizada no lançamento da transação
            var categoria = await _appDbContext.Categorias.FindAsync(transacao.IdCategoria);

            // Verifica a categoria, caso o retorno seja NULL uma exceção é lançada
            if (categoria == null)
                throw new Exception("Categoria não encontrada");

            // Verifica a idade do usuário para identificar se ele pode lançar a movimentação
            if (pessoa.Idade < 18 && transacao.Tipo == TipoTransacao.Receita)
                throw new Exception("Menores de idade não podem registrar receitas.");

            // Verificações para identificar se os tipos de despesas e as finalidades são condizentes
            if (transacao.Tipo == TipoTransacao.Despesa && categoria.Finalidade == FinalidadeCategoria.Receita)
                throw new Exception("A categoria não permite despesas!");

            if (transacao.Tipo == TipoTransacao.Receita && categoria.Finalidade == FinalidadeCategoria.Despesa)
                throw new Exception("A categoria não permite receitas!");

            _appDbContext.Transacoes.Add(transacao);
            await _appDbContext.SaveChangesAsync();

            return transacao;
        }
    } 
}
