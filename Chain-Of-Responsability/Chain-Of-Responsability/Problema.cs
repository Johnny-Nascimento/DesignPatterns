
namespace Chain_Of_Responsability.Problema
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

    public class DescontoPorCincoItens
    {
        public double Desconta(Orcamento orcamento)
        {
            if (orcamento.Itens.Count > 5)
                return orcamento.Valor * 0.1;

            return 0;
        }
    }

    public class DescontoPorMaisDeQuinhentosReais
    {
        public double Desconta(Orcamento orcamento)
        {
            if (orcamento.Valor > 500.0)
                return orcamento.Valor * 0.07;

            return 0;
        }
    }

    public class CalculadorDeDescontos
    {
        public double Calcula(Orcamento orcamento)
        {
            double desconto = new DescontoPorCincoItens().Desconta(orcamento);
            if (desconto == 0)
                desconto = new DescontoPorMaisDeQuinhentosReais().Desconta(orcamento);
            /*if (desconto == 0)
                desconto = new ...
                */

            // Mesmo criando uma classe para cada tipo de desconto
            // seria necessário sempre fazer um if para realizar uma nova tentativa de desconto em caso de não tenha sido satisfeito a primeira regra

            return desconto;
        }
    }
}
