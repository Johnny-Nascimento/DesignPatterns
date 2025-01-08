// A solucao visa criar uma classe que vai disparar uma série de ações que forem necessárias para serem executadas após a construção do objeto
// Essa classe vai ser unicamente responsavel por isso.
// A chamada vai ser feita após a construção com a lista de ações necessárias.

namespace Observer.Solucao
{
    public interface AcaoAposGerarNota
    {
        public string Executa(NotaFiscal notaFiscal);
    }

    public class NotaFiscalDao : AcaoAposGerarNota
    {
        public string Executa(NotaFiscal notaFiscal)
        {
            return "Salvando no banco";
        }
    }

    public class EnviadorDeEmail : AcaoAposGerarNota
    {
        public string Executa(NotaFiscal notaFiscal)
        {
            return "Enviando Email";
        }
    }

    public class EnviadorDeSMS : AcaoAposGerarNota
    {
        public string Executa(NotaFiscal notaFiscal)
        {
            return "Enviando SMS";
        }
    }

    public class Multiplicador : AcaoAposGerarNota
    {
        public double Fator { get; private set; }
        public Multiplicador(double fator)
        {
            Fator = fator;
        }

        public string Executa(NotaFiscal notaFiscal)
        {
            return $"{notaFiscal.ValorBruto * Fator}";
        }
    }

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
        private List<AcaoAposGerarNota> acoesAposGerarNota { get; set; }

        public BuilderNotaFiscal()
        {
            DataEmissao = DateTime.Now;

            acoesAposGerarNota = new List<AcaoAposGerarNota>();
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

        public void AdicionaAcao(AcaoAposGerarNota acao)
        {
            acoesAposGerarNota.Add(acao);
        }

        public NotaFiscal Constroi()
        {
            NotaFiscal nf = new NotaFiscal(RazaoSocial, Cnpj, DataEmissao, ValorBruto, Itens, Observacoes);

            string retornoAcoes = string.Empty;

            foreach (var acao in acoesAposGerarNota)
                retornoAcoes += acao.Executa(nf);

            return nf;
        }
    }
}
