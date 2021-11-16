using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Text;

namespace Extended_Order.Model
{
    class API
    {
        WebClient webClient;

        public const string SUCCESS = "SUCCESS";
        public const string ERROR = "ERROR";
        public API()
        {
            webClient = new WebClient();
            webClient.BaseAddress = "https://api.baselinker.com/connector.php";
            WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
            webHeaderCollection.Add("x-bltoken", "3003370-3015175-J3OMCXGI864YIE3QAK2KMOYZA3PMLVGT6AHQOCTPYQQ6TQP5ZKMNADQRG7NJYDQS");
            webClient.Headers.Add(webHeaderCollection);
            webClient.Encoding = Encoding.UTF8;
        }
        private string GetNewOrdersFromApi()
        {
            return webClient.UploadString("?method=getOrders", "{}");
        }

        public JObject GetNewOrders()
        {
            string jsonString = GetNewOrdersFromApi();
            return JObject.Parse(jsonString);
        }

        public void AddNewOrder(Order order)
        {
            webClient.UploadString("?method=addOrder", order.GetNewOrder().ToString());
            Console.WriteLine("Dodano nowe zamówienie ");
        }
    }
}
