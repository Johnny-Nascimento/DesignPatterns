// A solução cria uma corrente(chain) de responsabilidade(responsability) onde é feito montada uma Fila de execução onde a primeira chama a segunda e assim por diante.
// Deixando a criação da corrente por conta de quem chamar, nesse caso CalculadorDeDescontos.Calcula.

namespace Chain_Of_Responsability
{
    internal class Solucao
    {
        public class Item
        {
            public String Nome { get; private set; }
            public double Valor { get; private set; }

            public Item(String nome, double valor)
            {
                Nome = nome;
                Valor = valor;
            }
        }

        public class Orcamento
        {
            public double Valor { get; private set; }
            public IList<Item> Itens { get; private set; }

            public Orcamento(double valor)
            {
                Valor = valor;
                Itens = new List<Item>();
            }

            public void AdicionaItem(Item item)
            {
                Itens.Add(item);
            }
        }

        public interface IDesconto
        {
            double Desconta(Orcamento orcamento);
            IDesconto Proximo { get; set; }
        }

        public class DescontoPorCincoItens : IDesconto
        {
            public IDesconto Proximo { get; set; }

            public double Desconta(Orcamento orcamento)
            {
                if (orcamento.Itens.Count > 5)
                    return orcamento.Valor * 0.1;

                return Proximo.Desconta(orcamento);
            }
        }

        public class DescontoPorMaisDeQuinhentosReais : IDesconto
        {
            public IDesconto Proximo { get; set; }

            public double Desconta(Orcamento orcamento)
            {
                if (orcamento.Valor > 500.0)
                    return orcamento.Valor * 0.07;

                return Proximo.Desconta(orcamento);
            }
        }

        public class DescontoPorVendaCasada : IDesconto
        {
            public IDesconto Proximo { get; set; }

            private bool Existe(String nomeDoItem, Orcamento orcamento)
            {
                foreach (Item item in orcamento.Itens)
                {
                    if (item.Nome.Equals(nomeDoItem))
                        return true;
                }

                return false;
            }

            double IDesconto.Desconta(Orcamento orcamento)
            {
                if (Existe("LAPIS", orcamento) && Existe("CANETA", orcamento))
                    return orcamento.Valor * 0.05;

                return Proximo.Desconta(orcamento);
            }
        }

        public class SemDesconto : IDesconto
        {
            public IDesconto Proximo { get; set; }

            public double Desconta(Orcamento orcamento)
            {
                return 0;
            }
        }

        public class CalculadorDeDescontos
        {
            public double Calcula(Orcamento orcamento)
            {
                IDesconto desconto = new DescontoPorCincoItens();
                desconto.Proximo = new DescontoPorMaisDeQuinhentosReais();
                desconto.Proximo = new DescontoPorVendaCasada();
                desconto.Proximo.Proximo = new SemDesconto();

                return desconto.Desconta(orcamento);
            }
        }
    }
}
