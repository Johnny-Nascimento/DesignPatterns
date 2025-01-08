// Este problema consiste em uma classe que tem comportamentos diferentes dependendo do seu estado
// Neste exemplo o Orçamento só pode receber descontos nos 2 primeiros estados

namespace State.Problema
{
    public class Orcamento
    {
        public enum StatusOrcamento
        {
            EmAprovacao = 1,
            Aprovado = 2,
            Reprovado = 3,
            Finalizado = 4
        }

        public double Valor { get; private set; }

        // Outro problema, é este status ser publico, caso existam regras para ele ser mudadi, esta classe vai estar realizando muitas funções, aumentando a complexidade.
        // Por exemplo, o orçamento não pode mudar de EmAprovacao para Finalizado.
        public StatusOrcamento Status { get; set; }

        public Orcamento(double valor)
        {
            Valor = valor;
            Status = StatusOrcamento.EmAprovacao;
        }

        public void AplicaDescontoExtra()
        {
            switch (this.Status)
            {
                case StatusOrcamento.EmAprovacao:
                    this.Valor -= this.Valor * 0.05;
                break;

                case StatusOrcamento.Aprovado:
                    this.Valor -= this.Valor * 0.02;
                break;

                case StatusOrcamento.Reprovado:
                    throw new Exception("Não é possivel aplicar desconto em um orçamento reprovado.");
                break;

                case StatusOrcamento.Finalizado:
                    throw new Exception("Não é possivel aplicar desconto em um orçamento reprovado.");
                break;

                // A problematica esta em uma infinita criação de status e regras que podem crescer este método e aumentar complexidade.
            }
        }
    }
}
