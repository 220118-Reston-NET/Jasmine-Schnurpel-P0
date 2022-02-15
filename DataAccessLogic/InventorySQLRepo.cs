using System.Data.SqlClient;
using Models;

namespace DataAccessLogic
{
    public class InventorySQLRepo : IInventoryRepo
    {
        private readonly string _connectionString;
        public InventorySQLRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public List<ProductsModel> GetAllInStockItemsByStoreID(string p_StoreID)
        {
            string _sqlQuery = @"select p.ItemID, p.ItemName, p.ItemPrice, p.ItemDesc, p.LevelMinimum
                          from Inventory i, Products p
                          where i.ItemID = p.ItemID
                            AND i.StoreID = @StoreID
                            AND i.ItemQuantity > 0";
            List<ProductsModel> _ProductsList = new List<ProductsModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                comm.Parameters.AddWithValue("@StoreID", p_StoreID);

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    _ProductsList.Add(new ProductsModel()
                    {
                        ItemID = reader.GetString(0),
                        ItemName = reader.GetString(1),
                        ItemDesc = reader.GetString(2),
                        ItemPrice = reader.GetFloat(3),
                        ItemQuantity = reader.GetInt32(4),
                        LevelMinimum = reader.GetInt32(5)
                    });
                }
            }

            return _ProductsList;
        }
        public List<InventoryModel> GetAllProducts()
        {
            List<InventoryModel> _ListInventory = new List<InventoryModel>();
            string _sqlQuery = @"select * from Inventory";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    _ListInventory.Add(new InventoryModel()
                    {
                        InventoryID = reader.GetString(0),
                        ItemID = reader.GetString(1),
                        StoreID = reader.GetString(2),
                        ItemQuantity = reader.GetInt32(3)
                    });
                }
            }

            return _ListInventory;
        }
        public List<InventoryModel> GetAllProductsByStoreID(string p_StoreID)
        {
            List<InventoryModel> _ListInventory = GetAllProducts().Where(p => p.StoreID == p_StoreID).ToList();
            return _ListInventory;
        }
        public void ReplenishProducts(string p_InventoryID, int p_ItemQuantity)
        {
            string _sqlQuery = @"update Inventory
                                set ItemQuantity = ItemQuantity + @ItemQuantity
                                where InventoryID = @InventoryID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                comm.Parameters.AddWithValue("@ItemQuantity", p_ItemQuantity);
                comm.Parameters.AddWithValue("@InventoryID", p_InventoryID);

                comm.ExecuteNonQuery();
            }
        }
        public void RemoveProducts(string p_ItemID, string p_StoreID, int p_ItemQuantity)
        {
            string _sqlQuery = @"update Inventory
                          set ItemQuantity = ItemQuantity - @ItemQuantity
                          where ItemID = @ItemID
                            and StoreID = @StoreID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                comm.Parameters.AddWithValue("@ItemQuantity", p_ItemQuantity);
                comm.Parameters.AddWithValue("@ItemID", p_ItemID);
                comm.Parameters.AddWithValue("@StoreID", p_StoreID);

                comm.ExecuteNonQuery();
            }
        }
    }
}