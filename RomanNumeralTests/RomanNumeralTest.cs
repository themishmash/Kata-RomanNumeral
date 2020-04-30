using NUnit.Framework;
using RomanNumeralKata;

namespace RomanNumeralTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void RomanNumeral_input_1_2_3_returnsRomanNumeral_I_II_III()
        {
            //Given (class we need to create)
            RomanNumeral romanNumeral = new RomanNumeral();

            //Then
            Assert.AreEqual("I", romanNumeral.TranslateNumberToRomanNumeral(1));
            Assert.AreEqual("II", romanNumeral.TranslateNumberToRomanNumeral(2));
            Assert.AreEqual("III", romanNumeral.TranslateNumberToRomanNumeral(3));
        }
        
        [Test]
        public void RomanNumeral_input_22_returnsRomanNumeral_XXII()
        {
            //Given (class we need to create)
            RomanNumeral romanNumeral = new RomanNumeral();

            //Then
            Assert.AreEqual("XXII", romanNumeral.TranslateNumberToRomanNumeral(22));
        }
        
        [Test]
        public void RomanNumeral_input_237_returnsRomanNumeral_CCXXXVII()
        {
            //Given (class we need to create)
            RomanNumeral romanNumeral = new RomanNumeral();

            //Then
            Assert.AreEqual("CCXXXVII", romanNumeral.TranslateNumberToRomanNumeral(237));
        }
        
        [Test]
        public void RomanNumeral_input_4_returnsRomanNumeral_IV()
        {
            //Given (class we need to create)
            RomanNumeral romanNumeral = new RomanNumeral();
        
            //When
            //string result = romanNumeral.TranslateIntToRomanNumeral(1);
        
            //Then
            Assert.AreEqual("IV", romanNumeral.TranslateNumberToRomanNumeral(4));
           
        }
        
        [Test]
        public void RomanNumeral_Input_5_returns_V()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            // When
            string result = romanNumeral.TranslateNumberToRomanNumeral(5);
            // Then
            Assert.AreEqual("V", result);
        }
        
        [Test]
        public void RomanNumeral_input_6_7_8_returnsRomanNumeral_VI_VII_VIII()
        {
            //Given (class we need to create)
            RomanNumeral romanNumeral = new RomanNumeral();
            
        
            //Then
            Assert.AreEqual("VI", romanNumeral.TranslateNumberToRomanNumeral(6));
            Assert.AreEqual("VII", romanNumeral.TranslateNumberToRomanNumeral(7));
            Assert.AreEqual("VIII", romanNumeral.TranslateNumberToRomanNumeral(8));
        }
        
        [Test]
        public void RomanNumeral_Input_9_returns_IX()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            // When
            string result = romanNumeral.TranslateNumberToRomanNumeral(9);
            // Then
            Assert.AreEqual("IX", result);
        }
        
        [Test]
        public void RomanNumeral_Input_10_returns_X()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            // When
            string result = romanNumeral.TranslateNumberToRomanNumeral(10);
            // Then
            Assert.AreEqual("X", result);
        }
        
        [Test]
        public void RomanNumeral_Input_11_Returns_XI()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateNumberToRomanNumeral(11);
            // Then
            Assert.AreEqual("XI", result);
        }
        
        [Test]
        public void RomanNumeral_Input_13_Returns_XIII()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateNumberToRomanNumeral(13);
            // Then
            Assert.AreEqual("XIII", result);
        }
        
        [Test]
        public void RomanNumeral_Input_19_Returns_XIX()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateNumberToRomanNumeral(19);
            // Then
            Assert.AreEqual("XIX", result);
        }
        
        [Test]
        public void RomanNumeral_Input_37_Returns_XXXVII()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateNumberToRomanNumeral(37);
            // Then
            Assert.AreEqual("XXXVII", result);
        }
        
        [Test]
        public void RomanNumeral_Input_42_Returns_XLII()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateNumberToRomanNumeral(42);
            // Then
            Assert.AreEqual("XLII", result);
        }
        
        [Test]
        public void RomanNumeral_Input_986_Returns_CMLXXXVI()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateNumberToRomanNumeral(986);
            // Then
            Assert.AreEqual("CMLXXXVI", result);
        }
        
        [Test]
        public void RomanNumeral_Input_1404_Returns_MCDIV()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateNumberToRomanNumeral(1404);
            // Then
            Assert.AreEqual("MCDIV", result);
        }
    }
}