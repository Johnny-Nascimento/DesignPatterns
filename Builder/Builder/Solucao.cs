// A solução propões uma maneira mais legivel, mais simples de realizar a montagem do objeto, trazendo menos complexidade,
// realizando operações encapsuladas quando necessário como é o caso do valor bruto
// ainda assim mantem a segurança de deixar os sets privados.
// e permite usar o Fluent, que é a chamada de um método que retorna o proprio objeto e assim por diante. Notafiscal.Metodo().Metodo().Metodo()...

namespace Builder.Solucao
{
    public class ItemNota
    {
        public String Descricao { get; private set; }
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

    public class BuilderNotaFiscal
    {
        public string RazaoSocial { get; private set; } = string.Empty;
        public string Cnpj { get; private set; } = string.Empty;
        public DateTime DataEmissao { get; private set; }
        public double ValorBruto { get; private set; }
        public List<ItemNota> Itens { get; private set; } = new List<ItemNota>();
        public string Observacoes { get; private set; } = string.Empty;

        public BuilderNotaFiscal ParaEmpresa(string razaoSocial)
        {
            RazaoSocial = razaoSocial;

            return this;
        }

        public BuilderNotaFiscal ComCnpj(string cnpj)
        {
            Cnpj = cnpj;

            return this;
        }

        public BuilderNotaFiscal ComData(DateTime data)
        {
            DataEmissao = data;

            return this;
        }

        public BuilderNotaFiscal ComItem(ItemNota item)
        {
            Itens.Add(item);
            ValorBruto += item.Valor;

            return this;
        }

        public BuilderNotaFiscal ComObservacoes(string observacoes)
        {
            Observacoes = observacoes;

            return this;
        }

        public NotaFiscal Constroi()
        {
            return new NotaFiscal(RazaoSocial, Cnpj, DataEmissao, ValorBruto, Itens, Observacoes);
        }
    }
}
