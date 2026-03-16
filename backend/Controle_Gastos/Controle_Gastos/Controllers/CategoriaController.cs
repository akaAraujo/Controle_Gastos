using Controle_Gastos.Data;
using Controle_Gastos.DTO;
using Controle_Gastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controle_Gastos.Controllers
{

    [ApiController]
    [Route("api/categorias")]

    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        // Lista as categorias
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Consulta todas as categorias cadastradas
            var categorias = await _context.Categorias.ToListAsync();

            // Retorna as categorias e o código HTTP 200
            return Ok(categorias);
        }

        // Cadastra as categorias
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoriaDTO dto)
        {
            // Converte os dados do DTO para o objeto Categoria
            var categoria = new Categoria
            {
                Descricao = dto.Descricao,
                Finalidade = dto.Finalidade
            };

            // Verifica se a descrição está preenchida, caso não esteja é retornado o código HTTP 400
            if (string.IsNullOrWhiteSpace(categoria.Descricao))
                return BadRequest("A descrição é obrigatória!");

            // Realiza a inserção da categoria no banco de dados
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            // Retorna o código HTTPS 200
            return Ok(categoria);
        }
    }
}
