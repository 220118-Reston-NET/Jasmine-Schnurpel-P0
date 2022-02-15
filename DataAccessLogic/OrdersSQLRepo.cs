using System.Data.SqlClient;
using Models;

namespace DataAccessLogic
{
    public class OrdersSQLRepo : IOrdersRepo
    {
        private readonly string _connectionString;
        public OrdersSQLRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        private InventorySQLRepo _InventoryDL;
        private ProductSQLRepo _ProductDL;
        public OrdersModel PlaceOrder(List<LineItemsModel> p_LineItems, string p_StoreID, string UserID, float OrderPrice)
        {
            string _sqlQueryOrders = @"insert into Orders
                          values(@OrderID, @OrderPrice, @StoreID, @UserID)";
            string _sqlQueryLineItems = @"insert into LineItems
                          values(@ItemID, @OrderID, @ItemQuantity, @TotalPriceAtCheckOut)";

            OrdersModel _NewOrder = new OrdersModel();
            _InventoryDL = new InventorySQLRepo(_connectionString);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(_sqlQueryOrders, conn);
                comm.Parameters.AddWithValue("@OrderID", _NewOrder.OrderID);
                comm.Parameters.AddWithValue("@OrderPrice", _NewOrder.OrderPrice);
                comm.Parameters.AddWithValue("@StoreID", _NewOrder.StoreID);
                comm.Parameters.AddWithValue("@UserID", _NewOrder.UserID);

                comm.ExecuteNonQuery();

                foreach (var _Item in p_LineItems)
                {
                    comm = new SqlCommand(_sqlQueryLineItems, conn);
                    comm.Parameters.AddWithValue("@ItemID", _Item.ItemID);
                    comm.Parameters.AddWithValue("@OrderID", _NewOrder.OrderID);
                    comm.Parameters.AddWithValue("@ItemQuantity", _Item.ItemQuantity);
                    comm.Parameters.AddWithValue("@TotalPriceAtCheckOut", _NewOrder.OrderPrice);

                    comm.ExecuteNonQuery();

                    _InventoryDL.RemoveProducts(_Item.ItemID, _NewOrder.StoreID, _Item.ItemQuantity);
                }
            }

            return _NewOrder;

        }
        public List<OrdersModel> GetAllOrders()
        {
            string _sqlQuery = @"select * from Orders";
            List<OrdersModel> _OrdersList = new List<OrdersModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(_sqlQuery, conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _OrdersList.Add(new OrdersModel()
                    {
                        OrderID = reader.GetString(0),
                        OrderPrice = reader.GetFloat(1),
                        StoreID = reader.GetString(2),
                        UserID = reader.GetString(3),
                        LineItems = GetAllLineItemsByID(reader.GetString(0)),
                    });
                }
            }

            return _OrdersList;
        }
        public List<LineItemsModel> GetAllLineItemsByID(string p_OrderID)
        {
            string _sqlQuery = @"select * from LineItems
                          where orderID = @orderID";
            List<LineItemsModel> _ListLineItems = new List<LineItemsModel>();
            _ProductDL = new ProductSQLRepo(_connectionString);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                comm.Parameters.AddWithValue("@OrderID", p_OrderID);

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    _ListLineItems.Add(new LineItemsModel()
                    {
                        ItemID = reader.GetString(0),
                        OrderID = reader.GetString(1),
                        ItemQuantity = reader.GetInt32(2),
                        OrderPrice = reader.GetFloat(3),
                        ItemName = _ProductDL.GetItemDetailsByID(reader.GetString(0)).ItemName
                    });
                }
            }

            return _ListLineItems;
        }
    }
}