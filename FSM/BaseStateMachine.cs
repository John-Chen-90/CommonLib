using System.Linq;
using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// 状态驱动器
    /// 状态管理器
    /// </summary>
    public class BaseStateMachine : BaseState, IStateMachine
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        public IState CurState { get { return _curState; } }
        /// <summary>
        /// 默认状态
        /// </summary>
        public IState DefaultState { get { return _defaultState; } }
        /// <summary>
        /// 状态集合
        /// </summary>
        public Dictionary<string, IState> States { get { return _states; } }
        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="name"> 状态名 </param>
        /// <param name="defaultState"> 默认状态 </param>
        public BaseStateMachine(string name, IState defaultState) : base(name)
        {
            _states = new Dictionary<string, IState>();
            AddState(defaultState);
            _defaultState = defaultState;
            _curState = defaultState;
            _curState.OnEnter(null);
        }

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="state"></param>
        public void AddState(IState state)
        {
            if (!_states.ContainsKey(state.Name))
            {
                _states.Add(state.Name, state);
                state.SetStateMachine(this);
            }
            else
            {
                // log warining: 已有该 state 状态
            }
        }

        /// <summary>
        /// 获得状态
        /// </summary>
        /// <param name="name"> 状态名 </param>
        /// <returns> 找到的状态 </returns>
        public IState GetStateWithName(string name)
        {
            return _states == null ? null : _states[name];
        }

        /// <summary>
        /// 获得状态
        /// </summary>
        /// <param name="tag"> 状态标识 </param>
        /// <returns> 找到的状态 </returns>
        public IState GetStateWithTag(string tag)
        {
            foreach (var state in _states.Values)
            {
                if (state.Tag == tag)
                    return state;
            }
            return null;
        }

        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="state"> 状态 </param>
        public void RemoveState(IState state)
        {
            if (_states.ContainsKey(state.Name)) _states.Remove(state.Name);
            if (_defaultState == _curState && _curState == state)
            {
                _curState = _states.Count > 0 ? _states[_states.Keys.ToArray()[0]] : null;
                _defaultState = _curState;
            }
            else if (_defaultState != _curState && _defaultState == state)
            {
                _defaultState = _curState;
            }
            else if (_curState != _defaultState && _curState == state)
            {
                _curState = _states.Count > 0 ? _states[_states.Keys.ToArray()[0]] : null;
            }
        }

        /// <summary>
        /// 设置当前状态
        /// </summary>
        /// <param name="state"> 状态 </param>
        public void SetCurState(IState state)
        {
            if (state == null)
            {
                // log warining : 传入的 state 为空！
                return;
            }

            _curState = state;
        }

        /// <summary>
        /// 进入状态
        /// </summary>
        /// <param name="prev"> 上一个状态 </param>
        public override void OnEnter(IState prev)
        {
            base.OnEnter(prev);
            _curState.OnEnter(prev);
        }

        /// <summary>
        /// 离开当前状态
        /// </summary>
        /// <param name="next"> 下一个状态 </param>
        public override void OnExit(IState next)
        {
            base.OnExit(next);
            _curState.OnExit(next);
        }

        /// <summary>
        /// 帧更新
        /// </summary>
        /// <param name="deltaTime"> 每帧更新时间 </param>
        public override void OnUpdate(float deltaTime)
        {
            base.OnUpdate(deltaTime);
            _curState.OnUpdate(deltaTime);
        }

        private IState _curState;
        private IState _defaultState;
        private Dictionary<string, IState> _states;
    }
}