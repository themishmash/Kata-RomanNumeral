using System;
using System.Collections.Generic;
using System.Linq;

// SERIOUS REFACTOR NEEDED TO AVOID DRY. EDGE CASES FOR 40 > ARE NOT WORKING. CHECK LOGIC IN THE TENS TO SEE WHY THIS IS HAPPENING. 

namespace RomanNumeralKata
{
    public class RomanNumeral
    {
        private static int _multiplier { get; set; }
        private static string _midPointSymbol { get; set; }
        private static int _midPointSymbolValue { get; set; }
        private static string _unitSymbol { get; set; }
        
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
        
        private static void SetRomanNumeralForRegularNumbers(KeyValuePair<string, int> expandedNotation)
        {
            _multiplier = 1;
            _midPointSymbolValue = 5;
            _unitSymbol = "I";
            _midPointSymbol = "V";

            if (expandedNotation.Key == "Tens")
            {
                _multiplier = 10;
                _midPointSymbolValue = 50;
                _unitSymbol = "X";
                _midPointSymbol = "L";
            }
            else if (expandedNotation.Key == "Hundreds")
            {
                _multiplier = 100;
                _midPointSymbolValue = 500;
                _unitSymbol = "C";
                _midPointSymbol = "D";
            }
            else if (expandedNotation.Key == "Thousands")
            {
                _multiplier = 1000;
                _unitSymbol = "M";
            }
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
                    SetRomanNumeralForRegularNumbers(expandedNotation);
                    romanOutput.Add(GenerateRomanOutput(expandedNotation));
                }
            }
            romanOutput.Reverse();
            return string.Join("", romanOutput);
        }
        private static string GenerateRomanOutput(KeyValuePair<string, int> numberEntry)
        {
            var romanOutput = numberEntry.Value > _midPointSymbolValue ? _midPointSymbol : "";
            
            var modulusRemainder = (numberEntry.Value % _midPointSymbolValue) / _multiplier;
            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += _unitSymbol;
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



