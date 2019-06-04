
namespace UnitSystem
{
    /// <summary>
    /// 单位生命周期
    /// </summary>
    public interface IUnitLife
    {
        /// <summary>
        /// 初始化,开始加载
        /// </summary>
        void Init();
        /// <summary>
        /// 释放内存和资源
        /// </summary>
        void Release();
        /// <summary>
        /// 回收
        /// </summary>
        void Recovery();
    }
}
