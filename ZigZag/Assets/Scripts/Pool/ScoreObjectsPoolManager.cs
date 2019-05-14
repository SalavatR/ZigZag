using ScoreObjects;

namespace Pool
{
    public class ScoreObjectsPoolManager : PoolManagerBase<ScoreObjectBase>
    {
        public ScoreObjectsPoolManager(int stackPreSize, ScoreObjectBase objPrefab) : base(stackPreSize, objPrefab)
        {
        }
    }
}