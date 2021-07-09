using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose
{
    class GildedRose
    {
        readonly IList<Item> Itens;
        public GildedRose(IList<Item> itens)
        {
            Itens = itens;
        }

        public void AtualizarQualidade()
        {
            const string QUEIJO_BRIE = "Queijo Brie Envelhecido";
            const string INGRESSOS = "Ingressos para o concerto do TAFKAL80ETC";
            const string SULFURAS = "Sulfuras, a Mão de Ragnaros";
            const string CONJURADOS = "Bolo de Mana Conjurado";
            const int QUALIDADE_SULFURA = 80;

            if (Itens == null) return;

            foreach(var item in Itens)
            { 
                switch (item.Nome)
                {
                    case QUEIJO_BRIE:
                        AtualizarQueijoBrie(item);
                        break;
                    case INGRESSOS:
                        AtualizarIngressos(item);
                        break;
                    case SULFURAS:
                        AjustarSulfuras(item, QUALIDADE_SULFURA);
                        break;
                    case CONJURADOS:
                        AjustarConjurados(item);
                        break;
                    default:
                        AjustarDemaisItens(item);
                        break;
                }
            }
        }

        private static void AjustarSulfuras(Item item, int valorQualidade)
        {
            item.Qualidade = valorQualidade;
        }

        private void AjustarDemaisItens(Item item)
        {
            if (item.PrazoValidade <= 0)
            {
                AjustarQualidade(item, -2);
            }
            else
            {
                AjustarQualidade(item, -1);
            }

            item.PrazoValidade -= 1;
        }

        private void AjustarConjurados(Item item)
        {
            AjustarQualidade(item, -2);
            item.PrazoValidade -= 1;
        }

        private void AtualizarIngressos(Item item)
        {
            if (item.PrazoValidade <= 0)
            {
                item.Qualidade = 0;
            }
            else if (item.PrazoValidade <= 5)
            {
                AjustarQualidade(item, 3);
            }
            else if (item.PrazoValidade <= 10)
            {
                AjustarQualidade(item, 2);
            }
            else
            {
                AjustarQualidade(item, 1);
            }

            item.PrazoValidade -= 1;
        }

        private void AtualizarQueijoBrie(Item item)
        {
            if (item.PrazoValidade <= 0)
            {
                AjustarQualidade(item, 2);
            }
            else
            {
                AjustarQualidade(item, 1);
            }

            item.PrazoValidade -= 1;
        }

        private void AjustarQualidade(Item item, int ajuste)
        {
            item.Qualidade += ajuste;

            if (item.Qualidade <= 0)
            {
                item.Qualidade = 0;
            }
            else if(item.Qualidade >= 50)
            {
                item.Qualidade = 50;
            }
        }
    }
}
