using TemplateMethod.Exercicio;
using TemplateMethod.Solucao;


namespace TesteDesignPattern
{
    [TestClass]
    public sealed class TemplateMethod
    {
        [TestMethod]
        public void TesteImpostoICPPMaximaTaxacao()
        {
            Orcamento orcamento = new Orcamento(1000.00);
            ICPP icpp = new ICPP();

            double impostoCalculado = icpp.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 70);
        }

        [TestMethod]
        public void TesteImpostoICPPMinimaTaxacao()
        {
            Orcamento orcamento = new Orcamento(100.00);
            ICPP icpp = new ICPP();

            double impostoCalculado = icpp.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 5);
        }

        [TestMethod]
        public void TesteImpostoIKCVMaximaTaxacao()
        {
            Orcamento orcamento = new Orcamento(1000.00);
            orcamento.AdicionaItem(new Item("Lapis", 1000.00));

            IKCV ikcv = new IKCV();

            double impostoCalculado = ikcv.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 100);
        }

        [TestMethod]
        public void TesteImpostoIKCVMinimaTaxacao_SemOrcamentoMaiorQueMilReais()
        {
            Orcamento orcamento = new Orcamento(100.00);
            orcamento.AdicionaItem(new Item("Lapis", 100.00));

            IKCV ikcv = new IKCV();

            double impostoCalculado = ikcv.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 6);
        }

        [TestMethod]
        public void TesteImpostoIKCVMinimaTaxacao_SemItemMaiorQueCemReais()
        {
            Orcamento orcamento = new Orcamento(1000.00);
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Lapis", 100.00));

            IKCV ikcv = new IKCV();

            double impostoCalculado = ikcv.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 60);
        }

        [TestMethod]
        public void TesteImpostoIHITMaximaTaxacao()
        {
            Orcamento orcamento = new Orcamento(1000.00);
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Lapis", 100.00));
            orcamento.AdicionaItem(new Item("Caneta", 800.00));

            IHIT ihit = new IHIT();

            double impostoCalculado = ihit.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 230);
        }

        [TestMethod]
        public void TesteImpostoIHITMinimaTaxacao()
        {
            Orcamento orcamento = new Orcamento(100.00);
            orcamento.AdicionaItem(new Item("Lapis", 50.00));
            orcamento.AdicionaItem(new Item("Lapis Azul", 50.00));

            IHIT ihit = new IHIT();

            double impostoCalculado = ihit.Calcula(orcamento);

            Assert.AreEqual(impostoCalculado, 2);
        }
    }
}
