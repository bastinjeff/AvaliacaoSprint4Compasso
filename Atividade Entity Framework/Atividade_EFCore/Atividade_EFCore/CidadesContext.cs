using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_EFCore
{
	class CidadesContext : DbContext
	{
		public DbSet<Cidades> cidades { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Database=Cidades;Integrated Security=True;Connect Timeout=5;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Cidades>().ToTable("Cidades");

			modelBuilder.Entity<Cidades>()
				.Property(Cidade => Cidade.Id)
				.HasColumnType("guid")
				.IsRequired();

			modelBuilder.Entity<Cidades>()
				.Property(Cidade => Cidade.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(max)")
				.IsRequired();

			modelBuilder.Entity<Cidades>()
				.Property(Cidade => Cidade.Populacao)
				.HasColumnName("Populacao")
				.HasColumnType("int");

			modelBuilder.Entity<Cidades>()
				.Property(Cidade => Cidade.TaxaCriminalidade)
				.HasColumnType("float");

			modelBuilder.Entity<Cidades>()
				.Property(Cidade => Cidade.ImpostoSobreProduto)
				.HasColumnType("float");

			modelBuilder.Entity<Cidades>()
				.Property(Cidade => Cidade.EstadoCalamidade)
				.HasColumnType("bit");

		}
	}
}
