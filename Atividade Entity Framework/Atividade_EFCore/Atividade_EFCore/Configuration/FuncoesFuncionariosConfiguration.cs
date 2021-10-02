using Atividade_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_EFCore.Configuration
{
	class FuncoesFuncionariosConfiguration : IEntityTypeConfiguration<FuncoesFuncionarios>
	{
		public void Configure(EntityTypeBuilder<FuncoesFuncionarios> builder)
		{
			builder
				.ToTable("FuncoesFuncionarios");

			builder
				.Property<Guid>("FuncaoId");

			builder
				.Property<Guid>("FuncionarioId");

			builder
				.HasKey("FuncaoId", "FuncionarioId");

			builder
				.HasOne(FF => FF.Funcao)
				.WithMany(X => X.Funcionarios)
				.HasForeignKey("FuncaoId");

			builder
				.HasOne(FF => FF.Funcionario)
				.WithMany(X => X.Funcoes)
				.HasForeignKey("FuncionarioId");
		}
	}
}
