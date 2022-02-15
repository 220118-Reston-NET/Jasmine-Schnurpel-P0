using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class InventoryBL : IInventoryBL
    {
        private IInventoryRepo _iiRepo;
        public InventoryBL(IInventoryRepo p_repo)
        {
            _iiRepo = p_repo;
        }
        public InventoryModel GetItemDetail(string p_ItemID, string p_StoreID)
        {
            List<InventoryModel> _InventoryList = GetAllProductsByStoreID(p_StoreID);
            InventoryModel _selectedInven = new InventoryModel();

            for (int i = 0; i < _InventoryList.Count(); i++)
            {
                if (_InventoryList[i].ItemID == p_ItemID)
                {
                    _selectedInven = _InventoryList[i];
                }
            }
            return _selectedInven;
        }
        public List<InventoryModel> GetAllProductsByStoreID(string p_StoreID)
        {
            return _iiRepo.GetAllProductsByStoreID(p_StoreID);
        }
        public List<ProductsModel> GetAllInStockItemsByStoreID(string p_StoreID)
        {
            return _iiRepo.GetAllInStockItemsByStoreID(p_StoreID);
        }
        public void ReplenishProducts(string p_InventoryID, int p_ItemQuantity)
        {
            _iiRepo.ReplenishProducts(p_InventoryID, p_ItemQuantity);
        }
    }
}