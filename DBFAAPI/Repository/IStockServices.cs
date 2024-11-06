using DBFAAPI.Models;

namespace DBFAAPI.Repository
{
    public interface IStockServices
    {
        public int GetQuantityOfAProductInStore(int productId,int storeID);
        public int GetTotalQuantityInStore(int storeID);
        public int GetTotalCountOfProductsInStore(int storeID);
    }
}
