using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// 基础状态
    /// </summary>
    public class BaseState : IState
    {
        /// <summary>
        /// 状态名
        /// </summary>
        public string Name { get { return _name; } }
        /// <summary>
        /// 状态标识
        /// </summary>
        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
        /// <summary>
        /// 计时器
        /// </summary>
        public float Timer { get { return _timer; } }
        /// <summary>
        /// 状态机
        /// </summary>
        public IStateMachine Parent { get { return _parent; } }
        /// <summary>
        /// 上一个状态(从上一个状态转换而来)
        /// </summary>
        public IState PreState { get { return _preState;} }
        /// <summary>
        /// 下一个状态(已经转换到的状态)
        /// </summary>
        public IState NextState { get { return _nxtState;} }
        /// <summary>
        /// 本状态下的所有转换
        /// </summary>
        public List<ITransition> Transitions { get { return _transitions; } }
        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="name"> 状态名 </param>
        public BaseState(string name)
        {
            _name = name;
            _transitions = new List<ITransition>();
        }

        /// <summary>
        /// 添加状态转换
        /// </summary>
        /// <param name="transition"> 本状态下的转换 </param>
        public void AddTransition(ITransition transition)
        {
            if (!_transitions.Contains(transition))
                _transitions.Add(transition);
            else
            {
                // log warining : 该转换已经存在
            }

        }

        /// <summary>
        /// 进入本状态
        /// </summary>
        /// <param name="prev"> 上一个状态 </param>
        public virtual void OnEnter(IState prev)
        {
            _timer = 0;
            _index = 0;
            _isWork = true;
            _preState = prev;
        }

        /// <summary>
        /// 离开本状态
        /// </summary>
        /// <param name="next"> 下一个状态 </param>
        public virtual void OnExit(IState next)
        {
            _timer = 0;
            _index = 0;
            _isWork = false;
            _nxtState = next;
        }

        /// <summary>
        /// 每帧执行
        /// </summary>
        /// <param name="deltaTime"> 每帧更新时间 </param>
        public virtual void OnUpdate(float deltaTime)
        {
            if (!_isWork) return;
            _timer += deltaTime;
            if (_transitions.Count < 1) return;

            // 如果检测能够转换,则进入转换函数中
            if (_workingTransition != null && _workingTransition.OnCheck())
            {
                // 如果转换完成
                if (_workingTransition.OnCompleteCallBack())
                {
                    DoTransition(_workingTransition);
                }
                return;
            }

            _index += 1;
            if (_index >= _transitions.Count) _index = 0;
            _workingTransition = _transitions[_index];
        }

        /// <summary>
        /// 设置本状态的父状态机
        /// </summary>
        /// <param name="stateMachine"></param>
        public void SetStateMachine(IStateMachine stateMachine)
        {
            _parent = stateMachine;
        }

        protected int _index;
        protected string _tag;
        protected string _name;
        protected float _timer;
        protected bool _isWork;
        protected IState _preState;
        protected IState _nxtState;
        protected IStateMachine _parent;
        protected List<ITransition> _transitions;
        protected ITransition _workingTransition;

        /// <summary>
        /// 执行转换
        /// </summary>
        /// <param name="transition"></param>
        protected virtual void DoTransition(ITransition transition)
        {
            Parent.CurState.OnExit(transition.ToState);
            Parent.SetCurState(transition.ToState);
            Parent.CurState.OnEnter(transition.FromState);
        }
    }
}