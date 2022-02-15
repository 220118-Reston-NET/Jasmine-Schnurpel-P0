using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class UserBL : IUserBL
    {
        private IUserRepo _repo;
        public UserBL(IUserRepo p_repo)
        {
            _repo = p_repo;
        }
        public CustomerModel AddUser(CustomerModel p_User)
        {
            List<CustomerModel> _listUsers = _repo.GetAllUsers();
            for (int i = 0; i < _listUsers.Count(); i++)
            {
                if (_listUsers[i].UserID == p_User.UserID)
                {
                    throw new Exception("This ID is already taken!");
                }
            }
            return _repo.AddUser(p_User);
        }
        public List<CustomerModel> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }
        public CustomerModel SaveUser(CustomerModel p_User)
        {
            List<CustomerModel> _listUser = GetAllUsers().Where(p => p.UserID != p_User.UserID).ToList();
            return _repo.SaveUser(p_User);
        }
        public CustomerModel GetUserByID(string p_UserID)
        {
            CustomerModel _UserDetail = GetAllUsers().Where(p=>p.UserID == p_UserID).First();
            return _UserDetail;
        }
    }
}