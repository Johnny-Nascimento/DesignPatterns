using Observer.Solucao;

namespace TesteDesignPattern
{
    [TestClass]
    public sealed class Observer
    {
        [TestMethod]
        public void TesteObserver()
        {
            ItemNotaBuilder itemNotaBuilder = new ItemNotaBuilder();
            BuilderNotaFiscal builder = new BuilderNotaFiscal();

             builder.ParaEmpresa("Razao social")
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
                    .ComObservacoes("Observacao");


            builder.AdicionaAcao(new NotaFiscalDao());
            builder.AdicionaAcao(new EnviadorDeSMS());
            builder.AdicionaAcao(new EnviadorDeEmail());
            builder.AdicionaAcao(new Multiplicador(10.00));

            NotaFiscal notaFiscal = builder.Constroi();
        }
    }
}
