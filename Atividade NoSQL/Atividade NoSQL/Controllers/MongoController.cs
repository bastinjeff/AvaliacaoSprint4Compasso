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
			Console.WriteLine(pedido.orderID);
			InserirPedidoDataBase(StringConexaoMongoDB, NomeDatabase, NomeColecao, pedido);
			return Ok();
		}
		private async Task InserirPedidoDataBase(string StringConexao, string NomeDatabase, string NomeColecao, Pedido PedidoRecebido)
		{
			var Servidor = AbrirConexaoComMongoDB(StringConexao);
			var BancoPedidos = AbrirConexaoComDatabaseMongoDB(Servidor);
			var ColecaoPedidos = AbrirConexaoComColecaoMongoDB(BancoPedidos);
			await ColecaoPedidos.InsertOneAsync(PedidoRecebido);
		}

		private IMongoClient AbrirConexaoComMongoDB(string StringConexao)
		{
			return new MongoClient(StringConexao);
		}

		private IMongoDatabase AbrirConexaoComDatabaseMongoDB(IMongoClient Servidor)
		{
			return Servidor.GetDatabase(NomeDatabase);
		}

		private IMongoCollection<Pedido> AbrirConexaoComColecaoMongoDB(IMongoDatabase BancoPedidos)
		{
			return BancoPedidos.GetCollection<Pedido>(NomeColecao);
		}
	}
}
