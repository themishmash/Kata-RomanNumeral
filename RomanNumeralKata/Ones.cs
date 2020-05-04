using System.Security.Cryptography.X509Certificates;

namespace RomanNumeralKata
{
    public class Ones : IPlaceValues
    {
        public int Multiplier => 1;
        public int MidPointSymbolValue => 5;
        public string UnitSymbol => "I";
        public string MidPointSymbol => "V";
    }
}