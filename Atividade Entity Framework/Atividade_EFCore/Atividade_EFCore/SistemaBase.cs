using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Atividade_EFCore
{
	public class SistemaBase
	{
		public void Inicio()
		{
			var stringConexao = "Data Source=localhost" +
				"\\SQLEXPRESS;Database=Cidades;" +
				"Integrated Security=True;" +
				"Connect Timeout=5;" +
				"Encrypt=False;" +
				"TrustServerCertificate=False;" +
				"ApplicationIntent=ReadWrite;" +
				"MultiSubnetFailover=False";

			using (var Contexto = new CidadesContext(stringConexao))
			{
				Console.WriteLine("<<Chamando View VW_ALL_FUNCIONARIOS>>:");
				MostrarVW_ALL_FUNCIONARIOS(Contexto);
				Console.WriteLine("\n<Pressione Enter para Realizar a SP_ADD_CIDADE>");
				Console.ReadLine();
				Console.Clear();
				RealizaProcedureSP_ADD_CIDADE(Contexto);
				Console.WriteLine("\n<SP realizada com Sucesso, Pressione enter para finalizar>");
				Console.ReadLine();
			}
			
		}

		void RealizaProcedureSP_ADD_CIDADE(CidadesContext Contexto)
		{
			string SqlSP = "DECLARE @P_Id uniqueidentifier; SET @P_Id = NEWID();" +
				"exec SP_ADD_CIDADE @P_Id, @P_Nome, @P_Populacao, @P_TaxaCriminalidade, @P_ImpostoSobreProduto, @P_EstadoCalamidade";
			List<SqlParameter> Params = new List<SqlParameter>
			{
				new SqlParameter{ParameterName = "@P_Nome", Value = "SP_Teste"},
				new SqlParameter{ParameterName = "@P_Populacao", Value = 20000},
				new SqlParameter{ParameterName = "@P_TaxaCriminalidade", Value = 30.7},
				new SqlParameter{ParameterName = "@P_ImpostoSobreProduto", Value = 10.5},
				new SqlParameter{ParameterName = "@P_EstadoCalamidade", Value = false},
			};
			var Retorno = Contexto.Database.ExecuteSqlRaw(SqlSP, Params);			
		}

		void MostrarVW_ALL_FUNCIONARIOS(CidadesContext Contexto)
		{
			var sql = "select * from VW_ALL_FUNCIONARIOS";

			var RetornoView = Contexto.ViewAllFuncionarios.FromSqlRaw(sql);
			foreach (var item in RetornoView)
			{
				var UltimaAtualizacao = "";
				if (item.UltimaAtualizacao != null)
				{
					UltimaAtualizacao = item.UltimaAtualizacao.ToString();
				}
				else UltimaAtualizacao = "NULL";
				Console.WriteLine("Id = {0} \n    Nome = {1} \n    DataNascimento = {2} \n    CidadeId = {3} \n    UltimaAtualizacao = {4}\n\n", 
					item.Id, 
					item.Nome, 
					item.DataNascimento, 
					item.CidadeId, 
					UltimaAtualizacao);
			}
		}
	}
}
