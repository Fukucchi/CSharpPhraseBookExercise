using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmp;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            Product karinto = new Product(123, "かりんとう", 180);
            Product daifuku = new Product(235, "大福もち", 160);
            Product dorayaki = new Product(98, "どら焼き", 210);

            int karintoTax = karinto.GetTax();
            int daifukuTax = daifuku.GetTax();
            int dorayakiTax = dorayaki.GetTax();

            Console.WriteLine("{0} {1} {2}", karinto.Name, karinto.Price, karintoTax);
            Console.WriteLine("{0} {1} {2}", daifuku.Name, daifuku.Price, daifukuTax);
            Console.WriteLine("{0} {1} {2}", dorayaki.Name, dorayaki.Price, dorayakiTax);
            Console.ReadKey();



        }
    }
}
