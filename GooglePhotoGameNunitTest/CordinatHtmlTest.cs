using NUnit.Framework;

namespace GooglePhotoGameNunitTest
{
    public class Tests
    {
        public string InputValue = "123.123";

        //[TestCase (453.542 , ExpectedResult = 453.542)]
        [Test]
        public void convertToDoubleCoordinates( string inputValue)
        {
            
            double expected = 123.123;

            Assert.AreEqual(expected, inputValue);
        }
    }
}