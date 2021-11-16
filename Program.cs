using Extended_Order.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Extended_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            API api = new API();
            var orders = new OrderBuilder(api.GetNewOrders());

            if (orders.OrderList.Count == 0)
            {
                Console.WriteLine("Brak zamówień do przetowrzenia");
                Console.ReadLine();
                return;
            }

            Product productGratis = new ProductBuilder()
                .SetName("Gratis")
                .SetPrice_brutto((decimal)1.00)
                .GetProduct();

            orders.OrderList.ForEach(x => x.AddProduct(productGratis));

            foreach (var newOrder in orders.OrderList)
            {
                api.AddNewOrder(newOrder);
            }

            Console.ReadLine();
        }
    }
}
