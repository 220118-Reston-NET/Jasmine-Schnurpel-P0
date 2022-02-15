using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IStoreFrontRepo _isfRepo;
        public StoreFrontBL(IStoreFrontRepo p_repo)
        {
            _isfRepo = p_repo;
        }
        public StoreFrontModel AddStoreFront(StoreFrontModel p_StoreFront)
        {
            return _isfRepo.AddStoreFront(p_StoreFront);
        }

        public StoreFrontModel SaveStoreFront(StoreFrontModel p_StoreFront)
        {
            return _isfRepo.SaveStoreFront(p_StoreFront);
        }
        public List<StoreFrontModel> GetAllStoreFrontModels()
        {
            return _isfRepo.GetAllStoreFrontModels();
        }
        public StoreFrontModel GetStoreFrontByID(string p_StoreID)
        {
            StoreFrontModel _StoreFrontInfo = GetAllStoreFrontModels().Where(p => p.StoreID == p_StoreID).First();

            return _StoreFrontInfo;
        }
    }
}