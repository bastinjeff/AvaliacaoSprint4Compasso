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
		string StringConexao;
		public DbSet<Cidades> cidades { get; set; }
		public DbSet<Funcionarios> funcionarios { get; set; }

		public CidadesContext(string StringConexao)
		{
			this.StringConexao = StringConexao;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(StringConexao);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CidadesConfiguration());

		}
	}
}
