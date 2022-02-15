using Models;

namespace BusinessLogic
{
    public interface IUserBL
    {
        CustomerModel AddUser(CustomerModel p_User);
        CustomerModel SaveUser(CustomerModel p_User);
        List<CustomerModel> GetAllUsers();
        CustomerModel GetUserByID(string p_UserID);
    }
    public interface IStoreFrontBL
    {
        StoreFrontModel AddStoreFront(StoreFrontModel p_StoreFront);
        StoreFrontModel SaveStoreFront(StoreFrontModel p_StoreFront);
        List<StoreFrontModel> GetAllStoreFrontModels();
        StoreFrontModel GetStoreFrontByID(string p_StoreID);
    }
    public interface IProductBL
    {
        ProductsModel AddProducts(ProductsModel p_Item);
        ProductsModel SaveProducts(ProductsModel p_Item);
        List<ProductsModel> GetAllProducts();
        List<ProductsModel> GetAllProductsFromStore(string p_StoreID);
        ProductsModel GetItemDetailsByID(string p_ItemID);
        List<ProductsModel> GetAllItemsByName(string p_ItemName);
        List<StoreFrontModel> GetAllStoreFrontModelsByProductID(string p_ItemID);
    }
    public interface IOrdersBL
    {
        OrdersModel PlaceOrder(List<LineItemsModel> p_LineItems, string p_StoreID, string UserID, float OrderPrice);
        List<OrdersModel> GetAllOrdersByUserID(string p_UserID);
        List<OrdersModel> GetAllOrdersByStoreID(string p_StoreID);
        OrdersModel GetOrderByOrderID(string p_OrderID);
        List<OrdersModel> GetAllOrders();
    }
    public interface IInventoryBL
    {
        InventoryModel GetItemDetail(string p_ItemID, string p_StoreID);
        List<InventoryModel> GetAllProductsByStoreID(string p_StoreID);
        List<ProductsModel> GetAllInStockItemsByStoreID(string p_StoreID);
        void ReplenishProducts(string p_InventoryID, int p_ItemQuantity);
    }
}
