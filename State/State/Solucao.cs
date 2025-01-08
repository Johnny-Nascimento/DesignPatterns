// A solução sugere criar uma classe para cada status, ela vai implementar tanto o desconto extra baseado em sua regra, quanto a permissão para mudança de status
// Isso faz com que cada status tenha sua propria responsabilidade de realizar as ações necessárias.

namespace State.Solucao
{
    public class Orcamento
    {
        public double Valor { get; set; }
        public EstadoOrcamento EstadoAtual { get; set; }

        public Orcamento(double valor)
        {
            Valor = valor;
            EstadoAtual = new EmAprovacao();
        }

        public void EmAprovacao()
        {
            EstadoAtual.EmAprovacaoOrcamento(this);
        }

        public void AplicaDescontoExtra()
        {
            EstadoAtual.AplicaDescontoExtra(this);
        }

        public void AprovaOrcamento()
        {
            EstadoAtual.AprovaOrcamento(this);
        }

        public void ReprovaOrcamento()
        {
            EstadoAtual.ReprovaOrcamento(this);
        }

        public void FinalizaOrcamento()
        {
            EstadoAtual.FinalizaOrcamento(this);
        }
    }

    public interface EstadoOrcamento
    {
        public void EmAprovacaoOrcamento(Orcamento orcamento);
        public void AprovaOrcamento(Orcamento orcamento);
        public void ReprovaOrcamento(Orcamento orcamento);
        public void FinalizaOrcamento(Orcamento orcamento);
        public void AplicaDescontoExtra(Orcamento orcamento);
    }

    public class EmAprovacao : EstadoOrcamento
    {
        private bool DescontoAplicado { get; set; }

        public void EmAprovacaoOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento ja se encontra nesse status.");
        }

        public void AprovaOrcamento(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Aprovado();
        }

        public void ReprovaOrcamento(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Reprovado();
        }

        public void FinalizaOrcamento(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            if (DescontoAplicado)
                throw new Exception("Desconto já aplicado.");

            orcamento.Valor -= orcamento.Valor * 0.05;
            DescontoAplicado = true;
        }
    }

    public class Aprovado : EstadoOrcamento
    {
        private bool DescontoAplicado { get; set; }

        public void EmAprovacaoOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento Aprovado não pode ter o status alterado para Em aprovação.");
        }

        public void AprovaOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento ja se encontra nesse status.");
        }
        public void ReprovaOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento Aprovado não pode ter o status alterado para Reprovado.");
        }

        public void FinalizaOrcamento(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            if (DescontoAplicado)
                throw new Exception("Desconto já aplicado.");

            orcamento.Valor -= orcamento.Valor * 0.02;
            DescontoAplicado = true;
        }
    }

    public class Reprovado : EstadoOrcamento
    {
        public void EmAprovacaoOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento Reprovado não pode ter o status alterado para Em aprovação.");
        }

        public void AprovaOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento Reprovado não pode ter o status alterado para Aprovado.");
        }
        public void ReprovaOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento ja se encontra nesse status.");
        }

        public void FinalizaOrcamento(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orçamento recusado não pode receber desconto.");
        }
    }

    public class Finalizado : EstadoOrcamento
    {
        public void EmAprovacaoOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento finalizado não pode ter o status alterado.");
        }

        public void AprovaOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento finalizado não pode ter o status alterado.");
        }

        public void ReprovaOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento finalizado não pode ter o status alterado.");
        }

        public void FinalizaOrcamento(Orcamento orcamento)
        {
            throw new Exception("Orçamento ja se encontra nesse status.");
        }

        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orçamento Finalizado não pode receber desconto.");
        }
    }
}
