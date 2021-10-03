using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_NoSQL.Models
{
	public class PedidoPaginado
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public List<Pedido> items { get; set; }
		public PedidoPaginado()
		{

		}

		public PedidoPaginado(int PageNumber, int PageSize, List<Pedido> Resultado)
		{
			this.PageNumber = PageNumber;
			this.PageSize = PageSize;
			this.items = Resultado;
		}
	}
}
