using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace PM_gokart
{
    
    internal class Program
    {
        static string Ekezet(string szoveg)
        {
            string ujszo = "";
            Dictionary<char, string> ekezet = new Dictionary<char, string>()
        {
            {'á',"a"},
            {'é',"e"},
            {'ú',"u"},
            {'ű',"u"},
            {'ő',"o"},
            {'ó',"o"},
            {'ü',"u"},
            {'ö',"o"},
            {'í',"i"}
        };
            for (int i = 0; i < szoveg.Length; i++)
            {
                if (ekezet.ContainsKey(szoveg[i]))
                {
                    ujszo += ekezet[szoveg[i]];
                }
                else
                {
                    ujszo += szoveg[i];
                }
            }
            return ujszo;
        }
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
            string gonev = "Nyíregyházi Gokart pálya";
            string gocím = "László U 8, Nyíregyháza, Szabolcs-Szatmár-Bereg, 4400";
            string telsz = "+36-30-426-1265";
            string web = "nyiregygokart@gmail.com";

            Console.WriteLine($"Üdvözlünk a {gonev}-n\n{gocím}\n{telsz}\n{web}");
            string fejlec = "Gokart időpontfoglaló ";
            Console.WriteLine(fejlec);
            for (int i = 0; i < fejlec.Length; i++) Console.Write('-');
            Console.WriteLine();

            


            
           


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
            
            List<Versenyzo> versenyok = new List<Versenyzo>();

            for (int i = 0; i < numb; i++)
            {
                //név
                
                string venev = vezeteknev[rnd.Next(vezeteknev.Count)];
                string kenev = keresztnevek[rnd.Next(keresztnevek.Count)];
                Console.WriteLine($"{venev}-{kenev}");


                //év
                DateTime start = new DateTime(1950, 1, 1);
                string today = DateTime.Today.ToString("yyyy/MM/dd");
                int range = (DateTime.Today - start).Days;
                string szul = start.AddDays(rnd.Next(range)).ToString("yyyy/MM/dd");
                Console.WriteLine(szul);
                // elmult 18?
                var age = Math.Floor((DateTime.Now - DateTime.Parse(szul)).TotalDays / 365.242199);
                bool elmult = false;
                if (age >= 18)
                {
                    elmult = true;
                }
                // azonositó
                
                string azonosito = $"Go-{Ekezet(venev)}{Ekezet(kenev)}-{szul.Replace(".","").Replace(" ","")}";
                Console.WriteLine(azonosito);

                
                
                // email
                string email = Ekezet(venev) + "." + Ekezet(kenev) + "@gmail.com";
                Console.WriteLine(email);

                versenyok.Add(new Versenyzo(venev, kenev, szul, elmult, azonosito));
                Console.WriteLine("----------------------");
            }

            /*
            foreach (Versenyzo versenyzo in versenyok)
            {
                Console.WriteLine(versenyzo.szul);
            }*/

            var orakDict = new Dictionary<string, bool>();
            for (int i= 8; i < 19; i ++ )
            {
                string asd = i.ToString() + "-" + (i+1).ToString();
                orakDict.Add(asd, true);
            }

            foreach (var item in orakDict)
            {
                Console.WriteLine(item.Key + item.Value);
            }

            var napokDict = new Dictionary<string, Dictionary<string,bool>>();

            DateTime ma = DateTime.Today;
            var napokmaradt = DateTime.DaysInMonth(ma.Year, ma.Month) - ma.Day + 1;

            for (int i = 0; i < napokmaradt; i++)
            {
                DateTime date = ma.AddDays(i);
                string datum = (date).ToString("yyyy.MM.dd");
                
                Console.WriteLine(datum);
                napokDict.Add(datum, orakDict);
                
            }

            foreach (var item in napokDict)
            {
                Console.WriteLine(item.Key + item.Value);
            }

                //https://stackoverflow.com/questions/41029249/dictionary-of-dictionaries-in-c-sharp
                Console.WriteLine();
            Console.WriteLine("Nyomj meg egy gombot a kilépéshez");
            Console.ReadKey();
        }
    }
}
