using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_EFCore.Models
{
	public class Funcoes
	{
		public Guid Id { get; set; }
		public string Descricao { get; set; }
		public int NivelAcesso { get; set; }
		public List<FuncoesFuncionarios> Funcionarios { get; set; }
	}
}
