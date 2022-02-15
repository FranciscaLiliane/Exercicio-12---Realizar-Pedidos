using System;
using System.Collections.Generic;
using Exercicio_12.Entities.Enums;
using System.Globalization;

namespace Exercicio_12.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Itens { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {

        }
        public Order(DateTime moment, Client client)
        {
            Moment = moment;
            Client = client;
        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void addItem(OrderItem item)
        {
            Itens.Add(item);
        }
        public void removeItem(OrderItem item)
        {
            Itens.Remove(item);
        }
        public double total()
        {
            double sum = 0.0;
            foreach(OrderItem item in Itens)
            {
                sum += item.subTotal();
            }
            return sum;
        }
        public void viewItem()
        {
            foreach (OrderItem item in Itens)
            {
                Console.WriteLine(item.product.Name +" "+ item.Quantity +" "+ total().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
        public override string ToString()
        {
            return Moment
                + ", "
                + Status;
        }
    }
}
