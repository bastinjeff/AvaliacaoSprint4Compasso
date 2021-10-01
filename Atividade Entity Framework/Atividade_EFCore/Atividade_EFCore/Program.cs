using System;

namespace Atividade_EFCore
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var contexto = new CidadesContext())
			{
				foreach(var item in contexto.cidades)
				{
					Console.WriteLine(item.Nome);
				}
			}
		}
	}
}
