
namespace Event
{
    public class EventMgr
    {
        public static EventMgr Ins
        {
            get
            {
                if(_ins == null) _ins = new EventMgr();
                return _ins;
            }
        }

        private EventMgr()
        {
            
        }

        private static EventMgr _ins;
    }
}
