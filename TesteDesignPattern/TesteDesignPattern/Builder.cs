using Builder.Solucao;

namespace TesteDesignPattern
{
    [TestClass]
    public sealed class Builder
    {
        [TestMethod]
        public void TesteBuilder()
        {
            BuilderNotaFiscal builder = new BuilderNotaFiscal();
            NotaFiscal notaFiscal = builder.ParaEmpresa("Razao social")
                                           .ComCnpj("CNPJ")
                                           .ComData(DateTime.Now)
                                           .ComItem(new ItemNota("Descricao 1", 50.00, 1))
                                           .ComItem(new ItemNota("Descricao 2", 50.00, 1))
                                           .ComObservacoes("Observacao")
                                           .Constroi();

            Assert.AreEqual(100.00, notaFiscal.ValorBruto);
        }
    }
}
