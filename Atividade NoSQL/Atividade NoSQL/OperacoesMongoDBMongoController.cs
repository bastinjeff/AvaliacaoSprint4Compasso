using Atividade_NoSQL.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_NoSQL
{
	public static class OperacoesMongoDBMongoController
	{
		public static async Task<List<Pedido>> RetornaListaPedidoPaginada(string StringConexao, string NomeDatabase, string NomeColecao,
																		int pageNumber, int pageSize)
		{
			var ColecaoPedidos = RetornaTodosOsPedidos(StringConexao, NomeDatabase, NomeColecao).Result;
			var ColecaoPaginada = ColecaoPedidos.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
			return ColecaoPaginada;
		}
		public static async Task<List<Pedido>> RetornaTodosOsPedidos(string StringConexao, string NomeDatabase, string NomeColecao)
		{
			var ColecaoPedidos = RetornaColecaoPedidosMongoDB(StringConexao, NomeDatabase, NomeColecao);
			var TodosOsPedidos = await ColecaoPedidos.Find(X => true).ToListAsync();
			return TodosOsPedidos;
		}
		public static async Task<Pedido> InserirPedidoDataBase(string StringConexao, string NomeDatabase, string NomeColecao, Pedido PedidoRecebido)
		{
			var ColecaoPedidos = RetornaColecaoPedidosMongoDB(StringConexao, NomeDatabase, NomeColecao);
			await ColecaoPedidos.InsertOneAsync(PedidoRecebido);
			Console.WriteLine(PedidoRecebido.Id);
			return PedidoRecebido;
		}

		public static async Task<Pedido> RetornaPedidoComFiltroId(string StringConexao, string NomeDatabase, string NomeColecao,string FiltroId)
		{
			var ColecaoPedidos = RetornaColecaoPedidosMongoDB(StringConexao, NomeDatabase, NomeColecao);
			var ConstrutorFiltro = Builders<Pedido>.Filter;
			var Filtro = ConstrutorFiltro.Eq(X => X.Id, FiltroId);
			var PedidoRetornado = await ColecaoPedidos.Find(Filtro).ToListAsync();
			return PedidoRetornado.ElementAt(0);
		}

		private static IMongoCollection<Pedido> RetornaColecaoPedidosMongoDB(string StringConexao, string NomeDatabase, string NomeColecao)
		{
			var Servidor = AbrirConexaoComMongoDB(StringConexao);
			var BancoPedidos = AbrirConexaoComDatabaseMongoDB(Servidor, NomeDatabase);
			var ColecaoPedidos = AbrirConexaoComColecaoMongoDB(BancoPedidos, NomeColecao);
			return ColecaoPedidos;
		}

		private static IMongoClient AbrirConexaoComMongoDB(string StringConexao)
		{
			return new MongoClient(StringConexao);
		}

		private static IMongoDatabase AbrirConexaoComDatabaseMongoDB(IMongoClient Servidor, string NomeDatabase)
		{
			return Servidor.GetDatabase(NomeDatabase);
		}

		private static IMongoCollection<Pedido> AbrirConexaoComColecaoMongoDB(IMongoDatabase BancoPedidos, string NomeColecao)
		{
			return BancoPedidos.GetCollection<Pedido>(NomeColecao);
		}
	}
}
