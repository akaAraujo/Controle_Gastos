using Controle_Gastos.Data;
using Controle_Gastos.DTO;
using Controle_Gastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Controle_Gastos.Controllers
{

    [ApiController]

    [Route("api/pessoas")]

    public class PessoaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PessoaController(AppDbContext context)
        {
            _context = context;
        }

        // Lista todas as pessoas cadastradas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Busca todas as pessoas cadastradas no banco de dados
            var pessoas = await _context.Pessoas.ToListAsync();

            // Retorna os dados e o código HTTP 200
            return Ok(pessoas);
        }

        // Pesquisa a pessoa pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Realiza a pesquisa da pessoa pelo ID
            var pessoa = await _context.Pessoas.FindAsync(id);

            // Verifica o retorno, caso a pessoa não seja encotnrada é retornado o código HTTP 400
            if(pessoa == null)
                return NotFound("Pessoa não encontrada");

            // Retorna os dados da pessoa e o código HTTP 200
            return Ok(pessoa);
        }

        // Cria o registro da pessoa
        [HttpPost]
        public async Task<IActionResult> Create(CreatePessoaDTO dto)
        {
            // Converte os dados do DTO para o objeto Pessoa
            var pessoa = new Pessoa
            {
                Nome = dto.Nome,
                Idade = dto.Idade
            };

            // Adiciona a pessoa e persiste o cadastro no banco de dados
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            // Retorna o código HTTP 201
            return CreatedAtAction(nameof(GetById), new {id = pessoa.Id}, pessoa);
        }

        // Realiza a atualização do registro da pessoa
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreatePessoaDTO dto)
        {

            var pessoa = await _context.Pessoas.FindAsync(id);

            // Verifica o resultado, caso o retorno seja Null é devolvido o código HTTP 404
            if (pessoa == null)
                return NotFound("Pessoa não encontrada!");

            // Realiza a alteração nos dados da pessoa
            pessoa.Nome = dto.Nome;
            pessoa.Idade = dto.Idade;

            // Realiza o update no cadastro da pessoa no banco de dados
            await _context.SaveChangesAsync();

            // Retorna o código HTTP 200
            return Ok(pessoa);
        }

        // Deleta o registro do cadastro de pessoa
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Consulta a pessoa pelo ID
            var pessoa = _context.Pessoas.Find(id);

            // Caso a consulta retorne Null é retornado o código HTTP 404
            if (pessoa == null)
                return NotFound("Pessoa não encontrada!");

            // Remove o registro da pessoa do banco de dados
            // As movimentações também serão removidas devido ao DeleteBehavior.Cascade
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

}