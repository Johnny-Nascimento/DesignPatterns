using Imposto;
using Investimento;

internal class Program
{
    static void Main(string[] args)
    {
        ContaBancaria orcamento = new ContaBancaria(100);

        RealizadorDeInvestimentos realizadorDeInvestimentos = new RealizadorDeInvestimentos();

        realizadorDeInvestimentos.RealizaCalculo(orcamento, new Conservador());
        realizadorDeInvestimentos.RealizaCalculo(orcamento, new Moderado   ());
        realizadorDeInvestimentos.RealizaCalculo(orcamento, new Arrojado   ());
    }
}
