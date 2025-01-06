
namespace TemplateMethod.Solucao
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

    public abstract class TemplateImpostoCondicional : IImposto
    {
        protected abstract bool DeveUsarMaximaTaxacao(Orcamento orcamento);
        protected abstract double MaximaTaxacao(Orcamento orcamento);
        protected abstract double MinimaTaxacao(Orcamento orcamento);

        public double Calcula(Orcamento orcamento)
        {
            if (DeveUsarMaximaTaxacao(orcamento))
                return MaximaTaxacao(orcamento);

            return MinimaTaxacao(orcamento);
        }
    }

    public class ICPP : TemplateImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
    }

    public class IKCV : TemplateImpostoCondicional
    {
        private bool temItemMaiorQueCemReais(Orcamento orcamento)
        {
            return orcamento.Itens.FirstOrDefault(i => i.Valor > 100) != null;
        }

        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor >= 500 && temItemMaiorQueCemReais(orcamento);
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }

    public class IHIT : TemplateImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            HashSet<string> itensNomeRepetido = new HashSet<string>();

            foreach (var item in orcamento.Itens)
            {
                if (itensNomeRepetido.Contains(item.Nome))
                        return true;
                else
                    itensNomeRepetido.Add(item.Nome);
            }

            return false;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.13 + 100;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor *  (0.01 * orcamento.Itens.Count);
        }
    }
}
