namespace FSM
{
    /// <summary>
    /// 状态转换
    /// </summary>
    public class BaseTransition : ITransition
    {
        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="name"> 转换名 </param>
        /// <param name="from"> 从什么状态开始转换 </param>
        /// <param name="to"> 转换到什么状态 </param>
        public BaseTransition(string name, IState from, IState to)
        {
            _to = to;
            _from = from;
            _name = name;
        }

        /// <summary>
        /// 本次转换的名字
        /// </summary>
        public string Name { get { return _name; } }
        /// <summary>
        /// 转换到的状态
        /// </summary>
        public IState ToState { get { return _to; } }
        /// <summary>
        /// 当前需要转换的状态
        /// </summary>
        public IState FromState { get { return _from; } }

        /// <summary>
        /// 检测能否转换
        /// </summary>
        /// <returns> 转换结果 </returns>
        public virtual bool OnCheck()
        {
            return true;
        }

        /// <summary>
        /// 检测转换函数是否执行完毕
        /// </summary>
        /// <returns> 是否执行完毕 </returns>
        public virtual bool OnCompleteCallBack()
        {
            return true;
        }

        protected IState _from;
        protected IState _to;
        protected string _name;
    }
}