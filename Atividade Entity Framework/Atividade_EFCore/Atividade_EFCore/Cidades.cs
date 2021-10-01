using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_EFCore
{
	public class Cidades
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public int Populacao { get; set; }
		public float TaxaCriminalidade { get; set; }
		public float ImpostoSobreProduto { get; set; }
		public bool EstadoCalamidade { get; set; }

	}
}
