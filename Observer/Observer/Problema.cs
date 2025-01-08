// O problema é quando a nota fiscal termina de ser setada, o próximo passo seria, salva-la no banco, envia-la por email e sms, nesse caso não deveria ser mais responsabilidade da classe
// implementar essas rotinas


namespace Observer.Problema
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

    public class ItemNotaBuilder
    {
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        public double Quantidade { get; private set; }

        public ItemNotaBuilder ComDescricao(string descricao)
        {
            Descricao = descricao;

            return this;
        }

        public ItemNotaBuilder ComValor(double valor)
        {
            Valor = valor;

            return this;
        }

        public ItemNotaBuilder ComQuantidade(double quantidade)
        {
            Quantidade = quantidade;

            return this;
        }

        public ItemNota Constroi()
        {
            return new ItemNota(Descricao, Valor, Quantidade);
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

        public BuilderNotaFiscal()
        {
            DataEmissao = DateTime.Now;
        }

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

        public BuilderNotaFiscal Com(ItemNota item)
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

        private void SalvaNoBanco()
        {
            Console.WriteLine("Salvando no banco");
        }

        private void EnviaEmail()
        {
            Console.WriteLine("Enviando Email");
        }

        private void EnviaSMS()
        {
            Console.WriteLine("Enviando SMS");
        }

        public NotaFiscal Constroi()
        {
            NotaFiscal nf = new NotaFiscal(RazaoSocial, Cnpj, DataEmissao, ValorBruto, Itens, Observacoes);

            // Estas são as ações que não deveriam mais caber a nota fiscal.
            SalvaNoBanco();
            EnviaEmail();
            EnviaSMS();

            return nf;
        }
    }
}
