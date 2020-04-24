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
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
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
            // romanOutput.Add(SetRomanNumeralForValueMinusOne(inputNumber));

            foreach (var digitPlaceValue in digitPlaceValues)
            {
                romanOutput.Add(SetRomanNumeralForValueMinusOne(digitPlaceValue));
                // romanOutput.Add(SetRomanNumeralForRegularNumbers(digitPlaceValue));
            }

            romanOutput.Reverse();
            var symbolOutput = String.Join("", romanOutput);
            return symbolOutput;
        }
        
        private string SetRomanNumeralForRegularNumbers(KeyValuePair<string, int> numberEntry)
        {
            var midPointSymbolValue = 5;
            var midPointSymbol = "V";
            var unitSymbol = "I";

            if (numberEntry.Key == "Tens")
            {
                midPointSymbolValue = 50;
                midPointSymbol = "L";
                unitSymbol = "X";
            }
            else if (numberEntry.Key == "Hundreds")
            {
                midPointSymbolValue = 500;
                midPointSymbol = "D";
                unitSymbol = "C";
            }
            
            var romanOutput = GenerateRomanOutput(numberEntry, midPointSymbolValue, midPointSymbol, unitSymbol);
            return romanOutput;
        }

        private static string GenerateRomanOutput(KeyValuePair<string, int> numberEntry, int midPointSymbolValue, string romanDictionaryKey,
            string unitSymbol)
        {
            string romanOutput = numberEntry.Value > midPointSymbolValue ? romanDictionaryKey : "";
            
            var modulusRemainder = numberEntry.Value % midPointSymbolValue;
            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += unitSymbol;
            }

            return romanOutput;
        }
        
        private string SetRomanNumeralForValueMinusOne(KeyValuePair<string, int> numberEntry)
        {
            var multipleOf1_10_100 = 0;
            var unitSymbol = "";
            
            if (numberEntry.Key == "Ones" && numberEntry.Value != 0)
            {
                multipleOf1_10_100 = 1;
                unitSymbol = "I";
            }
            else if (numberEntry.Key == "Tens" && numberEntry.Value != 0)
            {
                multipleOf1_10_100 = 10;
                unitSymbol = "X";
            }
            else if (numberEntry.Key == "Hundreds" && numberEntry.Value != 0)
            {
                multipleOf1_10_100 = 100;
                unitSymbol = "C";
            }

            string romanOutput = "";
            
            foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
                
                if ((numberEntry.Value * multipleOf1_10_100) + multipleOf1_10_100 == dictionaryEntry.Value)
                {
                    romanOutput = unitSymbol + dictionaryEntry.Key; 
                    return romanOutput;
                }
            return "";
        }

        private void SeparatingInputToPlaceValues(int inputNumber)
        {
            int ones = (inputNumber / 1) % 10;
            int tens = (inputNumber / 10) % 10;
            int hundreds = (inputNumber / 100) % 10;
            int thousands = (inputNumber / 1000) % 10;
            digitPlaceValues["Ones"] = ones;
            digitPlaceValues["Tens"] = tens;
            digitPlaceValues["Hundreds"] = hundreds;
            digitPlaceValues["Thousands"] = thousands;
        }

        // public string TranslateIntToRomanNumeral(int inputNumber)
        // {
        //     string romanOutput = "";
        //
        //     if (InputMatchesNumeral(inputNumber))
        //     {
        //         romanOutput = FindRomanNumeralFromInput(inputNumber);
        //         return romanOutput;
        //     }
        //
        //     var digits = ConvertInputToSeparateDigits(inputNumber);
        //
        //     if (digits.Count == 1)
        //     {
        //         romanOutput = CreateUnits(digits);
        //     }
        //
        //     if (digits.Count == 2)
        //     {
        //         romanOutput = $"{CreateTens(digits)}{CreateUnits(digits)}";
        //     }
        //
        //     return romanOutput;
        // }
        // 
        //
      
        //
        // private int GetDictionaryValueMinusOne(int inputNumber)
        // {
        //     foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
        //         
        //         if (inputNumber == dictionaryEntry.Value - 1)
        //         {
        //             return dictionaryEntry.Value;
        //         }
        //     return 0;
        // }
        // //
        // private string SetRomanNumeralForValueMinusTen(int inputNumber)
        // {
        //     int tens = inputNumber * 10;
        //     foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
        //         
        //         if (tens + 10 == dictionaryEntry.Value)
        //        
        //         {
        //             string romanOutput = "X" + dictionaryEntry.Key; 
        //             return romanOutput;
        //         }
        //
        //     return "";
        // }
        //
        // private int GetDictionaryValueMinusTen(int inputNumber)
        // {
        //     int tens = inputNumber * 10;
        //     foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
        //         
        //         if (tens == dictionaryEntry.Value - 10)
        //         {
        //             return dictionaryEntry.Value;
        //         }
        //     return 0;
        // }
        //
        //
        private string FindRomanNumeralFromInput(int inputNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Key;
        }
        //
        // // FINDS MATCHING VALUE FROM THE LIST. IF NO MATCH RETURNS 0. TO BE USED FOR > 10. 
        // public int FindDictionaryValueFromInput(int inputNumber)
        // {
        //     return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Value;
        // }
        //
        //
        // private bool InputMatchesNumeral(int inputNumber)
        // {
        //     return FindRomanNumeralFromInput(inputNumber) != null;
        // }
      
        // IMPERATIVE WAY?? DOING THE SAME AS FindRomanNumeralFromValue(). 
        // private string GetRomanNumeralForMatchingInput(int inputNumber)
        // {
        //     foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
        //         
        //         if (inputNumber == dictionaryEntry.Value)
        //         {
        //             return dictionaryEntry.Key;
        //         }
        //     return "";
        // }
    }
}



