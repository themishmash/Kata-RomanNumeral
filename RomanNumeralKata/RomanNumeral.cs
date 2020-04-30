using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralKata
{
    public class RomanNumeral
    {
        
        private readonly Dictionary<string, int> RomanNumeralDictionary 
        = new Dictionary<string, int>
        {
            {"I", 1},
            {"IV", 4},
            {"V", 5},
            {"IX", 9},
            {"X", 10},
            {"XL", 40},
            {"L", 50},
            {"XC", 90},
            {"C", 100},
            {"CD", 400},
            {"D", 500},
            {"CM", 900},
            {"M", 1000},
           
        };
        
        private static Dictionary<string, int> SeparateToExpandedNotation(int inputNumber)
        {
            var expandedNotation = new Dictionary<string, int>
            {
                ["Ones"] = (inputNumber / 1) % 10,
                ["Tens"] = ((inputNumber / 10) % 10) * 10,
                ["Hundreds"] = ((inputNumber / 100) % 10) * 100,
                ["Thousands"] = ((inputNumber / 1000) % 10) * 1000
            };
            return expandedNotation;
        }


        public static PlaceValues SetPlaceValues(KeyValuePair<string, int> expandedNotation)
        {
            PlaceValues placeValues = null;
            placeValues = new Ones();
            if (expandedNotation.Key == "Tens")
            {
                placeValues = new Tens();
            }
            else if (expandedNotation.Key == "Hundreds")
            {
                placeValues = new Hundreds();
            }
            else if (expandedNotation.Key == "Thousands")
            {
                placeValues = new Thousands();
            }
            return placeValues;
        }
        public string TranslateNumberToRomanNumeral(int inputNumber)
        {
            var romanOutput = new List<string>();
            foreach (var expandedNotation in SeparateToExpandedNotation(inputNumber))
            {
                if (InputMatchesNumeral(expandedNotation.Value))
                {
                    romanOutput.Add(FindRomanNumeralForDigit(expandedNotation.Value));
                }
                else
                {
                    romanOutput.Add(GenerateRomanOutput(expandedNotation));
                }
            }
            romanOutput.Reverse();
            return string.Join("", romanOutput);
        }
        private static string GenerateRomanOutput(KeyValuePair<string, int> numberEntry)
        {
            var placeValues = SetPlaceValues(numberEntry);
            var romanOutput = numberEntry.Value > placeValues.MidPointSymbolValue ? placeValues.MidPointSymbol : "";
            var modulusRemainder = (numberEntry.Value % placeValues.MidPointSymbolValue) / placeValues.Multiplier;
            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += placeValues.UnitSymbol;
            }
            return romanOutput;
        }
        private bool InputMatchesNumeral(int expandedNumber)
        {
            return FindRomanNumeralForDigit(expandedNumber) != null;
        }
        private string FindRomanNumeralForDigit(int expandedNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(num => num.Value == expandedNumber).Key;
        }
    }
}



