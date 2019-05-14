using ParticleSystem;

namespace Pool
{
    public class ParticlesPoolManager : PoolManagerBase<ParticlesSystemBase>
    {
        public ParticlesPoolManager(int stackPreSize, ParticlesSystemBase objPrefab) : base(stackPreSize, objPrefab)
        {
        }
    }
}