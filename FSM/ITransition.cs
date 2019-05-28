
namespace FSM
{
    /// <summary>
    /// 状态转换
    /// </summary>
    public interface ITransition
    {
        /// <summary>
        /// 转换名
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 从什么状态开始转换
        /// </summary>
        IState FromState { get; }
        /// <summary>
        /// 到什么状态
        /// </summary>
        IState ToState { get; }
        /// <summary>
        /// 检查条件
        /// </summary>
        /// <returns></returns>
        bool OnCheck();
        /// <summary>
        /// 转换是否完成
        /// </summary>
        /// <returns></returns>
        bool OnCompleteCallBack();
    }
}
