using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;


namespace PM_gokart
{
    
    internal class Program
    {
        static string Ekezet(string szoveg)
        {
            szoveg = szoveg.ToLower();
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
            string eredmeny = char.ToUpper(ujszo[0]) + ujszo.Substring(1);
            return eredmeny;
        }
        public class Versenyzo
        {
            public string venev;
            public string kenev;
            public string szul;
            public bool tizennyolc;
            public string azonosito;
            public string email;

            public Versenyzo(string venev, string kenev, string szul, bool tizennyolc, string azonosito, string email)
            {
                this.venev = venev;
                this.kenev = kenev;
                this.szul = szul;
                this.tizennyolc = tizennyolc;
                this.azonosito = azonosito;
                this.email = email;
            }
        }
        public static string Idopont(string szabad)
        {
            string asd = "";
            if (szabad == "")
            {
                asd = "szabad";
            }
            else
            {
                asd = "foglalt";
                
            }
            return asd;
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
                string azonosito = $"Go-{Ekezet(venev)}{Ekezet(kenev)}-{szul.Replace("/","").Replace(" ","")}";
                Console.WriteLine(azonosito);

                // email
                string email = Ekezet(venev) + "." + Ekezet(kenev) + "@gmail.com";
                Console.WriteLine(email);

                versenyok.Add(new Versenyzo(venev, kenev, szul, elmult, azonosito, email));
                Console.WriteLine("----------------------");
            }

            var napokDict = new Dictionary<string, Dictionary<string, string>>();

            DateTime ma = DateTime.Today;
            var napokmaradt = DateTime.DaysInMonth(ma.Year, ma.Month) - ma.Day + 1;

            for (int i = 0; i < napokmaradt; i++)
            {
                DateTime date = ma.AddDays(i);
                string datum = (date).ToString("yyyy.MM.dd");

                var orakDict = new Dictionary<string, string>();
                for (int j = 8; j < 19; j++)
                {
                    string asd = j.ToString() + "-" + (j + 1).ToString();
                    orakDict.Add(asd, "");
                }

                napokDict.Add(datum, new Dictionary<string, string>(orakDict));
            }

            
            Console.WriteLine("-----------------------");
            for (int i = 0; i < rnd.Next(1, numb); i++)
            {
                string randomversenyzo = versenyok[rnd.Next(0, numb)].azonosito;
                foreach(var item in napokDict)
                {
                    
                     
                    foreach (var item2 in item.Value)
                    {


                        var randomnapok = napokDict.Keys.ToList();                                
                        int index = rnd.Next(randomnapok.Count);
                        string randomnap = randomnapok[index];


                       
                    }
                }
                break;
            }
            Console.WriteLine("-----------------------");


            foreach (var item in napokDict)
            {
                Console.Write("\t\t");
                foreach (var item2 in item.Value)
                {
                    Console.Write($"{item2.Key.PadRight(9)}");
                }
                Console.WriteLine();
                break;
            }
            foreach (var item in napokDict)
            {
                Console.Write($"{item.Key} -");
                foreach (var item2 in item.Value)
                {
                    if (Idopont(item2.Value) == "szabad")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($" {Idopont(item2.Value),8}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {Idopont(item2.Value),8}");
                        Console.ResetColor();
                    }

                }
                Console.WriteLine();
            }

            
           
            while (true)
            {
                Console.Write("Szeretnél-e időpontot foglalni? (y/n): ");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    string nap;
                    string azonosito;
                    string ora;

                    while (true) 
                    {
                        Console.Write("Írj be egy azonosítót: ");
                        azonosito = Console.ReadLine();                    
                        Console.Write("Hanyadikán? ");
                        nap = Console.ReadLine();
                        Console.Write("Mettől meddig? ");
                        ora = Console.ReadLine();
                        break;
                    }
                   
                    foreach (var napok in napokDict)
                    {                      
                        if (napok.Key.Substring(napok.Key.Length - 2) == nap){                         
                            foreach(var orak in napok.Value)
                            {                                
                                if (ora == orak.Key)
                                {
                                    
                                    napokDict[napok.Key][orak.Key] += azonosito;
                                    break;
                                }                              
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            //kiiratás
            foreach (var item in napokDict)
            {
                Console.Write("\t\t");
                foreach (var item2 in item.Value)
                {
                   Console.Write($"{item2.Key.PadRight(9)}");
                }
                Console.WriteLine();
                break;
            }
            foreach (var item in napokDict)
            {
                Console.Write($"{item.Key} -");
                foreach (var item2 in item.Value)
                {
                    if (Idopont(item2.Value) == "szabad")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($" {Idopont(item2.Value),8}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {Idopont(item2.Value),8}");
                        Console.ResetColor();
                    }
                        
                }
                Console.WriteLine();
            }
            /*
            foreach (var item in napokDict)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine(item2);
                }
            }*/
            
            Console.WriteLine();
            Console.WriteLine("Nyomj meg egy gombot a kilépéshez");
            Console.ReadKey();
        }
    }
}
