using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_gokart
{
    internal class Program
    {
        public class Versenyzo
        {
            public string venev;
            public string kenev;
            public string szul;
            public bool tizennyolc;
            public string azonosito;

            public Versenyzo(string venev, string kenev, string szul, bool tizennyolc, string azonosito)
            {
                this.venev = venev;
                this.kenev = kenev;
                this.szul = szul;
                this.tizennyolc = tizennyolc;
                this.azonosito = azonosito;
            }
        }
        static void Main(string[] args)
        {
            /*
            Gokart időpontfoglaló 
            PM - 2025.09.15
            */
            string fejlec = "Gokart időpontfoglaló ";
            Console.WriteLine(fejlec);
            for (int i = 0; i < fejlec.Length; i++) Console.Write('-');
            Console.WriteLine();

            


            string gonev = "Nyíregyházi Gokart pálya";
            string gocím = "László U 8, Nyíregyháza, Szabolcs-Szatmár-Bereg, 4400";
            string telsz = "+36-30-426-1265";
            string web = "nyiregygokart@gmail.com";

           


            StreamReader ve = new StreamReader("vezeteknevek.txt");
            List<string> vezeteknev = new List<string>();
            StreamReader ke = new StreamReader("keresztnevek.txt");
            List<string> keresztnevek = new List<string>();
            string sor;
            string sor2;
            string[] reszek;
            string[] reszek2;
            

            sor = ve.ReadToEnd();
            sor2 = ke.ReadToEnd();

            while (sor != null)
            {
                reszek = sor.Replace("'","").Split(',');
                reszek2 = sor2.Replace("'","").Split(',');           
                for (int i = 0;i < reszek.Length; i++)
                {                   
                    vezeteknev.Add(reszek[i].Trim());
                }
                for (int i = 0; i < reszek2.Length; i++)
                {
                    keresztnevek.Add(reszek2[i].Trim());
                }
                sor = ve.ReadLine();
            }
            Random rnd = new Random();
            int numb = rnd.Next(1, 51);
            for (int i = 0; i < numb; i++)
            {
                Console.WriteLine($"{vezeteknev[rnd.Next(vezeteknev.Count)]}-{keresztnevek[rnd.Next(keresztnevek.Count)]}");
                string venev = vezeteknev[rnd.Next(vezeteknev.Count)];
                string kenev = keresztnevek[rnd.Next(keresztnevek.Count)];

                //év
                DateTime start = new DateTime(1950, 1, 1);
                string today = DateTime.Today.ToString("yyyy/MM/dd");
                int range = (DateTime.Today - start).Days;
                string szul = start.AddDays(rnd.Next(range)).ToString("yyyy/MM/dd");
                // 18>?
                var age = (DateTime.Now - DateTime.Parse(szul)).TotalDays / 365.242199;
                Console.WriteLine(age);

                
                Console.WriteLine(szul);

                //new Versenyzo(venev,kenev, szul)
            }
            

            Console.WriteLine("Nyomj meg egy gombot a kilépéshez");
            Console.ReadKey();
        }
    }
}
