namespace Factory
{
    /// <summary>
    /// 简单工厂
    /// </summary>
    public class SimpleFactory<T>
    {
        public static SimpleFactory<T> GetFactory()
        {
            return new SimpleFactory<T>();
        }

        private SimpleFactory()
        {

        }

        public T CreateProduct(params object[] args)
        {
            return default(T);
        }
    }
}