/*
 * Ao identificar contas que possam ser fraudulentas, um banco possui uma série de filtros que devem ser aplicados sobre uma lista de contas.

Contas com saldo menor que 100 reais ou
Contas com saldo maior do que 500 mil reais, ou
Contas com data de abertura no mês corrente Todas essas são geralmente selecionadas para uma análise mais detalhada.
Usando Decorators, implemente esse conjunto de filtros e faça com que, ao receber uma lista, 
o decorator devolva uma nova lista com as contas que atendam a pelo menos um dos critérios acima. Isto é, queremos que o Filtro tenha pelo menos o método de filtragem de contas:
 */

using Decorator.Solucao;

namespace Decorator.Exercicio
{
    public class Conta
    {
        public double Saldo { get; set; }
        public DateTime DataAbertura { get; set; }
    }

    public abstract class Filtro
    {
        private readonly Filtro OutroFiltro;
        public Filtro(Filtro filtro)
        {
            OutroFiltro = filtro;
        }

        public Filtro()
        {
            OutroFiltro = null;
        }

        public IList<Conta> FazOutroFiltro(IList<Conta> contas)
        {
            if (OutroFiltro == null)
                return contas;

            return OutroFiltro.Filtra(contas);
        }

        public abstract IList<Conta> Filtra(IList<Conta> contas);
    }

    public class FiltraSaldoMenorCemReais : Filtro
    {
        public FiltraSaldoMenorCemReais(Filtro filtro) : base(filtro) { }

        public FiltraSaldoMenorCemReais() 
        { 
        }

        public override IList<Conta> Filtra(IList<Conta> contas)
        {
            foreach (Conta conta in contas.AsEnumerable().Reverse())
            {
                if (conta.Saldo < 100.00)
                    contas.Remove(conta);
            }

            return FazOutroFiltro(contas);
        }
    }

    public class FiltraSaldoMaiorQuinhentosMilReais : Filtro
    {
        public FiltraSaldoMaiorQuinhentosMilReais(Filtro filtro) : base(filtro) { }

        public FiltraSaldoMaiorQuinhentosMilReais()
        {
        }

        public override IList<Conta> Filtra(IList<Conta> contas)
        {
            foreach (Conta conta in contas.AsEnumerable().Reverse())
            {
                if (conta.Saldo > 500000.00)
                    contas.Remove(conta);
            }

            return FazOutroFiltro(contas);
        }
    }

    public class FiltraDataAberturaMesCorrente : Filtro
    {
        public FiltraDataAberturaMesCorrente(Filtro filtro) : base(filtro) { }

        public FiltraDataAberturaMesCorrente()
        {
        }

        public override IList<Conta> Filtra(IList<Conta> contas)
        {
            foreach (Conta conta in contas.AsEnumerable().Reverse())
            {
                if (conta.DataAbertura.Month == DateTime.Now.Month)
                    contas.Remove(conta);
            }

            return FazOutroFiltro(contas);
        }
    }
}
