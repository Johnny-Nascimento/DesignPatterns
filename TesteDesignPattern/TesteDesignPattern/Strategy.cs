using Strategy.Solucao;

namespace TesteDesignPattern
{
    [TestClass]
    public sealed class Strategy
    {
        public class ImpostoMock : IImposto
        {
            public double Calcula(Orcamento orcamento)
            {
                return orcamento.Valor;
            }
        }

        // É esperado que o ICMS seja calculado com a seguinte regra: 5% do valor do orçamento + 50
        [TestMethod]
        public void TestaRetornoICMS()
        {
            Orcamento orcamento = new Orcamento(100.00);
            ICMS icms = new ICMS();

            double impostoCalculado = icms.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 55);
        }

        // É esperado que o ISS seja calculado com a seguinte regra: 6% do valor do orçamento
        [TestMethod]
        public void TestaRetornoISS()
        {
            Orcamento orcamento = new Orcamento(100.00);
            ISS iss = new ISS();

            double impostoCalculado = iss.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 6);
        }

        // É esperado que o ICCC seja calculado com a seguinte regra: Quando valor igual a zero, retornar zero
        [TestMethod]
        public void TestaRetornoICC_ValorIgualAZero()
        {
            Orcamento orcamento = new Orcamento(0);
            ICCC iccc = new ICCC();

            double impostoCalculado = iccc.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 0);
        }

        // É esperado que o ICCC seja calculado com a seguinte regra: Quando valor menor que 1000, 5%
        [TestMethod]
        public void TestaRetornoICC_ValorMenorQueMil()
        {
            Orcamento orcamento = new Orcamento(100);
            ICCC iccc = new ICCC();

            double impostoCalculado = iccc.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 5);
        }

        // É esperado que o ICCC seja calculado com a seguinte regra: Quando valor menor ou igual a 3000, 7%
        [TestMethod]
        public void TestaRetornoICC_ValorMenorOuIgualATresMil()
        {
            Orcamento orcamento = new Orcamento(1000);
            ICCC iccc = new ICCC();

            double impostoCalculado = iccc.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 70);
        }

        // É esperado que o ICCC seja calculado com a seguinte regra: Quando valor maior que 3000, 8% + 30
        [TestMethod]
        public void TestaRetornoICC_ValorMaiorQueTresMil()
        {
            Orcamento orcamento = new Orcamento(10000);
            ICCC iccc = new ICCC();

            double impostoCalculado = iccc.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 830);
        }

        // É esperado a seguinte formatação: "O valor do imposto é: 100.00 R$"
        [TestMethod]
        public void TestaRetornoCalculaImposto()
        {
            Orcamento orcamento = new Orcamento(100);
            ImpostoMock impostoMock = new ImpostoMock();
            CalculadorDeImposto calculadorDeImposto = new CalculadorDeImposto();

            string textoFormatadoComValor = calculadorDeImposto.RealizaCalculo(orcamento, impostoMock);

            Assert.AreEqual(textoFormatadoComValor, "O valor do imposto é: R$ 100,00");
        }
    }
}
