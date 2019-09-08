using BlogEngine.DataAccess;
using BlogEngine.Models;

namespace BlogEngine.Services
{
    public class TagsNUserSvc
    {
        public Tag GetTagForEdit(long aTagID)
        {
            var objDataAccess = new TagDa();
            return objDataAccess.Select(aTagID);
        }
        public bool SaveTag(Tag aTag)
        {
            var objDataAccess = new TagDa();
            return objDataAccess.Insert(aTag);
        }

        public bool UpdateTag(Tag aTag)
        {
            var objDataAccess = new TagDa();
            return objDataAccess.Update(aTag);
        }

        public UserEvent GetEventForEdit(long aEventID)
        {
            var objDataAccess = new UserEventDa();
            return objDataAccess.Select(aEventID);
        }
        public bool SaveNewEvent(UserEvent aNew)
        {
            var objDataAccess = new UserEventDa();
            return objDataAccess.Insert(aNew);
        }
        public bool UpdateEvent(UserEvent aNew)
        {
            var objDataAccess = new UserEventDa();
            return objDataAccess.Update(aNew);
        }
    }
}
