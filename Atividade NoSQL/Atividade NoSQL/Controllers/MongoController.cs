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

		//Exemplo de Rota: localhost:5001/api/Mongo
		[HttpPost]
		public IActionResult ReceberPOST([FromBody]Pedido pedido)
		{			
			var PedidoResposta = OperacoesMongoDBMongoController.
				InserirPedidoDataBase(StringConexaoMongoDB, NomeDatabase, NomeColecao, pedido).Result;
			return CreatedAtAction(nameof(BuscaPedidoPorId), new { Id = PedidoResposta.Id }, PedidoResposta);
		}

		//Exemplo de Rota: localhost:5001/api/Mongo/Todos
		[HttpGet("Todos")]
		public IActionResult ListarTodosOsPedidos()
		{
			var TodosOsPedidos = OperacoesMongoDBMongoController.
				RetornaTodosOsPedidos(StringConexaoMongoDB, NomeDatabase, NomeColecao).Result;			
			return Ok(TodosOsPedidos);
		}

		//Exemplo de Rota: localhost:5001/api/Mongo?pageNumber=1&pageSize=2
		[HttpGet]
		public IActionResult ListaPedidosPaginados([FromQuery(Name = "pageNumber")]int pageNumber, [FromQuery(Name = "pageSize")] int pageSize)
		{
			var ColecaoPaginada = OperacoesMongoDBMongoController.
				RetornaListaPedidoPaginada(StringConexaoMongoDB, NomeDatabase, NomeColecao, pageNumber, pageSize).Result;
			var ResultadoPaginado = new PedidoPaginado(pageNumber,pageSize,ColecaoPaginada);
			return Ok(ResultadoPaginado);
		}

		//Exemplo de Rota: localhost:5001/api/Mongo/615a4976764e352ba724c410
		[HttpGet("{Id}")]
		public IActionResult BuscaPedidoPorId(string Id)
		{
			var PedidoRetornado = OperacoesMongoDBMongoController.RetornaPedidoComFiltroId(StringConexaoMongoDB, NomeDatabase, NomeColecao, Id).Result;
			return Ok(PedidoRetornado);
		}
		
	}
}
