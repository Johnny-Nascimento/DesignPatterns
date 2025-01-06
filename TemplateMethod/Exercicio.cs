
/* Relatórios são muito parecidos: todos eles contém cabeçalho, corpo, e rodapé. Existem dois tipos de relatórios: simples e complexos.

As diferenças são sutis: relatórios simples possuem cabeçalhos e rodapés de uma linha, apenas com o nome do banco e telefone, respectivamente;
relatórios complexos possuem cabeçalhos que informam o nome do banco, endereço, telefone, e rodapés que informam e-mail, e a data atual.

Além disso, dada uma lista de contas, um relatório simples apenas imprime titular e saldo da conta. O relatório complexo exibe titular, agência, número da conta, e saldo.

Use Template Method, e implemente o mecânismo de relatórios. Use dados falsos para os dados do banco.
*/

namespace TemplateMethod.Exercicio
{
    public class Conta
    {
        public string Titular { get; set; }
        public double Saldo { get; set; }
        public int Agencia { get; set; }
        public int NumeroConta{ get; set; }
        public string NomeBanco { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email{ get; set; }
    }

    public abstract class RelatorioTemplateMethod
    {
        protected RelatorioTemplateMethod(List<Conta> contas)
        {
            Contas = contas;
        }

        private List<Conta> Contas { get; set; }

        public void ImprimeRelatorio()
        {
            foreach (Conta conta in Contas)
            {
                ImprimeCabecalho(conta);
                ImprimeCorpo(conta);
                ImprimeRodape(conta);
            }
        }

        protected abstract void ImprimeCabecalho(Conta conta);
        protected abstract void ImprimeCorpo(Conta conta);
        protected abstract void ImprimeRodape(Conta conta);
    }

    public class RelatorioSimples : RelatorioTemplateMethod
    {
        public RelatorioSimples(List<Conta> contas) : base(contas)
        {
        }

        protected override void ImprimeCabecalho(Conta conta)
        {
            Console.Out.WriteLine(conta.NomeBanco + " " + conta.Telefone);
        }

        protected override void ImprimeCorpo(Conta conta)
        {
            Console.Out.WriteLine(conta.Titular + " " + conta.Saldo);
        }

        protected override void ImprimeRodape(Conta conta)
        {
            Console.Out.WriteLine("");
        }
    }

    public class RelatorioComplexo : RelatorioTemplateMethod
    {
        public RelatorioComplexo(List<Conta> contas) : base(contas)
        {
        }

        protected override void ImprimeCabecalho(Conta conta)
        {
            Console.Out.WriteLine(conta.NomeBanco + " " + conta.Endereco + " " + conta.Telefone);
        }

        protected override void ImprimeCorpo(Conta conta)
        {
            Console.Out.WriteLine(conta.Titular + " " + conta.Agencia+ " " + conta.NumeroConta + " " + conta.Saldo);
        }

        protected override void ImprimeRodape(Conta conta)
        {
            Console.Out.WriteLine(conta.Email + " " + DateTime.Now.ToString());
        }
    }
}
