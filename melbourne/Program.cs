using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace melbourne
{

    class Jatekosok
    {
        public string nev { get; set; }
        public string nemzetiseg { get; set; }
        public string csapat { get; set; }
        public int rajtpozicio { get; set; }
        public double idő { get; set; }

        public int pont { get; set; }

        public Jatekosok(string nev, string nemzetiseg, string csapat, int rajtpozicio, double idő, int pont)
        {
            this.nev = nev;
            this.nemzetiseg = nemzetiseg;
            this.csapat = csapat;
            this.rajtpozicio = rajtpozicio;
            this.idő = idő;
            this.pont = pont;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Jatekosok> jatekosok = new List<Jatekosok>();
            using(StreamReader reader = new StreamReader("C:\\Users\\Ny20VisegrádiT\\source\\repos\\melbourne\\melbourne\\src\\melbourne2009.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(';');

                    jatekosok.Add(new Jatekosok(parts[0], parts[1], parts[2], int.Parse(parts[3]), double.Parse(parts[4], CultureInfo.InvariantCulture), int.Parse(parts[5])));
                }
            }

            Console.WriteLine("\n1.feladat");

            Console.WriteLine($"A célba ért pilóták száma: {jatekosok.Count()}");

            Console.WriteLine("\n2.feladat");

            var vilagbajnok_pont = jatekosok.Select(n => n.pont).Sum();

            Console.WriteLine($"A világbajnoki pontok száma: {vilagbajnok_pont}");

            Console.WriteLine("\n3.feladat");

            var nemet = jatekosok.Where(n => n.nemzetiseg == "germany");

            foreach (var item in nemet)
            {
                Console.WriteLine(item.nev);
            }

            Console.WriteLine($"{nemet.Count()} német versenyző érkezett célba.");

            Console.WriteLine("\n4.feladat");

            var vilagbajnokCsapatok = jatekosok.Where(n => n.pont != 0).Select(n => n.csapat).Distinct().ToList();

            Console.WriteLine("\nA csapatok:\n");
            foreach (var csapat in vilagbajnokCsapatok)
            {
                Console.WriteLine(csapat); 
            }




            Console.WriteLine("\n5.feladat");

            var first = jatekosok.FirstOrDefault(n => n.rajtpozicio == 1);

            Console.WriteLine($"{first.nev} nyerte meg a versenyt {first.idő} másodperccel");


        }
    }
}
