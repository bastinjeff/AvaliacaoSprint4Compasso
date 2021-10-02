using Atividade_EFCore.Configuration;
using Atividade_EFCore.Models;
using Atividade_EFCore.Views;
using Microsoft.EntityFrameworkCore;
using Atividade_EFCore.Stored_Procedures;
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
		public DbSet<Funcoes> funcoes { get; set; }
		public DbSet<PrefeitosAtuais> prefeitosAtuais { get; set; }
		public DbSet<FuncoesFuncionarios> funcoesFuncionarios { get; set; }
		public DbSet<VW_ALL_FUNCIONARIOS> ViewAllFuncionarios { get; set; }
		public DbSet<SP_ADD_CIDADE> SPAddCidade { get; set; }

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
			modelBuilder.ApplyConfiguration(new FuncionariosConfiguration());
			modelBuilder.ApplyConfiguration(new FuncoesConfiguration());
			modelBuilder.ApplyConfiguration(new PrefeitosAtuaisConfiguration());
			modelBuilder.ApplyConfiguration(new FuncoesFuncionariosConfiguration());
			modelBuilder.ApplyConfiguration(new VW_ALL_FUNCIONARIOSConfiguration());
		}
	}
}
