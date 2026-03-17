using Controle_Gastos.Models;
using Microsoft.EntityFrameworkCore;

namespace Controle_Gastos.Data
{
    public class AppDbContext : DbContext
    {
        // Cria a tabela de Pessoas no banco de dados
        public DbSet<Pessoa> Pessoas { get; set; }
        // Cria a tabela de Categorias no banco de dados
        public DbSet<Categoria> Categorias { get; set; }
        // Cria a tabela de Transações no banco de dados
        public DbSet<Transacao> Transacoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        // Sobrescreve a função de criação do banco de dados para que sejam realizadas alterações no modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                // Definindo cardinalidade, uma pessoa tem muitas transações
                .HasMany(p => p.Transacoes)
                // Definindo que cada transação pertence a uma pessoa
                .WithOne(t => t.Pessoa)
                // Define que o campo IdPessoa na tabela de transações é uma FK
                .HasForeignKey(t => t.IdPessoa)
                // Faz com que ao deletar uma pessoa as transações também sejam apagadas
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento Categoria -> Transações
            modelBuilder.Entity<Transacao>()
                // Define que cada transação tem uma categoria
                .HasOne(t => t.Categoria)
                // Define que uma categoria tem várias transações
                .WithMany(c => c.Transacoes)
                // Define o IdCategoria como uma FK
                .HasForeignKey(t => t.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
