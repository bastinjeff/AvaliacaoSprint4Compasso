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
	class FuncoesConfiguration : IEntityTypeConfiguration<Funcoes>
	{
		public void Configure(EntityTypeBuilder<Funcoes> builder)
		{
			builder
				.ToTable("Funcoes");

			builder
				.Property(F => F.Id)
				.HasColumnName("Id")
				.HasColumnType("Guid")
				.IsRequired();

			builder
				.Property(F => F.Descricao)
				.HasColumnName("Descricao")
				.HasColumnType("varchar(max)");

			builder
				.Property(F => F.NivelAcesso)
				.HasColumnName("NivelAcesso")
				.HasColumnType("int")
				.IsRequired();

			builder
				.Property<DateTime>("UltimaAtualizacao");
						
		}
	}
}
