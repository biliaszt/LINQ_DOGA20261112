using System;
using System.Collections.Generic;
using System.Text;

namespace LINQdoga
{
    internal class Videojatek
    {
        public string Cim { get; set; }
        public string Mufaj { get; set; }
        public DateTime KiadasDatum { get; set; }
        public int AktivJatekosok { get; set; }
        public double Ertekeles {  get; set; }

        public override string ToString() =>
            $"\tCím: {Cim}\n" +
            $"\tMűfaj: {Mufaj}\n" +
            $"\tKiadás dátuma: {KiadasDatum}" +
            $"\tAktív játékosok: {AktivJatekosok}" +
            $"\tÉrtékelés: {Ertekeles}";
    }
}
