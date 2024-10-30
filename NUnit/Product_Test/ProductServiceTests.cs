using ProductApp;

namespace Product_Test
{
    [TestFixture]
    class ProductServiceTests
    {
        private ProductService _productService;
        [SetUp]
        public void SetUp()
        {
            _productService = new ProductService();
        }

        [Test]
        public void AddProduct_WhenNewProduct_ShouldIncreaseStock()
        {
            var product = new Product() { Name = "Laptop", Quantity = 1 };
            _productService.AddProduct(product);
            Assert.That(_productService.CheckStock("Laptop"),Is.EqualTo(1));
        }

        [Test]
        public void AddProduct_WhenExistingProduct_ShouldIncreaseStock()
        {
            var product = new Product() { Name = "Laptop", Quantity = 1 };
            _productService.AddProduct(product);
            _productService.AddProduct(new Product() { Name = "Laptop", Quantity = 1 });
            Assert.That(_productService.CheckStock("Laptop"),Is.EqualTo(2));
        }
        [Test]
        public void CheckStock_WhenProductDoesNotExist_ShouldReturnZero()
        {
            int stock = _productService.CheckStock("Laptop");
            Assert.That(stock,Is.EqualTo(0));
        }
        [Test]
        public void CheckStock_WhenProductExists_ShouldReturnCount()
        {
            var product = new Product() { Name = "Laptop", Quantity = 1 };
            _productService.AddProduct(product);
            int stock = _productService.CheckStock("Laptop");
            Assert.That(stock,Is.EqualTo(1));
        }
        [Test]
        public void UpdateStock_WhenProductExists_ShouldUpdateQuantity()
        {
            var product = new Product() { Name = "Laptop", Quantity = 1 };
            _productService.AddProduct(product);
            var updatedStock = _productService.UpdateStock("Laptop",3);
            Assert.Multiple(() =>
            {
                Assert.That(updatedStock, Is.True);
                Assert.That(_productService.CheckStock("Laptop"), Is.EqualTo(4));
            });
        }

        [Test]
        public void UpdateStock_WhenProductDoesNotExists_ShouldReturnFalse()
        {
            var updatedStock = _productService.UpdateStock("sample product",3);
            Assert.That(updatedStock, Is.False);
        }
    }
}
