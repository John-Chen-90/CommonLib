
namespace UnitSystem
{
    /// <summary>
    /// 单位
    /// </summary>
    public class Unit : IUnitLife
    {
        /// <summary>
        /// 单位唯一ID
        /// </summary>
        public uint UID { get { return _uid; } }

        /// <summary>
        /// 单位字符串ID
        /// 可以充当配置ID
        /// </summary>
        public string SID { get { return _sid; } }

        /// <summary>
        /// 单位名字
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// 单位类型
        /// </summary>
        public UnitCategory Category { get { return _category;} }

        /// <summary>
        /// 游戏对象,比如一个模型
        /// </summary>
        public object UnitObject { get { return _unitObject;} }

        /// <summary>
        /// 是否是服务端单位
        /// </summary>
        public bool Remote { get { return _remote;} }

        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="uid"> 实例ID </param>
        public Unit(uint uid)
        {
            _uid = uid;
        }
        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="uid"> 实例ID </param>
        /// <param name="sid"> 字符串ID </param>
        public Unit(uint uid, string sid)
        {
            _uid = uid;
            _sid = sid;
        }

        /// <summary>
        /// 每帧更新
        /// </summary>
        /// <param name="delta"></param>
        public virtual void Update(float delta)
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {

        }
        /// <summary>
        /// 释放资源内存,删除本实例对象
        /// </summary>
        public virtual void Release()
        {

        }
        /// <summary>
        /// 回收,并不删除本对象
        /// </summary>
        public virtual void Recovery()
        {

        }

        protected uint _uid;
        protected string _sid;
        protected string _name;
        protected bool _remote;
        protected object _unitObject;
        protected UnitCategory _category;

        /// <summary>
        /// 异步加载完成时的回调
        /// </summary>
        protected virtual void OnLoaded()
        {

        }
    }
}
