using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class OrdersBL : IOrdersBL
    {
        private IOrdersRepo _ioRepo;
        public OrdersBL(IOrdersRepo p_repo)
        {
            _ioRepo = p_repo;
        }
        public OrdersModel PlaceOrder(List<LineItemsModel> p_LineItems, string p_StoreID, string UserID, float OrderPrice)
        {
            return _ioRepo.PlaceOrder(p_LineItems, p_StoreID, UserID, OrderPrice);
        }
        public List<OrdersModel> GetAllOrdersByUserID(string p_UserID)
        {
            List<OrdersModel> _UserOrders = new List<OrdersModel>();
            _UserOrders = _ioRepo.GetAllOrders().Where(ord => ord.UserID == p_UserID).ToList();
            return _UserOrders;
        }
        public List<OrdersModel> GetAllOrdersByStoreID(string p_StoreID)
        {
            List<OrdersModel> _UserOrders = new List<OrdersModel>();
            _UserOrders = _ioRepo.GetAllOrders().Where(ord => ord.StoreID == p_StoreID).ToList();
            return _UserOrders;
        }
        public OrdersModel GetOrderByOrderID(string p_OrderID)
        {
            OrdersModel _OrderByID = GetAllOrders().Where(p => p.OrderID == p_OrderID).First();
            return _OrderByID;
        }
        public List<OrdersModel> GetAllOrders()
        {
            return _ioRepo.GetAllOrders();
        }
    }
}