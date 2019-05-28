using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// 状态机接口
    /// </summary>
    public interface IStateMachine
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        IState CurState { get; }
        /// <summary>
        /// 默认接口
        /// </summary>
        IState DefaultState { get; }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="state"></param>
        void AddState(IState state);
        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="state"></param>
        void RemoveState(IState state);
        /// <summary>
        /// 设置当前状态
        /// </summary>
        /// <param name="state"></param>
        void SetCurState(IState state);
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="tag"> 状态标识 </param>
        /// <returns> 状态 </returns>
        IState GetStateWithTag(string tag);
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="name"> 状态名 </param>
        /// <returns> 状态 </returns>
        IState GetStateWithName(string name);
        /// <summary>
        /// 所有的状态
        /// </summary>
        Dictionary<string, IState> States { get; }
    }
}
