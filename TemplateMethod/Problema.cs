// O problema é que observando bem, tanto o ICP quanto o IKCV tem regras muito semelhantes,
// onde é consistido uma regra para realizar a taxação maxima e caso não entre na regra, usa-se a taxação minima
// A semelhança nesse caso não são os valores e sim a regra que cada método aplica.

namespace TemplateMethod.Problema
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

    public interface IImposto
    {
        double Calcula(Orcamento orcamento);
    }

    public class ICPP : IImposto
    {
        public double Calcula(Orcamento orcamento)
        {
            // Regra semelhante
            if (orcamento.Valor >= 500)
                return orcamento.Valor * 0.07;

            return orcamento.Valor * 0.05;
        }
    }

    public class IKCV : IImposto
    {
        public double Calcula(Orcamento orcamento)
        {
            // Regra semelhante
            if (orcamento.Valor >= 500 && temItemMaiorQueCemReais(orcamento))
                return orcamento.Valor * 0.1;

            return orcamento.Valor * 0.06;
        }

        public bool temItemMaiorQueCemReais(Orcamento orcamento)
        {
            return orcamento.Itens.FirstOrDefault( i => i.Valor > 100) != null;
        }
    }
}
