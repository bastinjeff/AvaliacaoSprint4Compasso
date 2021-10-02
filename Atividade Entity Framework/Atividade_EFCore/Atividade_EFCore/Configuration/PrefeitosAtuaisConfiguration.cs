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
	class PrefeitosAtuaisConfiguration : IEntityTypeConfiguration<PrefeitosAtuais>
	{
		public void Configure(EntityTypeBuilder<PrefeitosAtuais> builder)
		{
			builder
				.ToTable("PrefeitosAtuais");

			builder
				.Property(PA => PA.Id)
				.HasColumnName("Id")
				.HasColumnType("Guid")
				.IsRequired();

			builder
				.Property(PA => PA.Nome)
				.HasColumnName("Nome")
				.HasColumnType("nvarchar(MAX)")
				.IsRequired();

			builder
				.Property(PA => PA.InicioMandato)
				.HasColumnName("InicioMandato")
				.HasColumnType("DateTime2(7)");

			builder
				.Property(PA => PA.FimMandato)
				.HasColumnName("FimMandato")
				.HasColumnType("Datetime2(7)");

			builder
				.HasOne(PA => PA.Cidade)
				.WithMany(C => C.prefeitosAtuais)
				.IsRequired();
		}
	}
}
