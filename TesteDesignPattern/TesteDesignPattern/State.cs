using State.Solucao;
using State.Exercicio;

namespace TesteDesignPattern
{
    [TestClass]
    public sealed class State
    {
        [TestMethod]
        public void TesteMudancaStatus_EmAprovacaoParaEmAprovacao()
        {
            Orcamento orcamento = new Orcamento(100.00);

            try
            {
                orcamento.EmAprovacao();
                Assert.Fail();

            }
            catch (Exception ex)
            {
                Assert.AreEqual("Orçamento ja se encontra nesse status.", ex.Message);
            }
        }

        [TestMethod]
        public void TesteMudancaStatus_EmAprovacaoParaAprovado()
        {
            Orcamento orcamento = new Orcamento(100.00);
            orcamento.AprovaOrcamento();

            Assert.IsTrue(orcamento.EstadoAtual is Aprovado);
        }

        [TestMethod]
        public void TesteMudancaStatus_EmAprovacaoParaReprovado()
        {
            Orcamento orcamento = new Orcamento(100.00);
            orcamento.ReprovaOrcamento();

            Assert.IsTrue(orcamento.EstadoAtual is Reprovado);
        }

        [TestMethod]
        public void TesteMudancaStatus_EmAprovacaoParaFinalizado()
        {
            Orcamento orcamento = new Orcamento(100.00);
            orcamento.FinalizaOrcamento();

            Assert.IsTrue(orcamento.EstadoAtual is Finalizado);
        }

        // ^^^^ *** É POSSIVEL TESTAR TODOS OS OUTROS STATUS MUDANDO PARA SEUS RESPECTIVOS STATUS, MAS VAI DEMORAR MUITO E É MUITO PARECIDO *** ^^^^

        // Esperado 5% de desconto quando em aprovacao
        [TestMethod]
        public void TesteDescontoExtraEmAprovacao()
        {
            Orcamento orcamento = new Orcamento(100.00);
            orcamento.AplicaDescontoExtra();

            Assert.AreEqual(orcamento.Valor, 95.00);
        }

        // Esperado 2% de desconto quando aprovado
        [TestMethod]
        public void TesteDescontoExtraAprovado()
        {
            Orcamento orcamento = new Orcamento(100.00);
            orcamento.AprovaOrcamento();
            orcamento.AplicaDescontoExtra();

            Assert.AreEqual(orcamento.Valor, 98.00);
        }

        [TestMethod]
        public void TesteDescontoExtraDuasVezes()
        {
            Orcamento orcamento = new Orcamento(100.00);
            orcamento.AplicaDescontoExtra();
            Assert.AreEqual(orcamento.Valor, 95.00);

            try
            {
                orcamento.AplicaDescontoExtra();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Desconto já aplicado.", ex.Message);
            }
        }

        // ^^^^ *** É POSSIVEL TESTAR TODOS OS OUTROS STATUS COM SEUS DESCONTOS, MAS VAI DEMORAR MUITO E É MUITO PARECIDO *** ^^^^

        [TestMethod]
        public void TesteContaPositiva()
        {
            Conta conta = new Conta(100.00);
            conta.Saca(50.00);
            Assert.AreEqual(50.00, conta.Saldo);

            conta.Deposita(100);
            Assert.AreEqual(148.00, conta.Saldo);
        }

        [TestMethod]
        public void TesteContaNegativa()
        {
            Conta conta = new Conta(-100.00);

            try
            {
                conta.Saca(50.00);
                Assert.Fail();

            }
            catch (Exception ex)
            {
                Assert.AreEqual("Conta negativa, não é possível sacar.", ex.Message);
            }


            conta.Deposita(200.00);
            Assert.AreEqual(90, conta.Saldo);
        }
    }
}