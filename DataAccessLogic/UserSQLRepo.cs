using System.Data.SqlClient;
using Models;

namespace DataAccessLogic
{
    public class UserSQLRepo : IUserRepo
    {
        private readonly string _connectionString;
        public UserSQLRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public CustomerModel AddUser(CustomerModel p_User)
        {
            string _sqlQuery = @"insert into Customer values(@UserID, @UserName, @UserLevel, @UserAddress, @UserEmail)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                comm.Parameters.AddWithValue("@UserID", p_User.UserID);
                comm.Parameters.AddWithValue("@UserName", p_User.UserName);
                comm.Parameters.AddWithValue("@UserLevel", p_User.UserLevel);
                comm.Parameters.AddWithValue("@UserAddress", p_User.UserAddress);
                comm.Parameters.AddWithValue("@UserEmail", p_User.UserEmail);

                comm.ExecuteNonQuery();
            }
            return p_User;
        }
        public CustomerModel SaveUser(CustomerModel p_User)
        {
            string _sqlQuery = @"update Customer set UserID = @UserID UserName = @UserName UserLevel = @UserLevel UserAddress = @UserAddress UserEmail = @UserEmail";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                comm.Parameters.AddWithValue("@UserID", p_User.UserID);
                comm.Parameters.AddWithValue("@UserName", p_User.UserName);
                comm.Parameters.AddWithValue("@UserLevel", p_User.UserLevel);
                comm.Parameters.AddWithValue("@UserAddress", p_User.UserAddress);
                comm.Parameters.AddWithValue("@UserEmail", p_User.UserEmail);

                comm.ExecuteNonQuery();
            }
            return p_User;
        }
        public List<CustomerModel> GetAllUsers()
        {
            string _sqlQuery = @"select * from Customer";
            List<CustomerModel> _listUser = new List<CustomerModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(_sqlQuery, conn);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    _listUser.Add(new CustomerModel()
                    {
                        UserID = reader.GetString(0),
                        UserName = reader.GetString(1),
                        UserLevel = reader.GetInt32(2),
                        UserAddress = reader.GetString(3),
                        UserEmail = reader.GetString(4),
                    });
                }
            }
            return _listUser;
        }
    }
}