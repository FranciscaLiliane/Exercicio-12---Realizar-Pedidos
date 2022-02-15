using Exercicio_12.Entities;
using System;
using System.Globalization;
namespace Exercicio_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite seu nome: ");
            string name = Console.ReadLine();
            Console.Write("Digite seu email: ");
            string email = Console.ReadLine();
            Console.Write("Digite sua data de nascimento: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            DateTime date = DateTime.Now;
            Order order = new Order(date, client);
            bool saida = true;
            while (saida)
            {
                Console.WriteLine("O que deseja fazer(1 = Realizar pedido, 2 = Apagar item, 3 = Visualizar pedido e 4 = Realizar pagamento): ");
                int num = int.Parse(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        Console.Write("Deseja pedir quantos itens? ");
                        int numItens = int.Parse(Console.ReadLine());

                        for (int i = 0; i < numItens; i++)
                        {
                            Console.Write("Digite o nome do produto: ");
                            string nameP = Console.ReadLine();
                            Console.Write("Digite o preço do produto: ");
                            double priceP = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Product product = new Product(nameP, priceP);

                            Console.Write("Digite a quantidade do produto: ");
                            int qtd = int.Parse(Console.ReadLine());
                            OrderItem item = new OrderItem(qtd, product);
                            order.addItem(item);
                        }
                        break;
                    case 2:
                        Console.Write("Digite o nome do produto: ");
                        string nameP2 = Console.ReadLine();
                        Console.Write("Digite o preço do produto: ");
                        double priceP2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Product product2 = new Product(nameP2, priceP2);

                        Console.Write("Digite a quantidade do produto: ");
                        int qtd2 = int.Parse(Console.ReadLine());
                        OrderItem item2 = new OrderItem(qtd2, product2);
                        order.removeItem(item2);
                        break;
                    case 3:
                        Console.WriteLine();
                        order.viewItem();
                        Console.WriteLine(order.ToString());
                        break;
                    case 4:
                        order.Status = (Entities.Enums.OrderStatus)1;
                        Console.WriteLine(order.ToString());
                        Console.WriteLine("Insira o valor do pagamento: ");
                        double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        double total = order.total();
                        if (value >= total)
                        {
                            order.Status = (Entities.Enums.OrderStatus)2;
                            Console.WriteLine(order.ToString());

                        }
                        else
                        {
                            Console.WriteLine("Valor abaixo do total a ser pago! ");
                        }
                        break;
                    default:
                        saida = false;
                        break;
                }
            }
            order.Status = (Entities.Enums.OrderStatus)3;
            Console.WriteLine(order.ToString());
        }
    }
}
