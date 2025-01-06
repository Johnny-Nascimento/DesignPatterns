// Com o decorator o calculo do proximo imposto fica encapsulado, fazendo com que a proxima implementação fique mais facil.

namespace Decorator.Solucao
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

    public abstract class Imposto
    {
        private readonly Imposto OutroImposto;

        public Imposto()
        {
            OutroImposto = null;
        }

        public Imposto(Imposto imposto)
        {
            OutroImposto = imposto;
        }

        protected double CalculaOutroImposto(Orcamento orcamento)
        {
            if (OutroImposto == null)
                return 0;

            return OutroImposto.Calcula(orcamento);
        }

        public abstract double Calcula(Orcamento orcamento);
    }

    public class ICMS : Imposto
    {
        public ICMS(Imposto outroImposto) : base(outroImposto)
        { 
        }

        public ICMS()
        {
        }

        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05 + 50 + CalculaOutroImposto(orcamento);
        }
    }

    public class ISS : Imposto
    {
        public ISS(Imposto outroImposto) : base(outroImposto)
        {
        }

        public ISS()
        {
        }

        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06 + CalculaOutroImposto(orcamento);
        }
    }

    public class ICCC : Imposto
    {
        public ICCC(Imposto outroImposto) : base(outroImposto)
        {
        }

        public ICCC()
        {
        }

        public override double Calcula(Orcamento orcamento)
        {
            if (orcamento.Valor == 0)
                return 0;

            if (orcamento.Valor < 1000)
                return orcamento.Valor * 0.05 + CalculaOutroImposto(orcamento);

            if (orcamento.Valor <= 3000)
                return orcamento.Valor * 0.07 + CalculaOutroImposto(orcamento);

            return orcamento.Valor * 0.08 + 30 + CalculaOutroImposto(orcamento);
        }
    }

    public class ImpostoMuitoAlto : Imposto
    {
        public ImpostoMuitoAlto(Imposto outroImposto) : base(outroImposto)
        {
        }

        public ImpostoMuitoAlto()
        {
        }

        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.20 + CalculaOutroImposto(orcamento);
        }
    }

    public abstract class TemplateImpostoCondicional : Imposto
    {
        public TemplateImpostoCondicional(Imposto outroImposto) : base(outroImposto)
        {
        }
        public TemplateImpostoCondicional()
        {
        }


        protected abstract bool DeveUsarMaximaTaxacao(Orcamento orcamento);
        protected abstract double MaximaTaxacao(Orcamento orcamento);
        protected abstract double MinimaTaxacao(Orcamento orcamento);

        public override double Calcula(Orcamento orcamento)
        {
            if (DeveUsarMaximaTaxacao(orcamento))
                return MaximaTaxacao(orcamento);

            return MinimaTaxacao(orcamento);
        }
    }

    public class ICPP : TemplateImpostoCondicional
    {
        public ICPP(Imposto outroImposto) : base(outroImposto)
        {
        }

        public ICPP()
        {
        }

        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07 + CalculaOutroImposto(orcamento);
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05 + CalculaOutroImposto(orcamento);
        }
    }

    public class IKCV : TemplateImpostoCondicional
    {
        public IKCV(Imposto outroImposto) : base(outroImposto)
        {
        }

        public IKCV()
        {
        }

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
            return orcamento.Valor * 0.1 + CalculaOutroImposto(orcamento);
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06 + CalculaOutroImposto(orcamento);
        }
    }
}
