using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_EFCore
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
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder
				.Property(F => F.DataNascimento)
				.HasColumnName("DataNascimento")
				.HasColumnType("datatime2(7)");

			builder
				.Property<Guid>("CidadeId");

			builder
				.HasOne(f => f.Cidade)
				.WithMany(c => c.funcionarios)
				.HasForeignKey("CidadeId");
		}
	}
}
