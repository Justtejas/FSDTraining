using ProductApp;

namespace Product_Test
{
    public class Tests
    {
        private CalculatorService _calculatorService;
        [SetUp]
        public void Setup()
        {
            _calculatorService = new CalculatorService();
        }

        [TestCase(10,20,30)]
        [TestCase(40,20,60)]
        [TestCase(20,20,40)]
        public void WhenAddTwoNumbers_Should_Return_SumOfTwoNumbers(int num1, int num2,int expected)
        {
            //Arrange
            // Act
            int sum = _calculatorService.Add(num1, num2);
            //Assert
            //Assert.AreEqual(expected,sum); // nunit version 3.0
            Assert.That(sum, Is.EqualTo(expected));
        }

        [Test]
        public void WhenAddTwoNegativeNumbers_Should_ReturnCorrectSum()
        {
            int expectedResult = -30;
            int actualResult = _calculatorService.Add(-10,-20);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [Test]
        public void WhenMultiplyTwoNumbers_Should_ReturnCorrectMultiplication()
        {
            int expectedResult = 30;
            int actualResult = _calculatorService.Multiply(10,3);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [Test]
        public void WhenSubtractTwoNumbers_Should_ReturnCorrectSubtraction()
        {
            int expectedResult = 10;
            int actualResult = _calculatorService.Subtraction(50,40);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [Test]
        public void WhenSubtractTwoNegativeNumbers_Should_ReturnCorrectSubtraction()
        {
            int expectedResult = 10;
            int actualResult = _calculatorService.Subtraction(-10,-20);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [Test]
        public void WhenDivideTwoNumbers_Should_ReturnCorrectDivision()
        {
            int expectedResult = 2;
            int actualResult = _calculatorService.Divide(20,10);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [Test]
        public void WhenDivideByZero_Should_ReturnDivideByZeroException()
        {
            var exception = Assert.Throws<DivideByZeroException>(() =>  _calculatorService.Divide(20,0));
            Assert.That(exception.Message, Is.EqualTo("Attempted to divide by zero."));
        }
    }
}