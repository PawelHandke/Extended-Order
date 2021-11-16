using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extended_Order.Model
{
    class ProductBuilder
    {
        Product product;

        public ProductBuilder()
        {
            product = new Product();
            product.Name = "";
            product.Price_brutto = decimal.Zero;
            product.Quantity = uint.MinValue;
            product.Weight = float.NaN;
        }

        public ProductBuilder SetName(string name)
        {
            product.Name = name;
            return this;
        }

        public ProductBuilder SetPrice_brutto(decimal value)
        {
            product.Price_brutto = value;
            return this;
        }

        public ProductBuilder SetQuantity(uint value)
        {
            product.Quantity = value;
            return this;
        }

        public ProductBuilder SetQuantity(float value)
        {
            product.Weight = value;
            return this;
        }

        public Product GetProduct()
        {
            Console.WriteLine("Stworzono nowy produkt o nazwie " + product.Name);
            return product;
        }
    }
}
