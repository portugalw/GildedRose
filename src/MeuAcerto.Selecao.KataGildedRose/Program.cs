using System;
using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose
{
	class Program
	{
		public static void Main(string[] args)
		{
			IList<Item> itens = new List<Item>{
				new Item {Nome = "Corselete +5 DEX", PrazoValidade = 10, Qualidade = 20},
				new Item {Nome = "Queijo Brie Envelhecido", PrazoValidade = 2, Qualidade = 0},
				new Item {Nome = "Elixir do Mangusto", PrazoValidade = 5, Qualidade = 7},
				new Item {Nome = "Sulfuras, a Mão de Ragnaros", PrazoValidade = 0, Qualidade = 80},
				new Item {Nome = "Sulfuras, a Mão de Ragnaros", PrazoValidade = -1, Qualidade = 80},
				new Item
				{
					Nome = "Ingressos para o concerto do TAFKAL80ETC",
					PrazoValidade = 15,
					Qualidade = 20
				},
				new Item
				{
					Nome = "Ingressos para o concerto do TAFKAL80ETC",
					PrazoValidade = 10,
					Qualidade = 49
				},
				new Item
				{
					Nome = "Ingressos para o concerto do TAFKAL80ETC",
					PrazoValidade = 5,
					Qualidade = 49
				},
				new Item {Nome = "Bolo de Mana Conjurado", PrazoValidade = 3, Qualidade = 6}
			};

			var app = new GildedRose(itens);
			var dia = 0;

			while (dia < 31)
			{
				Console.WriteLine($"-------- dia {dia} --------");
				Console.WriteLine("Nome, PrazoValidade, Qualidade");
				foreach (var item in itens)
				{
					Console.WriteLine($"{item.Nome}, {item.PrazoValidade}, {item.Qualidade}");
				}
				Console.WriteLine(string.Empty);
				app.AtualizarQualidade();

				dia++;
			}
		}

	}
}
