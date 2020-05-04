namespace RomanNumeralKata
{
    public class Thousands : IPlaceValues
    {
         public int Multiplier => 1000;
        public int MidPointSymbolValue => 1000;
        public string UnitSymbol => "M";
        public string MidPointSymbol => "";
    }
}