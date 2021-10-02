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
	class CidadesConfiguration : IEntityTypeConfiguration<Cidades>
	{
		public void Configure(EntityTypeBuilder<Cidades> builder)
		{
			builder.ToTable("Cidades");

			builder
				.Property(Cidade => Cidade.Id)
				.HasColumnType("guid")
				.IsRequired();

			builder
				.Property(Cidade => Cidade.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(max)");

			builder
				.Property(Cidade => Cidade.Populacao)
				.HasColumnName("Populacao")
				.HasColumnType("int")
				.IsRequired();

			builder
				.Property(Cidade => Cidade.TaxaCriminalidade)
				.HasColumnType("float")
				.IsRequired();

			builder
				.Property(Cidade => Cidade.ImpostoSobreProduto)
				.HasColumnType("float")
				.IsRequired();

			builder
				.Property(Cidade => Cidade.EstadoCalamidade)
				.HasColumnType("bit")
				.IsRequired();

			builder
				.Property<DateTime>("UltimaAtualizacao");			
		}
	}
}
