using Atividade_NoSQL.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_NoSQL.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MongoController : ControllerBase
	{
		string StringConexaoMongoDB = "mongodb://localhost:27017";
		string NomeDatabase = "PedidosDatabase";
		string NomeColecao = "Pedidos";
		[HttpPost]
		public IActionResult ReceberPOST([FromBody]Pedido pedido)
		{			
			InserirPedidoDataBase(StringConexaoMongoDB, NomeDatabase, NomeColecao, pedido);
			return NoContent();
		}

		[HttpGet("Todos")]
		public IActionResult ListarTodosOsPedidos()
		{
			var TodosOsPedidos = RetornaTodosOsPedidos(StringConexaoMongoDB, NomeDatabase, NomeColecao).Result;			
			return Ok(TodosOsPedidos);
		}

		[HttpGet]
		public IActionResult ListaPedidosPaginados([FromQuery(Name = "pageNumber")]int pageNumber, [FromQuery(Name = "pageSize")] int pageSize)
		{
			var ColecaoPaginada = RetornaListaPedidoPaginada(StringConexaoMongoDB, NomeDatabase, NomeColecao, pageNumber, pageSize).Result;
			return Ok(ColecaoPaginada);
		}

		private async Task<List<Pedido>> RetornaListaPedidoPaginada(string StringConexao, string NomeDatabase, string NomeColecao,
																		int pageNumber, int pageSize)
		{
			var ColecaoPedidos = RetornaTodosOsPedidos(StringConexao, NomeDatabase, NomeColecao).Result;
			var ColecaoPaginada = ColecaoPedidos.Skip((pageNumber-1) * pageSize).Take(pageSize).ToList();
			return ColecaoPaginada;
		}
		private async Task<List<Pedido>> RetornaTodosOsPedidos(string StringConexao, string NomeDatabase, string NomeColecao)
		{
			var ColecaoPedidos = RetornaColecaoPedidosMongoDB(StringConexao, NomeDatabase, NomeColecao);
			var TodosOsPedidos = await ColecaoPedidos.Find(X => true).ToListAsync();
			return TodosOsPedidos;
		}
		private async Task InserirPedidoDataBase(string StringConexao, string NomeDatabase, string NomeColecao, Pedido PedidoRecebido)
		{
			var ColecaoPedidos = RetornaColecaoPedidosMongoDB(StringConexao, NomeDatabase, NomeColecao);
			await ColecaoPedidos.InsertOneAsync(PedidoRecebido);
		}

		private IMongoCollection<Pedido> RetornaColecaoPedidosMongoDB(string StringConexao, string NomeDatabase, string NomeColecao)
		{
			var Servidor = AbrirConexaoComMongoDB(StringConexao);
			var BancoPedidos = AbrirConexaoComDatabaseMongoDB(Servidor, NomeDatabase);
			var ColecaoPedidos = AbrirConexaoComColecaoMongoDB(BancoPedidos, NomeColecao);
			return ColecaoPedidos;
		}

		private IMongoClient AbrirConexaoComMongoDB(string StringConexao)
		{
			return new MongoClient(StringConexao);
		}

		private IMongoDatabase AbrirConexaoComDatabaseMongoDB(IMongoClient Servidor, string NomeDatabase)
		{
			return Servidor.GetDatabase(NomeDatabase);
		}

		private IMongoCollection<Pedido> AbrirConexaoComColecaoMongoDB(IMongoDatabase BancoPedidos, string NomeColecao)
		{
			return BancoPedidos.GetCollection<Pedido>(NomeColecao);
		}
	}
}
