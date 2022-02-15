using System.Data.SqlClient;
using Models;

namespace DataAccessLogic
{
    public class StoreFrontSQLRepo : IStoreFrontRepo
    {
        private readonly string _connectionString;
        public StoreFrontSQLRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public StoreFrontModel AddStoreFront(StoreFrontModel p_StoreFront)
        {
            string _sqlQuery = @"insert into StoreFronts 
                        values(@StoreID, @StoreName, @StoreAddress)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(_sqlQuery, conn);

                command.Parameters.AddWithValue("@StoreID", p_StoreFront.StoreID);
                command.Parameters.AddWithValue("@StoreName", p_StoreFront.StoreName);
                command.Parameters.AddWithValue("@StoreAddress", p_StoreFront.StoreAddress);

                command.ExecuteNonQuery();
            }

            return p_StoreFront;
        }
        public List<StoreFrontModel> GetAllStoreFrontModels()
        {
            string _sqlQuery = @"select * from StoreFronts";
            List<StoreFrontModel> _listStoreFront = new List<StoreFrontModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(_sqlQuery, conn);

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    _listStoreFront.Add(new StoreFrontModel()
                    {
                        StoreID = reader.GetString(0),
                        StoreName = reader.GetString(1),
                        StoreAddress = reader.GetString(2),
                    });
                }
            }

            return _listStoreFront;
        }
        public StoreFrontModel SaveStoreFront(StoreFrontModel p_StoreFront)
        {
            string _sqlQuery = @"update StoreFronts 
                        set StoreName = @StoreName,
                            StoreAddress = @StoreAddress
                        where StoreID = @StoreID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                comm.Parameters.AddWithValue("@StoreName", p_StoreFront.StoreName);
                comm.Parameters.AddWithValue("@StoreAddress", p_StoreFront.StoreAddress);
                comm.Parameters.AddWithValue("@StoreID", p_StoreFront.StoreID);

                comm.ExecuteNonQuery();
            }
            return p_StoreFront;
        }
    }
}