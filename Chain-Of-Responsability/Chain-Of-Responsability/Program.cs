using Chain_Of_Responsability.Exercicio;

namespace Chain_Of_Responsability
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MontaRequisicao montaRequisicao = new MontaRequisicao();
            Requisicao requisicao = new Requisicao(Formato.NENHUM);
            Conta conta = new Conta("Jorge", 50.00);

            Console.WriteLine(montaRequisicao.FazRequisicao(requisicao, conta));
        }
    }
}