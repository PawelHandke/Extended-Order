using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extended_Order.Model
{
    class Order
    {
        private long order_id = 0;
        
        List<Product> productsList;
        public JObject JsonOrder { get; private set; }

        public Order(JObject jObject)
        {
            order_id = long.Parse(jObject["order_id"].ToString());
            
            SetProducts((JArray)jObject["products"]);
            JsonOrder = jObject;
        }

        private void SetProducts(JArray jArray)
        {
            foreach (var item in jArray.Children<JObject>())
            {
                productsList.Add(new Product(item));
            }
        }

        public void AddProduct(Product product)
        {
            JArray jArray = JsonOrder["products"] as JArray;
            JsonOrder.Remove("products");
            jArray.Add(JToken.Parse(product.jsonProduct.ToString()));
            JsonOrder.Add("products", jArray);
            
            productsList.Add(product);

            Console.WriteLine("Do zamówienia nr dodano produkt " + product.Name);
        }

        public JObject GetNewOrder()
        {
            JObject jObject = new JObject();
            foreach (string field in fields)
            {
                jObject.Add(field, JsonOrder[field]);
            }

            jObject["user_comments"] = "Zamówienie utworzone na podstawie " + order_id.ToString();
            Console.WriteLine("Zbudowano nowe zamówienie wraz z notatką w polu \"user_comments\"");
            return jObject;
        }

        List<string> fields = new List<string>() { "order_status_id", "date_add", "user_comments", "admin_comments", "phone", "email", "user_login", "currency", "payment_method",
            "payment_method_cod", "paid",    "delivery_method",    "delivery_price",    "delivery_fullname",    "delivery_company",    "delivery_address",    "delivery_city",
            "delivery_postcode",    "delivery_country_code",    "delivery_point_id",    "delivery_point_name",    "delivery_point_address",    "delivery_point_postcode",
            "delivery_point_city",    "invoice_fullname",    "invoice_company",    "invoice_nip",    "invoice_address",    "invoice_city",    "invoice_postcode",    "invoice_country_code",
            "want_invoice",    "extra_field_1",    "extra_field_2",    "products"};
    }
}
