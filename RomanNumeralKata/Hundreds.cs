namespace RomanNumeralKata
{
    public class Hundreds : IPlaceValues
    {
        public int Multiplier => 100;
        public int MidPointSymbolValue => 500;
        public string UnitSymbol => "C";
        public string MidPointSymbol => "D";
    }
}