using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CBradio
{
    class Program
    {
        static void Main(string[] args)
        {
            var hivasok = new List<Hivas>();
            using var sr = new StreamReader(
                path: @"..\..\..\src\cb.txt",
                encoding: System.Text.Encoding.UTF8);
            _ = sr.ReadLine();
            while (!sr.EndOfStream) hivasok.Add(new(sr.ReadLine()));

            Console.WriteLine($"3. feladat: a bejegyzések száma: {hivasok.Count}");

            bool f4 = hivasok.Any(h => h.AdasDB == 4);
            Console.WriteLine($"4. feladat: {(f4 ? "Volt" : "Nem volt")} 4 adast indító sofőr");

            Console.Write("Kérek egy nevet:  ");
            string knev = Console.ReadLine();
            int f5  = hivasok
                .Where(h => h.Nev.ToLower() == knev.ToLower())
                .Sum(h => h.AdasDB);
            Console.WriteLine("5. feladat:");
            if (f5 != 0) Console.WriteLine($"{knev} {f5}x használta a CB rádiót");
            else Console.WriteLine("Nincs ilyen nevű sofőr");

            using var sw = new StreamWriter(
                path: @"..\..\..\src.cb2.txt",
                append: false,
                encoding: Encoding.UTF8);
            sw.WriteLine("Kezdes;Nev;AdasDb");
            foreach (var h in hivasok)
            {
                sw.WriteLine($"{h.IdoPercben};{h.Nev};{h.AdasDB}");
            }

            var f8 = hivasok
                .GroupBy(h => h.Nev)
                .ToDictionary(n => n.Key, hsz => hsz.Sum(h => h.AdasDB));
            Console.WriteLine($"8. feladat: A sofőrök száma: {f8.Count} fő");

            var f9 = f8.OrderBy(kvp => kvp.Value).Last();
            Console.WriteLine("9. feladat:");
            Console.WriteLine($"A legtöbbb adást indító sofőr: {f9.Key}");
            Console.WriteLine($"{f9.Value} alkalommal");
        }
    }
}
