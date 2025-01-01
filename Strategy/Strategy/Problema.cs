
using Strategy.Solucao;

namespace Strategy.Problema
{
    public class Orcamento
    {
        public Orcamento(double valor) => Valor = valor;
        public double Valor { get; private set; }
    }

    public class CalculadorDeImposto
    {
        // Grande dificuldade na adição e ou edição desse código.
        // Um método realizando varias ações.

        public void RealizaCalculo(Orcamento orcamento, String imposto)
        {
            if ("ICMS".Equals(imposto))
            {
                double icms = orcamento.Valor * 0.05 + 50;
                Console.WriteLine(icms);
            }
            else if ("ISS".Equals(imposto))
            {
                double iss = orcamento.Valor * 0.06;
                Console.WriteLine(iss);
            }
            else if ("ICCC".Equals(imposto))
            {
                double iccc = 0;

                if (orcamento.Valor < 1000)
                    iccc = orcamento.Valor * 0.05;
                else if (orcamento.Valor <= 3000)
                    iccc = orcamento.Valor * 0.07;
                else
                    iccc = orcamento.Valor * 0.08 + 30;

                Console.WriteLine(iccc);
            }
            else
                Console.WriteLine("Imposto inesistente.");
        }
    }
}
