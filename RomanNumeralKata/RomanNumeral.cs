using System;
using System.Collections.Generic;
using System.Linq;

// SERIOUS REFACTOR NEEDED TO AVOID DRY. EDGE CASES FOR 40 > ARE NOT WORKING. CHECK LOGIC IN THE TENS TO SEE WHY THIS IS HAPPENING. 

namespace RomanNumeralKata
{
    public class RomanNumeral
    {
        private Dictionary<string, int>RomanNumeralDictionary 
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
        
        private Dictionary<string, int> digitPlaceValues = new Dictionary<string, int>
        {
            {"Ones", 0},
            {"Tens", 0}, 
            {"Hundreds", 0},
            {"Thousands", 0},
        };
        
        public string TranslateIntToRomanNumeral(int inputNumber)
        {

            List<string> romanOutput = new List<string>();
            
            SeparatingInputToPlaceValues(inputNumber);
           
            foreach (var digitPlaceValue in digitPlaceValues)
            {
                if (InputMatchesNumeral(digitPlaceValue.Value))
                {
                    romanOutput.Add(FindRomanNumeralFromInput(digitPlaceValue.Value));
                }
                else
                {
                    romanOutput.Add(SetRomanNumeralForRegularNumbers(digitPlaceValue));
                }
                
            }

            romanOutput.Reverse();
            var symbolOutput = String.Join("", romanOutput);
            return symbolOutput;
        }
        
        private bool InputMatchesNumeral(int inputNumber)
        {
            return FindRomanNumeralFromInput(inputNumber) != null;
        }
        
        private string SetRomanNumeralForRegularNumbers(KeyValuePair<string, int> numberEntry)
        {
            var midPointSymbolValue = 5;
            var midPointSymbol = "V";
            var unitSymbol = "I";
            var multiplier = 1;

            if (numberEntry.Key == "Tens")
            {
                multiplier = 10;
                midPointSymbolValue = 50;
                midPointSymbol = "L";
                unitSymbol = "X";
            }
            else if (numberEntry.Key == "Hundreds")
            {
                multiplier = 100;
                midPointSymbolValue = 500;
                midPointSymbol = "D";
                unitSymbol = "C";
            }
            else if (numberEntry.Key == "Thousands")
            {
                multiplier = 1000;
                unitSymbol = "M";
            }
            
            var romanOutput = GenerateRomanOutput(numberEntry, midPointSymbolValue, midPointSymbol, unitSymbol, multiplier);
            return romanOutput;
        }

        private static string GenerateRomanOutput(KeyValuePair<string, int> numberEntry, int midPointSymbolValue, string romanDictionaryKey,
            string unitSymbol, int multiplier)
        {
            string romanOutput = numberEntry.Value > midPointSymbolValue ? romanDictionaryKey : "";
            
            var modulusRemainder = (numberEntry.Value % midPointSymbolValue) / multiplier;
            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += unitSymbol;
            }

            return romanOutput;
        }
        

        private void SeparatingInputToPlaceValues(int inputNumber)
        {
            int ones = (inputNumber / 1) % 10;
            int tens = (inputNumber / 10) % 10;
            int hundreds = (inputNumber / 100) % 10;
            int thousands = (inputNumber / 1000) % 10;
            digitPlaceValues["Ones"] = ones;
            digitPlaceValues["Tens"] = tens * 10;
            digitPlaceValues["Hundreds"] = hundreds * 100;
            digitPlaceValues["Thousands"] = thousands * 1000;
        }
        
       
        private string FindRomanNumeralFromInput(int inputNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Key;
        }
        
    }
}



