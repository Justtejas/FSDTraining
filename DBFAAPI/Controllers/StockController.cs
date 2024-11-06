using DBFAAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DBFAAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly IStockServices _stockServices;
        public StockController(IStockServices stockServices)
        {
            _stockServices = stockServices;
        }
        [HttpGet("stock/{storeID}/{productID}")]
        public IActionResult GetQuantityOfAProductInStore(int storeID, int productID)
        {
            var quantityOfAProductInStore = _stockServices.GetQuantityOfAProductInStore(productID, storeID);
            return Ok($"The Total Quantity of Product with ProductID: {productID} in Store with StoreID: {storeID} is :{quantityOfAProductInStore}");
        }
        [HttpGet("stock/store/{storeID}")]
        public IActionResult GetTotalQuantityInStore(int storeID)
        {
            var totalQuantityInStore = _stockServices.GetTotalQuantityInStore(storeID);
            return Ok($"The Total Quantity of products in Store with StoreID: {storeID} is :{totalQuantityInStore}");
        }
        [HttpGet("stock/storecount/{storeID}")]
        public IActionResult GetTotalCountOfProductsInStore(int storeID)
        {
            var totalCountOfProductsInStore = _stockServices.GetTotalCountOfProductsInStore(storeID);
            return Ok($"The Total Quantity of Products in Store with StoreID: {storeID} is :{totalCountOfProductsInStore}");
        }
    }
}
