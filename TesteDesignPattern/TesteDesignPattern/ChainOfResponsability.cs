using Chain_Of_Responsability.Solucao;

namespace TesteDesignPattern
{
    [TestClass]
    public sealed class ChainOfResponsability
    {
        // É esperado que com 5 itens ou mais seja calculado o desconto de 10% do valor total do orçamento.
        [TestMethod]
        public void TestaRetornoDescontoCincoItensOuMais()
        {
            Orcamento orcamento = new Orcamento(100.00);
            orcamento.AdicionaItem(new Item("Borracha", 20.00));
            orcamento.AdicionaItem(new Item("Lapis", 20.00));
            orcamento.AdicionaItem(new Item("Caderno", 20.00));
            orcamento.AdicionaItem(new Item("Caneta", 20.00));
            orcamento.AdicionaItem(new Item("Papel", 20.00));

            DescontoPorCincoItens descontoPorCincoItens = new DescontoPorCincoItens();
            double descontoCalculado = descontoPorCincoItens.Desconta(orcamento);

            Assert.AreEqual(descontoCalculado, 10);
        }

        // É esperado que com o valor do orçamento maior que 500.00, seja calculado o desconto de 7% do valor total do orçamento
        [TestMethod]
        public void TestaRetornoDescontoPorMaisDeQuinhentosReais()
        {
            Orcamento orcamento = new Orcamento(501);

            DescontoPorMaisDeQuinhentosReais descontoPorMaisDeQuinhentosReais = new DescontoPorMaisDeQuinhentosReais();
            double descontoCalculado = descontoPorMaisDeQuinhentosReais.Desconta(orcamento);

            Assert.AreEqual(descontoCalculado, 35.07);
        }

        // É esperado que com os itens Lapis e Caneta no orçamento, seja calculado o desconto de 5% do valor total do orçamento.
        [TestMethod]
        public void TestaRetornoDescontoVendaCasadaLapisCaneta()
        {
            Orcamento orcamento = new Orcamento(100);
            orcamento.AdicionaItem(new Item("Lapis", 50.00));
            orcamento.AdicionaItem(new Item("Caneta", 50.00));

            DescontoPorVendaCasada descontoVendaCasada = new DescontoPorVendaCasada();
            double descontoCalculado = descontoVendaCasada.Desconta(orcamento);

            Assert.AreEqual(descontoCalculado, 5);
        }

        // É esperado não seja aplicado desconto.
        [TestMethod]
        public void TestaRetornoDescontoSemDesconto()
        {
            Orcamento orcamento = new Orcamento(100);

            SemDesconto semDesconto = new SemDesconto();
            double descontoCalculado = semDesconto.Desconta(orcamento);

            Assert.AreEqual(descontoCalculado, 0);
        }

        // É esperado que a cadeia seja executada, executando o primeiro desconto "DescontoPorCincoItens"
        [TestMethod]
        public void TestaCalculadorDeDesconto_DescontoPorCincoItens()
        {
            Orcamento orcamento = new Orcamento(100.00);
            orcamento.AdicionaItem(new Item("Borracha", 20.00));
            orcamento.AdicionaItem(new Item("Lapis", 20.00));
            orcamento.AdicionaItem(new Item("Caderno", 20.00));
            orcamento.AdicionaItem(new Item("Caneta", 20.00));
            orcamento.AdicionaItem(new Item("Papel", 20.00));

            CalculadorDeDescontos calculadorDeDescontos = new CalculadorDeDescontos();
            double descontoCalculado = calculadorDeDescontos.Calcula(orcamento);

            Assert.AreEqual(descontoCalculado, 10);
        }

        // É esperado que a cadeia seja executada, executando o primeiro desconto "DescontoPorMaisDeQuinhentosReais"
        [TestMethod]
        public void TestaCalculadorDeDesconto_DescontoPorMaisDeQuinhentosReais()
        {
            Orcamento orcamento = new Orcamento(501);

            CalculadorDeDescontos calculadorDeDescontos = new CalculadorDeDescontos();
            double descontoCalculado = calculadorDeDescontos.Calcula(orcamento);

            Assert.AreEqual(descontoCalculado, 35.07);
        }

        // É esperado que a cadeia seja executada, executando o primeiro desconto "DescontoPorVendaCasada"
        [TestMethod]
        public void TestaCalculadorDeDesconto_DescontoPorVendaCasada()
        {
            Orcamento orcamento = new Orcamento(100);
            orcamento.AdicionaItem(new Item("Lapis", 50.00));
            orcamento.AdicionaItem(new Item("Caneta", 50.00));

            CalculadorDeDescontos calculadorDeDescontos = new CalculadorDeDescontos();
            double descontoCalculado = calculadorDeDescontos.Calcula(orcamento);

            Assert.AreEqual(descontoCalculado, 5);
        }

        // É esperado que a cadeia seja executada, executando o primeiro desconto "SemDesconto"
        [TestMethod]
        public void TestaCalculadorDeDesconto_SemDesconto()
        {
            Orcamento orcamento = new Orcamento(100);

            CalculadorDeDescontos calculadorDeDescontos = new CalculadorDeDescontos();
            double descontoCalculado = calculadorDeDescontos.Calcula(orcamento);

            Assert.AreEqual(descontoCalculado, 0);
        }
    }
}
