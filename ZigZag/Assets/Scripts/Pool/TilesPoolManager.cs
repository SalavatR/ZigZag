using Tile;

namespace Pool
{
    public class TilesPoolManager : PoolManagerBase<TileBase>
    {
        public TilesPoolManager(int stackPreSize, TileBase objPrefab) : base(stackPreSize, objPrefab)
        {
        }
    }
}