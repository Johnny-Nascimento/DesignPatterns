// O problema é o seguinte, realizar a soma de impostos pode ser complicada, tendo que instanciar varias classes fazer a soma e apresentar o resultado.
// Dependendo da situação isso pode ficar muito grande e acabar ficando confuso.
// Seria possivel criar classes como ICMScomISS... Mas isso poderia acabar ficando mais confuso ainda.

namespace Decorator.Problema
{
    public class Orcamento
    {
        public Orcamento(double valor) => Valor = valor;
        public double Valor { get; private set; }
    }

    public interface IImposto
    {
        double Calcula(Orcamento orcamento);
    }

    public class ICMS : IImposto
    {
        public double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05 + 50;
        }
    }

    public class ISS : IImposto
    {
        public double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }

    public class SomadorDeImpostos
    {
        public void SomaImpostos()
        {
            Orcamento orcamento = new Orcamento(500);

            ISS iss = new ISS();
            double impostoCalculado = iss.Calcula(orcamento);

            ICMS icms = new ICMS();
            impostoCalculado += icms.Calcula(orcamento);

            // ... e assim por diante, quantas vezes forem necessárias.

            Console.WriteLine(impostoCalculado);
        }
    }
}
