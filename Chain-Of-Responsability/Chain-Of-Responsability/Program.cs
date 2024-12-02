using static Chain_Of_Responsability.Solucao;
using static Chain_Of_Responsability.Exercicio;
using System;

namespace Chain_Of_Responsability
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            CalculadorDeDescontos calcula = new CalculadorDeDescontos();
            Orcamento orcamento = new Orcamento(500.0);
            orcamento.AdicionaItem(new Item("LAPIS", 1));
            orcamento.AdicionaItem(new Item("CANETA", 1));

            double desconto = calcula.Calcula(orcamento);

            Console.WriteLine("Desconto {0:0.00}", desconto);
            */

            MontaRequisicao montaRequisicao = new MontaRequisicao();
            Requisicao requisicao = new Requisicao(Formato.NENHUM);
            Conta conta = new Conta("Jorge", 50.00);

            Console.WriteLine(montaRequisicao.FazRequisicao(requisicao, conta));
        }
    }

}