using Controle_Gastos.Data;
using Controle_Gastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controle_Gastos.Controllers
{
    [ApiController]
    [Route("api/relatorios")]

    public class RelatoriosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelatoriosController(AppDbContext context)
        {
            _context = context;
        }

        // Relatório de totais por pessoa
        [HttpGet("pessoas")]
        public async Task<IActionResult> TotalPorPessoa()
        {
            // Busca todas as pessoas e calcula os totais de transações
            var data = await _context.Pessoas
                .Select(p => new
                {
                    PessoaId = p.Id,
                    PessoaNome = p.Nome,

                    // Soma das receitas das pessoas
                    TotalRenda = (decimal)(p.Transacoes
                        .Where(t => t.Tipo == TipoTransacao.Receita)
                        .Sum(t => (double?)t.Valor) ?? 0),
                    
                    // Soma das despesas das pessoas
                    TotalDespesas = (decimal)(p.Transacoes
                        .Where(t => t.Tipo == TipoTransacao.Despesa)
                        .Sum(t => (double?)t.Valor) ?? 0)
                }).ToListAsync();

            // Calcula o saldo (receitas - despesas)
            var resultado = data.Select(p => new
            {
                p.PessoaId,
                p.PessoaNome,
                p.TotalRenda,
                p.TotalDespesas,

                // Calcula o saldo final da pessoa
                Balanco = p.TotalRenda - p.TotalDespesas
            }).ToList();

            // Totais gerais de todas as pessoas
            var totalRecebido = resultado.Sum(x => x.TotalRenda);
            var totalDespesas = resultado.Sum(x => x.TotalDespesas);

            var resposta = new
            {
                Pessoas = resultado,

                Totais = new
                {
                    TotalRenda = totalRecebido,
                    TotalDespesas = totalDespesas,
                    Balanco = totalRecebido - totalDespesas
                }
            };

            return Ok(resposta);
        }

        // Gastos totais por categoria
        [HttpGet("categorias")]
        public async Task<IActionResult> TotaisPorCategoria()
        {
            var dados = await _context.Categorias
                .Select(c => new
                {
                    CategoriaId = c.Id,
                    CategoriaDescricao = c.Descricao,

                    TotalReceita = (decimal)(_context.Transacoes
                        .Where(t => t.IdCategoria == c.Id && t.Tipo == TipoTransacao.Receita)
                        .Sum(t => (double?)t.Valor) ?? 0),

                    TotalDespesas = (decimal)(_context.Transacoes
                        .Where(t => t.IdCategoria == c.Id && t.Tipo == TipoTransacao.Despesa)
                        .Sum(t => (double?)t.Valor) ?? 0)
                }).ToListAsync();

            var resultado = dados.Select(c => new
            {
                c.CategoriaId,
                c.CategoriaDescricao,
                c.TotalReceita,
                c.TotalDespesas,

                Balanco = c.TotalReceita - c.TotalDespesas
            }).ToList();

            var totalReceita = resultado.Sum(x => x.TotalReceita);
            var totalDespesa = resultado.Sum(x => x.TotalDespesas);

            var resposta = new
            {
                Categorias = resultado,

                Totais = new
                {
                    TotalReceita = totalReceita,
                    TotalDespesas = totalDespesa,
                    Balanco = totalReceita - totalDespesa
                }
            };

            return Ok(resposta);
        }

    }
}
