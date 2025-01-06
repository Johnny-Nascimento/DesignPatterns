/*
Crie todo o mecanismo para flexibilizar a criação de diferentes estratégias de impostos, igual visto no vídeo. Crie a interface Imposto, e as estratégias ICMS e ISS. O ISS deve ser 6% do valor do orçamento, e o ICMS deve ser 5% do valor do orçamento mais o valor fixo de R$ 50,00.
Crie a classe Orcamento, que tem como atributo um valor. Crie um construtor que recebe esse valor, e um getter para devolvê-lo.
Crie a classe CalculadorDeImposto, que recebe um Orcamento e um Imposto. Essa classe calcula o imposto usando a estratégia recebida e imprime o resultado na tela.
Cole aqui o código dos impostos e do CalculadorDeImposto.
*/

namespace Strategy.Solucao
{
    public class Orcamento
    {
        public Orcamento(double valor) => Valor = valor;
        public double Valor { get; private set; }
    }

    public interface IImposto
    {
        double Calcula(Orcamento orcamento);
    }

    public class ICMS : IImposto
    {
        public double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05 + 50;
        }
    }

    public class ISS : IImposto
    {
        public double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }

    public class ICCC : IImposto
    {
        /*
        Implemente mais uma estratégia de cálculo de imposto.
        Crie o imposto que se chama ICCC, que retorna 5% do valor total caso o orçamento seja menor do que R$ 1000,00 reais, 7% caso o valor esteja entre R$ 1000 e R$ 3000,00 com os limites inclusos, ou 8% mais 30 reais, caso o valor esteja acima de R$ 3000,00.
        Escreva um método main que testa sua implementação. Cole aqui o código do ICCC.
        */

        public double Calcula(Orcamento orcamento)
        {
            if (orcamento.Valor == 0)
                return 0;

            if (orcamento.Valor < 1000)
                return orcamento.Valor * 0.05;

            if (orcamento.Valor <= 3000)
                return orcamento.Valor * 0.07;

            return orcamento.Valor * 0.08 + 30;
        }
    }

    public class CalculadorDeImposto
    {
        public string RealizaCalculo(Orcamento orcamento, IImposto imposto)
        {
            return $"O valor do imposto é: {imposto.Calcula(orcamento).ToString("C")}";
        }
    }
}
