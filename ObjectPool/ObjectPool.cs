using System.Collections.Generic;

namespace ObjectPool
{
    /// <summary>
    /// 简单泛型对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T>
    {
        /// <summary>
        /// 获取一个对象池
        /// </summary>
        /// <typeparam name="T"> 对象池的类型 </typeparam>
        /// <returns> 对象池 </returns>
        public static ObjectPool<T> GetPool()
        {
            return new ObjectPool<T>();
        }

        private ObjectPool()
        {
            _pools = new Stack<T>();
        }

        /// <summary>
        /// 释放对象池
        /// </summary>
        public void Release()
        {
            _pools.Clear();
        }

        /// <summary>
        /// 获取对象池中的一个对象,如果对象池为空,则返回为空(null)
        /// </summary>
        /// <returns> 对象池的对象 </returns>
        public T Get()
        {
            if (_pools.Count == 0) return default(T);

            return _pools.Pop();
        }

        /// <summary>
        /// 添加非空对象到对象池
        /// </summary>
        /// <param name="value"> 对象 </param>
        public void Add(T value)
        {
            if(value == null) return;

            _pools.Push(value);
        }

        /// <summary>
        /// 获取对象池的对象
        /// </summary>
        public int Count
        {
            get { return _pools.Count; }
        }

        /// <summary>
        /// 检测该对象是否在对象池中
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainObject(T value)
        {
            if (_pools.Count == 0) return false;

            bool temp = _pools.Contains(value);
            return temp;
        }

        protected Stack<T> _pools;

    }
}
