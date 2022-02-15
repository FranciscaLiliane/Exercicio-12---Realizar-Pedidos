using System;

namespace Exercicio_12.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product product { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            this.product = product;
            Price = product.Price;
        }

        public double subTotal()
        {
            return Quantity*Price;
        }
    }
}
