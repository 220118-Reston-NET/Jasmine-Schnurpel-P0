using System.Data.SqlClient;
using Models;

namespace DataAccessLogic
{
    public class ProductSQLRepo : IProductsRepo
    {
        private readonly string _connectionString;
        public ProductSQLRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public ProductsModel AddProducts(ProductsModel p_Items)
        {
            string _sqlQuery = @"insert into Products
                  values(@ItemID, @ItemName, @ItemDesc, @ItemPrice, @ItemQuantity, @LevelMinimum)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                comm.Parameters.AddWithValue("@ItemID", p_Items.ItemID);
                comm.Parameters.AddWithValue("@ItemName", p_Items.ItemName);
                comm.Parameters.AddWithValue("@ItemDesc", p_Items.ItemDesc);
                comm.Parameters.AddWithValue("@ItemPrice", p_Items.ItemPrice);
                comm.Parameters.AddWithValue("@ItemQuantity", p_Items.ItemQuantity);
                comm.Parameters.AddWithValue("@LevelMinimum", p_Items.LevelMinimum);

                comm.ExecuteNonQuery();
            }
            return p_Items;
        }
        public ProductsModel SaveProducts(ProductsModel p_Items)
        {
            string _sqlQuery = @"update Products 
                          SET ItemName = @ItemName,
                            ItemDesc = @ItemDesc,
                            ItemPrice = @ItemPrice,
                            ItemQuantity = @ItemQuantity
                            LevelMinimum = @LevelMinimum
                          WHERE ItemID = @ItemID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(_sqlQuery, conn);

                command.Parameters.AddWithValue("@ItemID", p_Items.ItemID);
                command.Parameters.AddWithValue("@ItemName", p_Items.ItemName);
                command.Parameters.AddWithValue("@ItemDesc", p_Items.ItemDesc);
                command.Parameters.AddWithValue("@ItemPrice", p_Items.ItemPrice);
                command.Parameters.AddWithValue("@ItemQuantity", p_Items.ItemQuantity);
                command.Parameters.AddWithValue("@LevelMinimum", p_Items.LevelMinimum);

                command.ExecuteNonQuery();
            }

            return p_Items;
        }
        public List<ProductsModel> GetAllProducts()
        {
            string _sqlQuery = @"select * from Products";
            List<ProductsModel> _listProducts = new List<ProductsModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(_sqlQuery, conn);

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    _listProducts.Add(new ProductsModel()
                    {
                        ItemID = reader.GetString(0),
                        ItemName = reader.GetString(1),
                        ItemDesc = reader.GetString(2),
                        ItemQuantity = reader.GetInt32(3),
                        ItemPrice = reader.GetFloat(4),
                        LevelMinimum = reader.GetInt32(5)
                    });
                }
            }
            return _listProducts;
        }
        public List<ProductsModel> GetAllProductsFromStore(string p_StoreID)
        {
            List<ProductsModel> _listProductsFromStore = new List<ProductsModel>();
            string _sqlQuery = @"select p.ItemID, p.ItemName, p.ItemDesc, p.ItemQuantity, p.ItemPrice, p.LevelMinimum from ProductsModel p, StoreFrontModel sf, InventoryModel i
                          where p.ProductID = i.ProductID 
                            and sf.StoreID = i.StoreID
                            and sf.StoreID = @StoreID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(_sqlQuery, conn);
                command.Parameters.AddWithValue("@StoreID", p_StoreID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _listProductsFromStore.Add(new ProductsModel()
                    {
                        ItemID = reader.GetString(0),
                        ItemName = reader.GetString(1),
                        ItemDesc = reader.GetString(2),
                        ItemQuantity = reader.GetInt32(3),
                        ItemPrice = reader.GetFloat(4),
                        LevelMinimum = reader.GetInt32(5)
                    });
                }
            }
            return _listProductsFromStore;
        }
        public ProductsModel GetItemDetailsByID(string p_ItemID)
        {
            return GetAllProducts().Where(p => p.ItemID == p_ItemID).First();
        }
        public List<StoreFrontModel> GetAllStoreFrontModelsByProductID(string p_ItemID)
        {
            List<StoreFrontModel> _listStoreFronts = new List<StoreFrontModel>();

            string _sqlQuery = @"select sf.StoreID, sf.StoreName, sf.StoreAddress from StoreFrontModel sf, InventoryModel i, ProductsModel p 
                          WHERE sf.StoreID = i.StoreID 
                            AND i.ItemID = p.ItemID
                            AND p.ItemID = @ItemID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                comm.Parameters.AddWithValue("@ItemID", p_ItemID);

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    _listStoreFronts.Add(new StoreFrontModel()
                    {
                        StoreID = reader.GetString(0),
                        StoreName = reader.GetString(1),
                        StoreAddress = reader.GetString(2),
                    });
                }
            }
            return _listStoreFronts;
        }
    }
}