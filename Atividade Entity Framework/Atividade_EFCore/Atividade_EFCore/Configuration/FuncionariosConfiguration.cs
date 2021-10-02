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
	class FuncionariosConfiguration : IEntityTypeConfiguration<Funcionarios>
	{
		public void Configure(EntityTypeBuilder<Funcionarios> builder)
		{
			builder
				.ToTable("Funcionarios");

			builder
				.Property(F => F.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(max)");

			builder
				.Property(F => F.DataNascimento)
				.HasColumnName("DataNascimento")
				.HasColumnType("datatime2(7)")
				.IsRequired();

			builder
				.Property<Guid>("CidadeId").IsRequired();

			builder
				.HasOne(f => f.Cidade)
				.WithMany(c => c.funcionarios)
				.HasForeignKey("CidadeId");

			builder
				.Property<DateTime>("UltimaAtualizacao");
		}
	}
}
