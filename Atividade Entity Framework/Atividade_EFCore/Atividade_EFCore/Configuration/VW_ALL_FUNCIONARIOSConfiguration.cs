using Atividade_EFCore.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_EFCore.Configuration
{
	class VW_ALL_FUNCIONARIOSConfiguration : IEntityTypeConfiguration<VW_ALL_FUNCIONARIOS>
	{
		public void Configure(EntityTypeBuilder<VW_ALL_FUNCIONARIOS> builder)
		{
			builder
				.ToTable("VW_ALL_FUNCIONARIOS");

			builder
				.Property(F => F.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder
				.Property(F => F.DataNascimento)
				.HasColumnName("DataNascimento")
				.HasColumnType("datatime2(7)");

			builder
				.Property(F => F.CidadeId)
				.HasColumnName("CidadeId")
				.HasColumnType("Guid");

			builder
				.Property(F => F.UltimaAtualizacao)
				.HasColumnName("UltimaAtualizacao")
				.HasColumnType("datetime2(7)");
		}
	}
}
