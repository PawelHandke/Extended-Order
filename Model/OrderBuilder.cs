using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Extended_Order.Model
{
    class OrderBuilder
    {
        public OrderBuilder(JObject jObject)
        {
            OrderList = new List<Order>();
            if (jObject["status"].ToString() == API.SUCCESS)
            {
                JArray jArray = jObject["orders"] as JArray;
                foreach (var item in jArray.Children<JObject>())
                {
                    OrderList.Add(new Order(item));
                }

                Console.WriteLine("Pobrano listę zamówien.");
            }
            else
            {
                Console.WriteLine("Nie udało się połączyć z API.");
                Console.WriteLine(jObject["error_code"]);
                Console.WriteLine(jObject["error_message"]);
            }
        }

        public List<Order> OrderList { get; private set; }
    }
}
