using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose
{
    class GildedRose
    {
        IList<Item> Itens;
        public GildedRose(IList<Item> itens)
        {
            Itens = itens;
        }

        public void AtualizarQualidade2()
        {
            for (var i = 0; i < Itens.Count; i++)
            {
                if (Itens[i].Nome != "Queijo Brie Envelhecido" && Itens[i].Nome != "Ingressos para o concerto do TAFKAL80ETC")
                {
                    if (Itens[i].Qualidade > 0)
                    {
                        if (Itens[i].Nome == "Bolo de Mana Conjurado")
                        {
                            Itens[i].Qualidade -= 2;
                        }
                        else if (Itens[i].Nome != "Sulfuras, a Mão de Ragnaros")
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade - 1;
                        }
                    }
                }
                else
                {
                    if (Itens[i].Qualidade < 50)
                    {
                        Itens[i].Qualidade = Itens[i].Qualidade + 1;

                        if (Itens[i].Nome == "Ingressos para o concerto do TAFKAL80ETC")
                        {
                            if (Itens[i].PrazoValidade < 11)
                            {
                                if (Itens[i].Qualidade < 50)
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade + 1;
                                }
                            }

                            if (Itens[i].PrazoValidade < 6)
                            {
                                if (Itens[i].Qualidade < 50)
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade + 1;
                                }
                            }
                        }
                    }
                }

                if (Itens[i].Nome != "Sulfuras, a Mão de Ragnaros")
                {
                    Itens[i].PrazoValidade = Itens[i].PrazoValidade - 1;
                }

                if (Itens[i].PrazoValidade < 0)
                {
                    if (Itens[i].Nome != "Queijo Brie Envelhecido")
                    {
                        if (Itens[i].Nome != "Ingressos para o concerto do TAFKAL80ETC")
                        {
                            if (Itens[i].Qualidade > 0)
                            {
                                if (Itens[i].Nome != "Sulfuras, a Mão de Ragnaros")
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade - 1;
                                }
                            }
                        }
                        else
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade - Itens[i].Qualidade;
                        }
                    }
                    else
                    {
                        if (Itens[i].Qualidade < 50)
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade + 1;
                        }
                    }
                }
            }
        }

        public void AtualizarQualidade()
        {
            const string QUEIJO_BRIE = "Queijo Brie Envelhecido";
            const string INGRESSOS = "Ingressos para o concerto do TAFKAL80ETC";
            const string SULFURAS = "Sulfuras, a Mão de Ragnaros";
            const string CONJURADOS = "Bolo de Mana Conjurado";
            const int QUALIDADE_SULFURA = 80;

            foreach(var item in Itens)
            { 
                switch (item.Nome)
                {
                    case QUEIJO_BRIE:
                        AtualizarQualidadeQueijoBrie(item);
                        break;
                    case INGRESSOS:
                        AtualizarQualidadeIngressos(item);
                        break;
                    case SULFURAS:
                        AjustarQualidadeSulfuras(item, QUALIDADE_SULFURA);
                        break;
                    case CONJURADOS:
                        AjustarQualidadeConjurados(item);
                        break;
                    default:
                        AjustarQualidadeDemaisItens(item);
                        break;
                }
            }
        }

        private static void AjustarQualidadeSulfuras(Item item, int valorQualidade)
        {
            item.Qualidade = valorQualidade;
        }

        private void AjustarQualidadeDemaisItens(Item item)
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

        private void AjustarQualidadeConjurados(Item item)
        {
            AjustarQualidade(item, -2);
            item.PrazoValidade -= 1;
        }

        private void AtualizarQualidadeIngressos(Item item)
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

        private void AtualizarQualidadeQueijoBrie(Item item)
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
