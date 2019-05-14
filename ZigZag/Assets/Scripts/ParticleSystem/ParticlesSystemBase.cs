using Pool;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace ParticleSystem
{
    public class ParticlesSystemBase : MonoBehaviour,IPoolObject
    {
        [FormerlySerializedAs("_particleSystem")] [SerializeField] UnityEngine.ParticleSystem particleSystem;

        [Inject] private ParticlesPoolManager PoolManager;
        private void OnValidate()
        {
            particleSystem = GetComponent<UnityEngine.ParticleSystem>();
        }

    
        void Update()
        {
            if(!particleSystem.IsAlive())
            {
                PoolManager.DestroyObject(this);
            }
        }

        public void ResetToDefault()
        {
        
        }

        public void DisableObject()
        {
            gameObject.SetActive(false);
        }
    }
}
