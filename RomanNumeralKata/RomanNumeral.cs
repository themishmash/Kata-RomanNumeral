using System;
using System.Collections.Generic;
using System.Linq;

// SERIOUS REFACTOR NEEDED TO AVOID DRY. EDGE CASES FOR 40 > ARE NOT WORKING. CHECK LOGIC IN THE TENS TO SEE WHY THIS IS HAPPENING. 

namespace RomanNumeralKata
{
    public class RomanNumeral
    {
        private static int _midPointSymbolValue { get; set; }
        private static string _midPointSymbol { get; set; }
        private static string _unitSymbol { get; set; }
        private static int _multiplier { get; set; }
        
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
     
        public string TranslateIntToRomanNumeral(int inputNumber)
        {
            var romanOutput = new List<string>();
            var digitPlaceValues = SeparatingInputToPlaceValues(inputNumber);
            
            foreach (var digitPlaceValue in digitPlaceValues)
            {
                if (InputMatchesNumeral(digitPlaceValue.Value))
                {
                    romanOutput.Add(FindRomanNumeralFromInput(digitPlaceValue.Value));
                }
                else
                {
                    SetRomanNumeralForRegularNumbers(digitPlaceValue);
                    romanOutput.Add(GenerateRomanOutput(digitPlaceValue));
                }
            }

            romanOutput.Reverse();
            var symbolOutput = string.Join("", romanOutput);
            return symbolOutput;
        }
        
        private bool InputMatchesNumeral(int inputNumber)
        {
            return FindRomanNumeralFromInput(inputNumber) != null;
        }
        
        private static void SetRomanNumeralForRegularNumbers(KeyValuePair<string, int> numberEntry)
        {
            _midPointSymbolValue = 5;
            _midPointSymbol = "V";
            _unitSymbol = "I";
            _multiplier = 1;

            if (numberEntry.Key == "Tens")
            {
                _multiplier = 10;
                _midPointSymbolValue = 50;
                _midPointSymbol = "L";
                _unitSymbol = "X";
            }
            else if (numberEntry.Key == "Hundreds")
            {
                _multiplier = 100;
                _midPointSymbolValue = 500;
                _midPointSymbol = "D";
                _unitSymbol = "C";
            }
            else if (numberEntry.Key == "Thousands")
            {
                _multiplier = 1000;
                _unitSymbol = "M";
            }
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
        

        private static Dictionary<string, int> SeparatingInputToPlaceValues(int inputNumber)
        {
            var digitPlaceValues = new Dictionary<string, int>
            {
                ["Ones"] = (inputNumber / 1) % 10,
                ["Tens"] = ((inputNumber / 10) % 10) * 10,
                ["Hundreds"] = ((inputNumber / 100) % 10) * 100,
                ["Thousands"] = ((inputNumber / 1000) % 10) * 1000
            };
            return digitPlaceValues;
        }
        
        private string FindRomanNumeralFromInput(int inputNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Key;
        }
        
    }
}



