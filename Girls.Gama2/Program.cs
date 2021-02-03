using Girls.Gama2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Girls.Gama2
{
    class Program
    {
        private static List<Boleto> listaBoleto;
        private static List<Dinheiro> listaDinheiro;

        static void Main(string[] args)
        {
            listaBoleto = new List<Boleto>();
            listaDinheiro = new List<Dinheiro>();

            while (true)
            {
                Console.WriteLine("\n\n===============================================================");
                Console.WriteLine("======================== LOJA DA AMANDA =======================\n");
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1-Compra | 2-Pagar Boleto | 3-Relatório");

                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Comprar();
                        break;
                    case 2:
                        PagamentoBoleto();
                        break;
                    case 3:
                        Relatorio();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Comprar()
        {
            Console.WriteLine("\nForma de pagamento:");
            Console.WriteLine("1-Dinheiro | 2-Boleto");

            var opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Dinheiro();
                    break;
                case 2:
                    Boleto();
                    break;
                default:
                    break;
            }

        }

        public static void Dinheiro()
        {
            Console.WriteLine("Digite o valor da compra:");
            var valor = Double.Parse(Console.ReadLine());

            Console.WriteLine("Valor recebido: ");
            var recebido = Double.Parse(Console.ReadLine());

            var dinheiro = new Dinheiro(valor);
            dinheiro.DarDesconto();

            Console.WriteLine($"\nCompras a vista tem desconto de 5% === R$ {dinheiro.Valor}");

            if (recebido > valor || dinheiro.Valor < valor)
            {
                var troco = recebido - dinheiro.Valor;
                Console.WriteLine($"\nO valor do troco é de === R$ {troco}");
            }

            listaDinheiro.Add(dinheiro);
        }

        public static void Boleto()
        {

            Console.WriteLine("Digite o valor da compra:");
            var valor = Double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o CPF do cliente:");
            var cpf = Console.ReadLine();

            Console.WriteLine("Digite uma descricao da compra:");
            var descricao = Console.ReadLine();

            var boleto = new Boleto(valor, cpf, descricao);
            boleto.GerarBoleto();

            Console.WriteLine($"\nCompra realizada com sucesso {boleto.CodigoBarra} com a data de vencimento para o dia {boleto.DataVencimento}");

            listaBoleto.Add(boleto);
        }


        public static void PagamentoBoleto()
        {
            Console.WriteLine("Digite o codigo de barras: ");
            var numero = Guid.Parse(Console.ReadLine());

            var boleto = listaBoleto
                           .Where(item => item.CodigoBarra == numero)
                           .FirstOrDefault();
            if (boleto is null)
            {
                Console.WriteLine($"Boleto de código {numero} não encontrado!");
                return;
            }

            if (boleto.EstaPago())
            {
                Console.WriteLine($"\nO boleto foi pago dia {boleto.DataPagamento}");
            }

            if (boleto.EstaVencido())
            {
                boleto.CalcularJuros();
                Console.WriteLine($"\nBoleto está vencido e terá acrescimo de 10% === R$ {boleto.Valor}");

            }

            boleto.Pagar();
            Console.WriteLine($"\nBoleto de código {numero} foi pago com sucesso!");

        }

        public static void Relatorio()
        {
            Console.WriteLine("Qual opção de relatório:");
            Console.WriteLine("1-Boletos Pagos | 2-Boletos à vencer | 3-Boletos Vencidos | 4-Compras Finalizadas");

            var opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    BoletosPagos(true);
                    break;
                case 2:
                    BoletosAVencer();
                    break;
                case 3:
                    BoletosVencidos();
                    break;
                case 4:
                    TodasAsCompras();
                    break;
                default:
                    break;
            }
        }

        public static List<Boleto> BoletosPagos(bool? direto)
        {
            if (direto == true)
            {
                Console.WriteLine("---------------------------- INÍCIO DO RELATÓRIO ----------------------------");
                Console.WriteLine("----------------------------    BOLETOS PAGOS    ----------------------------");
            }

            var boletos = listaBoleto
                                .Where(item => item.Confirmacao == true)
                                .ToList();

            foreach (var item in boletos)
            {
                Console.WriteLine($"Código de barra: {item.CodigoBarra} \nValor: R$ {item.Valor} \nData Pagamento: {item.DataPagamento}");
            }
            Console.WriteLine("---------------------------- FIM DO RELATÓRIO  ----------------------------\n\n");

            return boletos;
        }

        public static void BoletosAVencer()
        {
            var boletos = listaBoleto
                                .Where(item => item.Confirmacao == false
                                    && item.DataVencimento > DateTime.Now)
                                .ToList();

            if (boletos is null)
            {
                Console.WriteLine($"\n\nNão há boletos a vencer.");
            }
            else
            {
                Console.WriteLine("---------------------------- INÍCIO DO RELATÓRIO ----------------------------");
                Console.WriteLine("----------------------------   BOLETOS À VENCER  ----------------------------");

                foreach (var item in boletos)
                {
                    Console.WriteLine($"\nCódigo de barras: {item.CodigoBarra} \nValor: R$ {item.Valor} \nData Vencimento: {item.DataVencimento}");
                }

                Console.WriteLine("---------------------------- FIM DO RELATÓRIO  ----------------------------\n\n");
            }

        }

        public static void BoletosVencidos()
        {
            var boletos = listaBoleto
                                .Where(item => item.Confirmacao == false
                                    && item.DataVencimento < DateTime.Now)
                                .ToList();

            if (boletos is null)
            {
                Console.WriteLine("Não existem boletos vencidos!");
            }
            else
            {

                Console.WriteLine("---------------------------- INÍCIO DO RELATÓRIO ----------------------------");
                Console.WriteLine("----------------------------   BOLETOS VENCIDOS  ----------------------------");
                foreach (var item in boletos)
                {
                    Console.WriteLine($"Código de barra: {item.CodigoBarra} \nValor: R$ {item.Valor} \nData Pagamento: {item.DataVencimento}");
                }
                Console.WriteLine("----------------------------  FIM DO RELATÓRIO  ----------------------------\n\n");

            }
        }


        public static void TodasAsCompras()
        {

            Console.WriteLine("---------------------------- INÍCIO DO RELATÓRIO ----------------------------");
            Console.WriteLine("---------------------------- COMPRAS FINALIZADAS ----------------------------");
           
            foreach (var item in listaDinheiro)
            {
                Console.WriteLine($"Descrição: {item.DescricaoCompra} \nValor: R$ {item.Valor} \nData Pagamento: {item.DataPagamento}");
            }

            var boletos = BoletosPagos(false);
        }



    }
}
