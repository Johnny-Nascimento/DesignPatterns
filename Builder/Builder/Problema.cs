// A principal complexidade deste exemplo é a criação de um objeto com todas as informações, de maneira com que fique claro e com um código limpo, devido a quantidade grande de informações
// setar os dados diretamente pelo construtor pode se acabar aumentando a complexidade do código

namespace Builder.Problema
{
    public class ItemNota
    {
        public String Descricao{ get; private set; }
        public double Valor { get; private set; }
        public double Quantidade { get; private set; }
    
        public ItemNota(String descricao, double valor, double quantidade)
        {
            Descricao = descricao;
            Valor = valor;
            Quantidade = quantidade;
        }
    }

    public class NotaFiscal
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public double ValorBruto { get; private set; }
        public List<ItemNota> Itens { get; private set; }
        public string Observacoes { get; private set; }

        public NotaFiscal(string razaoSocial, string cnpj, DateTime dataEmissao, double valorBruto, List<ItemNota> itens, string observacoes)
        {
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            DataEmissao = dataEmissao;
            ValorBruto = valorBruto;
            Itens = itens;
            Observacoes = observacoes;
        }
    }
}
