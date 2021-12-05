using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task16._2
{
    public class Product
    {
        public int code { get; set; }
        public string name { get; set; }
        public float price { get; set; }

        public Product(int code, string name, float price)
        {
            this.code = code;
            this.name = name;
            this.price = price;
        }
    }

    internal class Program
    {
        static void Main()
        {
            float maxPrice = 0;
            string nameOfMaxPrice = "";

            Product[] products = new Product[5];

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            StreamReader sr = new StreamReader("Products.json");
            string jsonString = sr.ReadToEnd();
            sr.Close();

            products = JsonSerializer.Deserialize<Product[]>(jsonString,options);

            maxPrice = products[0].price;
            nameOfMaxPrice = products[0].name;

            for (int i = 0; i < 5; i++)
            {
                if (products[i].price > maxPrice)
                {
                    maxPrice = products[i].price;
                    nameOfMaxPrice = products[i].name;
                }
               
            }
            Console.WriteLine($"Продукт с максимальной ценой: {nameOfMaxPrice}");


            Console.ReadKey();

        }
    }
}
