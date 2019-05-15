using System.Runtime.InteropServices.ComTypes;

namespace FSM
{
    /// <summary>
    /// 状态接口
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 上一个状态
        /// </summary>
        IState PreState { get; }

        /// <summary>
        /// 下一个状态
        /// </summary>
        IState NextState { get; }

        /// <summary>
        /// 状态标识
        /// </summary>
        string Id { get; }

        /// <summary> 
        /// 执行一次操作
        /// </summary>
        void DoActionOnce();

        /// <summary>
        /// 在update中执行操作
        /// </summary>
        void DoActionLoop();
    }
}