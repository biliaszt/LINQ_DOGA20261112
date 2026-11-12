using LINQdoga;
using System.Reflection.Metadata;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;

#region file beolvasas
#nullable disable
List<Videojatek> jatekok = new List<Videojatek>();
const string FilePath = "..\\..\\..\\data\\videogames.csv";
using StreamReader sr = new(FilePath);
_ = sr.ReadLine();

while (!sr.EndOfStream)
{
    var tmp = sr.ReadLine().Split(",");
    jatekok.Add(new()
    {
        Cim = tmp[0],
        Mufaj = tmp[1],
        KiadasDatum = DateTime.Parse(tmp[2]),
        AktivJatekosok = int.Parse(tmp[3]),
        Ertekeles = double.Parse(tmp[4].Replace('.', ',')),
    });
}
#endregion

Console.WriteLine("\n1.");
var fel1 = jatekok.Count(j => j.Ertekeles > 4.5);
Console.WriteLine($"{fel1} db ilyen játék van");

Console.WriteLine("\n2.");
var fel2 = jatekok.MaxBy(j => j.AktivJatekosok);
Console.WriteLine($"{fel2.Cim}-val/vel játszanak a legtöbben");

Console.WriteLine("\n3.");
var fel3 = jatekok.Any(j => j.KiadasDatum.Year < 2020);
if (fel3)
{
    Console.WriteLine("Igen, van ilyen játék");
}
else
{
    Console.WriteLine("Nem, nincs ilyen játék");
}

Console.WriteLine("\n4.");
var fel4 = jatekok.Average(j => j.Ertekeles);
Console.WriteLine($"Játékok értékelésének átlaga: {fel4:0.00}");

Console.WriteLine("\n5.");
var fel5 = jatekok.Single(j => j.Cim == "Cyber City 2077");
Console.WriteLine($"{fel5.Cim}");

Console.WriteLine("\n6.");
var fel6 = jatekok.Where(j => j.Mufaj == "RPG").OrderByDescending(j => j.KiadasDatum);
foreach (var jatek in fel6)
{
    Console.WriteLine($"\t{jatek.Cim}");
}

Console.WriteLine("\n7.");
var fel7 = jatekok.OrderByDescending(j => j.Ertekeles).Take(3);
foreach (var jatek in fel7)
{
    Console.WriteLine($"\t{jatek.Cim}");
}

Console.WriteLine("\n8.");
var fel8 = jatekok.Where(j => j.KiadasDatum.Year == 2022).Average(j => j.AktivJatekosok);
Console.WriteLine($"{fel8} az átlagos aktív játékosszám, a 2022 vagy azután kiadott játékokban");

Console.WriteLine("\n9.");
var mufajGroupBy = jatekok.GroupBy(j => j.Mufaj);
foreach (var fel9 in mufajGroupBy)
{
    Console.WriteLine($"\t{fel9.Key}: {fel9.Count()} db");
}

Console.WriteLine("\n10.");
foreach (var fel10 in mufajGroupBy)
{
    Console.WriteLine($"\t{fel10.Key}: {fel10.MaxBy(j => j.Ertekeles).Cim}");
}
