using Atividade_API_REST.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_API_REST.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PokemonController : ControllerBase
	{
		static List<Pokemon> PokemonsCadastrados = new List<Pokemon>();
		static int ContadorHipotetico = 0;

		[HttpPost]
		public void AdicionaPokemon([FromBody] Pokemon pokemon)
		{
			ContadorHipotetico++;
			pokemon.Codigo = ContadorHipotetico;					
			PokemonsCadastrados.Add(pokemon);
			Console.WriteLine("Pokemon Novo Adicionado");
		}

		[HttpGet]
		public IEnumerable<Pokemon> RecuperaTodosOsPokemons()
		{
			Console.WriteLine("Retornando Todos os Pokemons");
			return PokemonsCadastrados;
		}

		[HttpGet("{id}")]
		public Pokemon RecuperaPokemonPorId(int Id)
		{
			Console.WriteLine("Retornando Pokemon de Id {0}", Id);
			return PokemonsCadastrados.Find(P => P.Codigo == Id);
		}

		[HttpDelete("{id}")]
		public void DeletaPokemonPorId(int Id)
		{
			Console.WriteLine("Deletando Pokemon de Id {0}", Id);
			PokemonsCadastrados.Remove(PokemonsCadastrados.Find(P => P.Codigo == Id));
		}
	}
}
