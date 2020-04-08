namespace RomanNumeralKata
{
    public class RomanNumeral
    {
        public string TranslateIntToRomanNumeral(int number)
        {
            var numeralOutput = "";

            if (number + 1 == 5)
            {
                numeralOutput = "IV";
                return numeralOutput;
            }
            
            if (number < 5)
            {
                int modulusRemainder = number % 5;
                for (int i = 0; i < modulusRemainder; i++)
                {
                    numeralOutput += "I";
                }
                return numeralOutput;
            }
            
            
            // if (number == 1)
            // {
            //     return "I";
            // }
            //
            // if (number == 2)
            // {
            //     return "II";
            // }
            //
            // if (number == 3)
            // {
            //     return "III";
            // }

            if (number == 5)
            {
                return "V";
            }

            if (number == 10)
            {
                return "X";
            }

            return null;
        }
    }
}

//If input is 7, this becomes 7 - 5 = 2. 
//Then 5 (V). Maybe variable for number of 'I's. Remainder will be the number of 'I's to add. 

//If input is 4. Then it becomes 4-5 = -1. If the answer is -1 --> add 'I' in front of V.

//If input is 9. Then it becomes 9 - 5 = 4. 

