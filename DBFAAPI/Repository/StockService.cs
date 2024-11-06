using DBFAAPI.Models;

namespace DBFAAPI.Repository
{
    public class StockService : IStockServices
    {
        private readonly BikeStoresContext _bikeStoresContext;
        public StockService(BikeStoresContext bikeStoresContext)
        {
            _bikeStoresContext = bikeStoresContext;
        }

        public int GetQuantityOfAProductInStore(int productId, int storeID)
        {
            var quantityOfProductInStore = _bikeStoresContext.Stocks.Where(s => s.ProductId == productId && s.StoreId == storeID).FirstOrDefault();
            if(quantityOfProductInStore == null)
            {
                return 0;
            }
            return quantityOfProductInStore.Quantity ?? 0;
        }

        public int GetTotalCountOfProductsInStore(int storeID)
        {
            var totalCountOfProductsInStore = _bikeStoresContext.Stocks.Where(s => s.StoreId == storeID).Select(s => s.ProductId).Count();
            return totalCountOfProductsInStore;
        }

        public int GetTotalQuantityInStore(int storeID)
        {
            var totalQuantityInStore = _bikeStoresContext.Stocks.Where(s => s.StoreId == storeID).Sum(s => s.Quantity ?? 0);
            return totalQuantityInStore;
        }
    }
}
