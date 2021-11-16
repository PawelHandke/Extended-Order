using Extended_Order.Interface;
using Newtonsoft.Json.Linq;

namespace Extended_Order.Model
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price_brutto { get; set; }
        public uint Quantity { get; set; }
        public float Weight { get; set; }
        public JObject jsonProduct { get; private set; }

        public Product()
        {

        }
        public Product(JObject jsonData)
        {
            Name = jsonData["name"].ToString();
            Price_brutto = decimal.Parse(jsonData["price_brutto"].ToString());
            Quantity = uint.Parse(jsonData["quantity"].ToString());
            Weight = float.Parse(jsonData["weight"].ToString());
            jsonProduct = jsonData;
        }
    }
}
