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
    }
}
