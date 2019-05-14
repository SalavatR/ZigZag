using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Pool
{
    public class PoolManagerBase<T> : IPoolManager<T> where T : UnityEngine.MonoBehaviour, IPoolObject
    {
        protected T ObjPrefab { get; set; }
        protected Stack<T> Pool;

        public PoolManagerBase(int stackPreSize, T objPrefab)
        {
            ObjPrefab = objPrefab;
            Pool = new Stack<T>(stackPreSize);
        }

        public virtual void DestroyObject(T obj)
        {
            Pool.Push(obj);
            obj.DisableObject();
        }

        public T GetObject()
        {
            T tile;
            if (Pool.Count > 0)
            {
                tile = Pool.Pop();
                tile.gameObject.SetActive(true);
            }
            else
            {
                tile = Object.Instantiate(ObjPrefab);
            }
            tile.ResetToDefault();
            return tile;
        }
    }
}