using Builder.Solucao;

namespace TesteDesignPattern
{
    [TestClass]
    public sealed class Builder
    {
        [TestMethod]
        public void TesteBuilder()
        {
            ItemNotaBuilder itemNotaBuilder = new ItemNotaBuilder();
            BuilderNotaFiscal builder = new BuilderNotaFiscal();

            NotaFiscal notaFiscal = builder.ParaEmpresa("Razao social")
                                           .ComCnpj("CNPJ")
                                           .ComData(DateTime.Now)
                                           .Com
                                           (
                                            itemNotaBuilder.ComDescricao("Descricao 1")
                                                            .ComQuantidade(1)
                                                            .ComValor(50.00)
                                                            .Constroi()
                                           )
                                           .Com
                                           (
                                            itemNotaBuilder.ComDescricao("Descricao 2")
                                                           .ComQuantidade(1)
                                                           .ComValor(50.00)
                                                           .Constroi()
                                           )
                                           .ComObservacoes("Observacao")
                                           .Constroi();

            Assert.AreEqual(100.00, notaFiscal.ValorBruto);
        }
    }
}
