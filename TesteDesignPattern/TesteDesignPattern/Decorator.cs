using Decorator.Exercicio;
using Decorator.Solucao;

namespace TesteDesignPattern
{
    [TestClass]
    public sealed class Decorator
    {
        // É esperado o resultado somado dos impostos ImpostoMuitoAlto + ICMS + ISS + ICCC
        [TestMethod]
        public void TestaImpostoComposto()
        {
            Orcamento orcamento = new Orcamento(100.00);
            ImpostoMuitoAlto impostoMuitoAlto = new ImpostoMuitoAlto(new ICMS(new ISS(new ICCC())));

            double impostoCalculado = impostoMuitoAlto.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 86);
        }

        [TestMethod]
        public void TestaTesta()
        {
            IList<Conta> contas = new List<Conta>();

            contas.Add(new Conta { Saldo = 99.99, DataAbertura = new DateTime(2024, 12, 10) });
            contas.Add(new Conta { Saldo = 100.00, DataAbertura = DateTime.Now });
            contas.Add(new Conta { Saldo = 501000.00, DataAbertura = new DateTime(2024, 12, 10) });
            contas.Add(new Conta { Saldo = 1000.00, DataAbertura = new DateTime(2024, 12, 10) });

            FiltraSaldoMenorCemReais filtro = new FiltraSaldoMenorCemReais(new FiltraSaldoMaiorQuinhentosMilReais(new FiltraDataAberturaMesCorrente()));
            IList<Conta> contasValidas = filtro.Filtra(contas);

            Assert.AreEqual(contasValidas.Count, 1);
            Assert.AreEqual(contasValidas[0].Saldo, 1000.00);
            Assert.AreEqual(contasValidas[0].DataAbertura, new DateTime(2024, 12, 10));
        }
    }
}
