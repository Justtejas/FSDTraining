using Moq;
using ProductApp;
using System.Diagnostics;

namespace Product_Test
{
    [TestFixture]
    public class OrderServiceTests
    {

        private Mock<IProductService> _mockProductService;
        private OrderService _orderService;

        [SetUp]
        public void SetUp()
        {
            _mockProductService = new Mock<IProductService>();
            _orderService = new OrderService(_mockProductService.Object);
        }

        [Test]
        public void PlaceOrder_WhenStockIsSufficient_ShouldReturnTrueAndReduceStock()
        {
           _mockProductService.Setup(x => x.CheckStock(It.IsAny<string>())).Returns(10);
            var result = _orderService.PlaceOrder("Laptop",5);
            Assert.That(result, Is.True);
            _mockProductService.Verify(x => x.UpdateStock("Laptop", 5), Times.Once());
        }
        
        [Test]
        public void PlaceOrder_WhenStockIsInsufficient_ShouldReturnFalse()
        {
           _mockProductService.Setup(x => x.CheckStock(It.IsAny<string>())).Returns(2);
            var result = _orderService.PlaceOrder("Laptop",5);
            Assert.That(result, Is.False);
            _mockProductService.Verify(x => x.UpdateStock(It.IsAny<string>(),It.IsAny<int>()), Times.Never());
        }

    }
}
