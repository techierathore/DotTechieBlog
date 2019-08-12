using BlogEngine.DataAccess;
using BlogEngine.Models;

namespace BlogEngine.Services
{
    public class AdminHomeSvc
    {
        public AdminCounts GetAdminCounts()
        {
            var objDataSvc = new CommentDa();
            var vPostCount = objDataSvc.GetAdminCounts();
            return vPostCount;
        }
    }
}
