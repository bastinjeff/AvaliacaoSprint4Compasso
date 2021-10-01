using Microsoft.EntityFrameworkCore;
using System;

namespace Atividade_EFCore
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var contexto = new CidadesContext())
			{
				var funcionarioCCidade = contexto.funcionarios.Include(f => f.Cidade);
				foreach(var item in funcionarioCCidade)
				{
					Console.WriteLine(item.Nome + ":" + item.Cidade.Nome);
				}
			}
		}
	}
}
