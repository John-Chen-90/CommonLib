using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// 无参代理
    /// </summary>
    public delegate void VoidStateDelegate();
    /// <summary>
    /// 带状态参数的代理
    /// </summary>
    /// <param name="state"></param>
    public delegate void VoidStateDelegateState(IState state);
    /// <summary>
    /// 带浮点数参数的代理
    /// </summary>
    /// <param name="f"> 浮点数 </param>
    public delegate void VoidStateDelegateFloat(float f);

    /// <summary>
    /// 状态接口
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 定时器
        /// </summary>
        float Timer { get; }
        /// <summary>
        /// 状态名
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 状态标识
        /// </summary>
        string Tag { get; set; }
        /// <summary>
        /// 进入状态
        /// </summary>
        /// <param name="prev"> 上一个状态 </param>
        void OnEnter(IState prev);
        /// <summary>
        /// 离开状态
        /// </summary>
        /// <param name="next"> 下一个状态 </param>
        void OnExit(IState next);
        /// <summary>
        /// 帧更新
        /// </summary>
        /// <param name="deltaTime"> 每帧更新时间 </param>
        void OnUpdate(float deltaTime);
        /// <summary>
        /// 本状态下所有转换
        /// </summary>
        List<ITransition> Transitions { get; }
        /// <summary>
        /// 添加转换
        /// </summary>
        /// <param name="transition"> 本状态下的转换 </param>
        void AddTransition(ITransition transition);
        /// <summary>
        /// 状态机
        /// </summary>
        IStateMachine Parent { get; }
        /// <summary>
        /// 设置状态机
        /// </summary>
        /// <param name="stateMachine"></param>
        void SetStateMachine(IStateMachine stateMachine);
    }
}
