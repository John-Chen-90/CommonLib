
namespace Event
{
    /// <summary>
    /// 事件管理器
    /// </summary>
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

        public event DelegateHandler EventHandler;

        private EventMgr()
        {
            
        }

        private static EventMgr _ins;
    }
}
