namespace Pool
{
    public interface IPoolManager<T> where T: UnityEngine.Object,IPoolObject
    {
        T GetObject();
        void DestroyObject(T obj);
    }
}