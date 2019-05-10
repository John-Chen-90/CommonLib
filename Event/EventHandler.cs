namespace Event
{
    /// <summary>
    /// 代理
    /// </summary>
    /// <param name="sender"> 注册的事件者 </param>
    /// <param name="args"> 参数 </param>
    public delegate void DelegateHandler(object sender, params object[] args);
    
}