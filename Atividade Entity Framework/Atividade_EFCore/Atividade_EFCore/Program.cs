using Microsoft.EntityFrameworkCore;
using System;

namespace Atividade_EFCore
{
	class Program
	{
		static void Main(string[] args)
		{
			var stringConexao = "Data Source=localhost" +
				"\\SQLEXPRESS;Database=Cidades;" +
				"Integrated Security=True;" +
				"Connect Timeout=5;" +
				"Encrypt=False;" +
				"TrustServerCertificate=False;" +
				"ApplicationIntent=ReadWrite;" +
				"MultiSubnetFailover=False";
			using (var contexto = new CidadesContext(stringConexao))
			{
				var sql = "select * from VW_ALL_FUNCIONARIOS";

				var RetornoView = contexto.ViewAllFuncionarios.FromSqlRaw(sql);

				foreach (var item in RetornoView)
				{
					Console.WriteLine(item.Nome + ":" + item.CidadeId);
				}
			}
		}
	}
}

