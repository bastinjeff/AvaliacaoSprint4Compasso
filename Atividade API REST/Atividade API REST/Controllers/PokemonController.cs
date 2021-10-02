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
		public IActionResult AdicionaPokemon([FromBody] Pokemon pokemon)
		{
			ContadorHipotetico++;
			pokemon.Codigo = ContadorHipotetico;
			PokemonsCadastrados.Add(pokemon);
			Console.WriteLine("Pokemon Novo Adicionado");
			return CreatedAtAction(nameof(RecuperaPokemonPorId), new { Id = pokemon.Codigo }, pokemon);
		}

		[HttpGet]
		public IActionResult RecuperaTodosOsPokemons()
		{
			Console.WriteLine("Retornando Todos os Pokemons");
			return Ok(PokemonsCadastrados);
		}

		[HttpGet("{id}")]
		public IActionResult RecuperaPokemonPorId(int Id)
		{
			Console.WriteLine("Retornando Pokemon de Id {0}", Id);
			Pokemon Retornado = PokemonsCadastrados.FirstOrDefault(P => P.Codigo == Id);
			if(Retornado == null)
			{
				return NotFound();
			}
			return Ok(Retornado);
		}

		[HttpDelete("{id}")]
		public IActionResult DeletaPokemonPorId(int Id)
		{
			Console.WriteLine("Deletando Pokemon de Id {0}", Id);
			PokemonsCadastrados.Remove(PokemonsCadastrados.Find(P => P.Codigo == Id));
			return NoContent();
		}
	}
}
