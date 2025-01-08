
namespace State.Exercicio
{
    public class Conta
    {
        public StatusConta Status { get; set; }
        public double Saldo { get; set; }
        
        public Conta(double saldo)
        {
            Saldo = saldo;

            if (saldo > 0)
                Status = new StatusPositivo();
            else
                Status = new StatusNegativo();
        }

        public void Saca(double valor)
        {
            Status.Saca(valor, this);
        }

        public void Deposita(double valor)
        {
            Status.Deposita(valor, this);
        }
    }

    public interface StatusConta
    {
        public void Saca(double valor, Conta conta);
        public void Deposita(double valor, Conta conta);
    }

    public class StatusPositivo : StatusConta
    {
        public void Saca(double valor, Conta conta)
        {
            conta.Saldo -= valor;

            if (conta.Saldo < 0)
                Negativo(conta);
        }

        public void Deposita(double valor, Conta conta)
        {
            conta.Saldo += valor * 0.98;
        }

        private void Negativo(Conta conta)
        {
            conta.Status = new StatusNegativo();
        }  
    }

    public class StatusNegativo : StatusConta
    {
        public void Saca(double valor, Conta conta)
        {
            throw new Exception("Conta negativa, não é possível sacar.");
        }

        public void Deposita(double valor, Conta conta)
        {
            conta.Saldo += valor * 0.95;

            if (conta.Saldo > 0)
                Positivo(conta);
        }

        private void Positivo(Conta conta)
        {
            conta.Status = new StatusPositivo();
        }
    }
}
