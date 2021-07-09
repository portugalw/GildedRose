using System.Collections.Generic;
using Xunit;

namespace MeuAcerto.Selecao.KataGildedRose
{
    public class GildedRoseTest
    {
        [Fact]
        public void Foo()
        {
            IList<Item> Items = new List<Item> { new Item { Nome = "foo", PrazoValidade = 0, Qualidade = 0 } };
            GildedRose app = new GildedRose(Items);
            app.AtualizarQualidade();
            Assert.Equal("foo", Items[0].Nome);
        }


        [Fact]
        public void ValidaQualidadeQueijoBrieCincoDiasDeveSerCinco()
        {
            var dias = 5;
            IList<Item> Items = new List<Item> { new Item { Nome = "Queijo Brie Envelhecido", PrazoValidade = 5, Qualidade = 0 } };
            GildedRose app = new GildedRose(Items);

            while (dias != 0)
            {
                app.AtualizarQualidade();
                dias--;
            }
            Assert.Equal(5, Items[0].Qualidade);
        }

        [Fact]
        public void ValidaQualidadeComSessentaDiasDeveSerCinquenta()
        {
            var dias = 60;
            IList<Item> Items = new List<Item> { new Item { Nome = "Queijo Brie Envelhecido", PrazoValidade = 5, Qualidade = 0 } };
            GildedRose app = new GildedRose(Items);

            while (dias != 0)
            {
                app.AtualizarQualidade();
                dias--;
            }
            Assert.Equal(50, Items[0].Qualidade);
        }
    }
}
