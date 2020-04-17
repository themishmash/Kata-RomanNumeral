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
            Assert.AreEqual("I", romanNumeral.TranslateIntToRomanNumeral(1));
            Assert.AreEqual("II", romanNumeral.TranslateIntToRomanNumeral(2));
            Assert.AreEqual("III", romanNumeral.TranslateIntToRomanNumeral(3));
        }
        
        [Test]
        public void RomanNumeral_input_4_returnsRomanNumeral_IV()
        {
            //Given (class we need to create)
            RomanNumeral romanNumeral = new RomanNumeral();

            //When
            //string result = romanNumeral.TranslateIntToRomanNumeral(1);

            //Then
            Assert.AreEqual("IV", romanNumeral.TranslateIntToRomanNumeral(4));
           
        }
        
        [Test]
        public void RomanNumeral_Input_5_returns_V()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            // When
            string result = romanNumeral.TranslateIntToRomanNumeral(5);
            // Then
            Assert.AreEqual("V", result);
        }
        
        [Test]
        public void RomanNumeral_input_6_7_8_returnsRomanNumeral_VI_VII_VIII()
        {
            //Given (class we need to create)
            RomanNumeral romanNumeral = new RomanNumeral();
            

            //Then
            Assert.AreEqual("VI", romanNumeral.TranslateIntToRomanNumeral(6));
            Assert.AreEqual("VII", romanNumeral.TranslateIntToRomanNumeral(7));
            Assert.AreEqual("VIII", romanNumeral.TranslateIntToRomanNumeral(8));
        }
        
        [Test]
        public void RomanNumeral_Input_9_returns_IX()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            // When
            string result = romanNumeral.TranslateIntToRomanNumeral(9);
            // Then
            Assert.AreEqual("IX", result);
        }
        
        [Test]
        public void RomanNumeral_Input_10_returns_X()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            // When
            string result = romanNumeral.TranslateIntToRomanNumeral(10);
            // Then
            Assert.AreEqual("X", result);
        }

        [Test]
        public void RomanNumeral_Input_11_Returns_XI()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateIntToRomanNumeral(11);
            // Then
            Assert.AreEqual("XI", result);
        }
        
        [Test]
        public void RomanNumeral_Input_13_Returns_XIII()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateIntToRomanNumeral(13);
            // Then
            Assert.AreEqual("XIII", result);
        }
        
        [Test]
        public void RomanNumeral_Input_19_Returns_XIX()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateIntToRomanNumeral(19);
            // Then
            Assert.AreEqual("XIX", result);
        }
        
        [Test]
        public void RomanNumeral_Input_37_Returns_XXXVII()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateIntToRomanNumeral(37);
            // Then
            Assert.AreEqual("XXXVII", result);
        }
        
        [Test]
        public void RomanNumeral_Input_42_Returns_XLII()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            string result = romanNumeral.TranslateIntToRomanNumeral(42);
            // Then
            Assert.AreEqual("XLII", result);
        }
    }
}