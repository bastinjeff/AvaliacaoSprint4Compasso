using Microsoft.EntityFrameworkCore;
using System;

namespace Atividade_EFCore
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var contexto = new CidadesContext("Data Source=localhost\\SQLEXPRESS;Database=Cidades;Integrated Security=True;Connect Timeout=5;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
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
