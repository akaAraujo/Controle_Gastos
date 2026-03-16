using Controle_Gastos.Data;
using Controle_Gastos.DTO;
using Controle_Gastos.Models;
using Controle_Gastos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Controle_Gastos.Controllers
{

    [ApiController]
    [Route("api/transacoes")]

    public class TransacoesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ServicoTransacao _servico;

        public TransacoesController(AppDbContext context, ServicoTransacao servico)
        {
            _context = context;
            _servico = new ServicoTransacao(context);
        }

        // Lista as movimentações
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Consulta as movimentações
            var transacao = await _context.Transacoes
                // Carrega o relacionamento com a tabela de pessoas
                .Include(t => t.Pessoa)
                // Carrega o relacionamento com a tabela de categorias
                .Include(t => t.Categoria)
                .ToListAsync();

            return Ok(transacao);
        }

        // Cadastra a transação
        [HttpPost]
        public async Task<IActionResult> Create(CreateTransacaoDTO dto)
        {
            try
            {
                // Converte os dados do DTO para o objeto Transação
                var transacao = new Transacao
                {
                    Descricao = dto.Descricao,
                    Valor = dto.Valor,
                    Tipo = dto.Tipo,
                    IdCategoria = dto.IdCategoria,
                    IdPessoa = dto.IdPessoa
                };


                // Realiza a inserção dos dados no banco de dados
                var resultado = await _servico.Create(transacao);

                // Retorna a mensagem de sucesso com o código HTTP 200
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum problema será retornada uma exessão
                return BadRequest(ex.Message);
            }
        }
    }
}
