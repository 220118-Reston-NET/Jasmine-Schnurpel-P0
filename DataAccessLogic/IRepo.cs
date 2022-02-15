using Models;

namespace DataAccessLogic
{
    public interface IUserRepo
    {
        CustomerModel AddUser(CustomerModel p_User);
        CustomerModel SaveUser(CustomerModel p_User);
        List<CustomerModel> GetAllUsers();

    }
    public interface IStoreFrontRepo
    {
        StoreFrontModel AddStoreFront(StoreFrontModel p_StoreFront);
        List<StoreFrontModel> GetAllStoreFrontModels();
        StoreFrontModel SaveStoreFront(StoreFrontModel p_StoreFront);
    }
    public interface IProductsRepo
    {
        ProductsModel AddProducts(ProductsModel p_Items);
        ProductsModel SaveProducts(ProductsModel p_Items);
        List<ProductsModel> GetAllProducts();
        List<ProductsModel> GetAllProductsFromStore(string p_StoreID);
        ProductsModel GetItemDetailsByID(string p_ItemID);
        List<StoreFrontModel> GetAllStoreFrontModelsByProductID(string p_ItemID);
    }
    public interface IInventoryRepo
    {
        List<InventoryModel> GetAllProducts();
        List<InventoryModel> GetAllProductsByStoreID(string p_StoreID);
        List<ProductsModel> GetAllInStockItemsByStoreID(string p_StoreID);
        void RemoveProducts(string p_ItemID, string p_StoreID, int p_ItemQuantity);
        void ReplenishProducts(string p_InventoryID, int p_ItemQuantity);
    }
    public interface IOrdersRepo
    {
        OrdersModel PlaceOrder(List<LineItemsModel> p_LineItems, string p_StoreID, string UserID, float OrderPrice);
        List<OrdersModel> GetAllOrders();
        List<LineItemsModel> GetAllLineItemsByID(string p_OrderID);
    }
}