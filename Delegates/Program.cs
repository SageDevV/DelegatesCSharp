namespace DelegatsAndEvents
{

    public class Program
    {
        public delegate void OperacaoMatematica(double x, double y);
        static void Main(string[] args)
        {
            //Os delegates referenciam métodos desde que tenham a mesma assinatura e tipo de retorno. Sendo assim, eles tem uma natureza multicast
            //Existe 3 formas de executar um método, a partir de uma chamada/invocação de método, que seria o mais comum.
            //Um método anônimo que seria uma referência de método.
            //E um método anônimo que referencia um método com expressão lambda.

            List<OperacaoMatematica>? operacoesMatematicas = new List<OperacaoMatematica>();
            operacoesMatematicas.Add(new OperacaoMatematica(Multiplicacao));
            operacoesMatematicas.Add(new OperacaoMatematica(Potenciacao));
            operacoesMatematicas.Add(new OperacaoMatematica(Radiciacao));

            operacoesMatematicas.Add(delegate (double x, double y)
            {
                double result = x / y;
                Console.WriteLine($"O resultado da divisão com delegate anônimo de {x} / {y} é {result}");
            });

            operacoesMatematicas.Add((x, y) => 
            {
                double result = x * y;
                Console.WriteLine($"O resultado da multiplicação com delegate anônimo e expressão lambda entre {x} e {y} é {result}");
            });

            foreach (var operacaoMatematica in operacoesMatematicas)
            {
                operacaoMatematica(1, 5);
            }

            OperacaoMatematica opMulticast = Multiplicacao;
            opMulticast += Potenciacao;
            opMulticast += Radiciacao;
            opMulticast += delegate (double x, double y)
            {
                double result = x / y;
                Console.WriteLine($"O resultado da divisão com delegate anônimo de {x} / {y} é {result}");
            };

            opMulticast += (x, y) =>
            {
                double result = x * y;
                Console.WriteLine($"O resultado da multiplicação com delegate anônimo e expressão lambda entre {x} e {y} é {result}");
            };

            Console.WriteLine();
            opMulticast(5, 4);
        }

        public static void Multiplicacao(double x, double y)
        {
            Console.WriteLine($"O resultado da multiplicação com referência de método entre {x} e {y} é {x * y}");
        }

        public static void Potenciacao(double x, double y)
        {
            Console.WriteLine($"O resultado da potencia com referência de método de {x} elevado a {y} é {Math.Pow(x, y)}");
        }

        public static void Radiciacao(double x, double y)
        {
            var result = x + y;
            Console.WriteLine($"O resultado da radiciação com referência de método de 4 é {Math.Sqrt(result)}");
        }
    }
}
