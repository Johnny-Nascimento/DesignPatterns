/*
Muitas pessoas optam por investir o dinheiro das suas contas bancárias. Existem diversos tipos de investimentos, desde investimentos conservadores até mais arrojados.
Independente do investimento escolhido, o titular da conta recebe apenas 75% do lucro do investimento, pois 25% é imposto.
Implemente um mecanismo que invista o valor do saldo dela em um dos vários tipos de investimento e, dado o retorno desse investimento, 75% do valor é adicionado no saldo da conta.
Crie a classe RealizadorDeInvestimentos que recebe uma estratégia de investimento, a executa sobre uma conta bancária, e adiciona o resultado seguindo a regra acima no saldo da conta.

Os possíveis tipos de investimento são:
"CONSERVADOR", que sempre retorna 0.8% do valor investido;
"MODERADO", que tem 50% de chances de retornar 2.5%, e 50% de chances de retornar 0.7%;
"ARROJADO", que tem 20% de chances de retornar 5%, 30% de chances de retornar 3%, e 50% de chances de retornar 0.6%.

Para verificar se a chance é maior que 30%, por exemplo, use:
bool escolhido = new Random().Next(101) > 30;
*/

namespace Investimento
{
    public class ContaBancaria
    {
        public ContaBancaria(double saldo) => Saldo = saldo;
        public double Saldo { get; private set; }
    }

    public interface IInvestimento
    {
        double Calcula(ContaBancaria contaBancaria);
    }

    public class Conservador : IInvestimento
    {
        // "CONSERVADOR", que sempre retorna 0.8% do valor investido;

        public double Calcula(ContaBancaria contaBancaria)
        {
            double lucroInvestimento = contaBancaria.Saldo * 0.8;
            lucroInvestimento -= lucroInvestimento * 0.25;

            return lucroInvestimento + contaBancaria.Saldo;
        }
    }

    public class Moderado : IInvestimento
    {
        // "MODERADO", que tem 50% de chances de retornar 2.5%, e 50% de chances de retornar 0.7%;

        public double Calcula(ContaBancaria contaBancaria)
        {
            int chanceRetorno = new Random().Next(101);

            double percentualMultiplicador = chanceRetorno > 50 ? 0.7 : 2.5;

            double lucroInvestimento = contaBancaria.Saldo * percentualMultiplicador;
            lucroInvestimento -= lucroInvestimento * 0.25;

            return lucroInvestimento + contaBancaria.Saldo;
        }
    }

    public class Arrojado : IInvestimento
    {
        // "ARROJADO", que tem 20% de chances de retornar 5%, 30% de chances de retornar 3%, e 50% de chances de retornar 0.6%.

        public double Calcula(ContaBancaria contaBancaria)
        {
            int chanceRetorno = new Random().Next(101);

            double percentualMultiplicador = 0;

            switch (chanceRetorno)
            {
                case > 50: percentualMultiplicador = 0.06; break;
                case > 30: percentualMultiplicador = 0.03; break;
                case > 20: percentualMultiplicador = 0.05; break;

                default:
                    break;
            }

            double lucroInvestimento = contaBancaria.Saldo * percentualMultiplicador;
            lucroInvestimento -= lucroInvestimento * 0.25;
                
            return lucroInvestimento + contaBancaria.Saldo;
        }
    }

    public class RealizadorDeInvestimentos
    {
        public void RealizaCalculo(ContaBancaria contaBancaria, IInvestimento investimento)
        {
            Console.WriteLine($"O seu investimento rendeu: {investimento.Calcula(contaBancaria).ToString("C")}");
        }
    }
}
