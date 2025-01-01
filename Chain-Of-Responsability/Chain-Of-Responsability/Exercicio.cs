/*
Um servidor de aplicação bancária que se comunica com outros, deve responder de várias formas diferentes, de acordo com a solicitação da aplicação cliente.
Se a aplicação solicitar uma Conta, cujos atributos são separados por ponto-e-vírgula, por exemplo, o servidor deverá responder nesse formato; se a aplicação solicitar XML,

o servidor deverá responder XML; se ela pedir separado por % (por cento), a aplicação deverá devolver dessa forma.
Implemente um Chain of Responsibility onde, dada uma requisição e uma conta bancária,
ela passeia por toda a corrente até encontrar a classe que deve processar a requisição de acordo com o formato solicitado, e imprime na tela a conta bancária no formato correto.

Imagine que a classe Requisição possui uma propriedade chamada Formato, que responde "XML", "CSV", ou "PORCENTO", indicando qual tratamento adequado.
Uma Conta possui apenas saldo e nome do titular:
 */

namespace Chain_Of_Responsability.Exercicio
{
    public class Conta
    {
        public double Saldo { get; private set; }
        public String Nome { get; private set; }

        public Conta(String nome, double saldo)
        {
            Saldo = saldo;
            Nome = nome;
        }
    }

    public enum Formato
    {
        XML,
        CSV,
        PORCENTO,
        NENHUM
    }

    public class Requisicao
    {
        public Formato Formato { get; private set; }

        public Requisicao(Formato formato)
        {
            Formato = formato;
        }
    }

    public interface IFormato
    {
        public IFormato Proximo { get; set; }
        public String AnalisaFormato(Requisicao requisicao);
    }

    public class FormatoXML : IFormato
    {
        public String AnalisaFormato(Requisicao requisicao) { return requisicao.Formato == Formato.XML ? "XML" : Proximo.AnalisaFormato(requisicao); }
        public IFormato Proximo { get; set; }

        public FormatoXML(IFormato proximo)
        {
            Proximo = proximo;
        }
    }

    public class FormatoCSV : IFormato
    {
        public String AnalisaFormato(Requisicao requisicao) { return requisicao.Formato == Formato.CSV ? "CSV" : Proximo.AnalisaFormato(requisicao); }
        public IFormato Proximo { get; set; }

        public FormatoCSV(IFormato proximo)
        {
            Proximo = proximo;
        }
    }

    public class FormatoPorcento : IFormato
    {
        public String AnalisaFormato(Requisicao requisicao) { return requisicao.Formato == Formato.PORCENTO ? "Porcento": Proximo.AnalisaFormato(requisicao); }
        public IFormato Proximo { get; set; }

        public FormatoPorcento(IFormato proximo)
        {
            Proximo = proximo;
        }
    }

    public class SemFormato : IFormato
    {
        public String AnalisaFormato(Requisicao requisicao) { return "Nenhum"; }
        public IFormato Proximo { get; set; }
    }

    public class MontaRequisicao
    {
        public String FazRequisicao(Requisicao requisicao, Conta conta)
        {
                
            FormatoXML formato = new FormatoXML(new FormatoCSV(new FormatoPorcento(new SemFormato())));
   
            return formato.AnalisaFormato(requisicao);
        }
    }
}
