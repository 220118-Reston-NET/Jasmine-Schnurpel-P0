using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class ProductBL : IProductBL
    {
        private IProductsRepo _ipRepo;
        public ProductBL(IProductsRepo p_repo)
        {
            _ipRepo = p_repo;
        }
        public ProductsModel AddProducts(ProductsModel p_Item)
        {
            return _ipRepo.AddProducts(p_Item);
        }
        public ProductsModel SaveProducts(ProductsModel p_Item)
        {
            List<ProductsModel> _ProductList = GetAllProducts().Where(p => p.ItemID != p_Item.ItemID).ToList();
            return _ipRepo.SaveProducts(p_Item);

        }
        public List<ProductsModel> GetAllProducts()
        {
            return _ipRepo.GetAllProducts();
        }
        public List<ProductsModel> GetAllProductsFromStore(string p_StoreID)
        {
            return _ipRepo.GetAllProductsFromStore(p_StoreID);
        }
        public ProductsModel GetItemDetailsByID(string p_ItemID)
        {
            List<ProductsModel> _ProductList = GetAllProducts();

            return _ProductList.Where(p => p.ItemID == p_ItemID).First();
        }
        public List<ProductsModel> GetAllItemsByName(string p_ItemName)
        {
            return GetAllProducts().FindAll(p => p.ItemName.Contains(p_ItemName));
        }
        public List<StoreFrontModel> GetAllStoreFrontModelsByProductID(string p_ItemID)
        {
            return _ipRepo.GetAllStoreFrontModelsByProductID(p_ItemID);
        }
    }
}