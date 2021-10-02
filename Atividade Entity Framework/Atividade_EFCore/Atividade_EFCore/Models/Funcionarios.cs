using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_EFCore.Models
{
	public class Funcionarios
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public Cidades Cidade { get; set; }
		public List<FuncoesFuncionarios> Funcoes { get; set; }
	}
}
