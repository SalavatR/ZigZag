using ParticleSystem;
using Pool;
using ScoreObjects;
using Tile;
using UnityEngine;
using Zenject;

namespace Controllers
{
    [CreateAssetMenu(fileName = "ScriptableObjInstaller",menuName = "Scriptable Object Installer")]
    public class ScriptableObjInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameConfig _config;

        [SerializeField] private TileBase tilePrefab;
        [SerializeField] private ScoreObjectBase scoreObjectPrefab;
        [SerializeField] private ParticlesSystemBase particleSystemPrefab;

        public override void InstallBindings()
        {
            Container.BindInstance(_config);
        
            Container.BindInstance(new TilesPoolManager(30,tilePrefab)).AsSingle();
            Container.BindInstance(new ScoreObjectsPoolManager(10,scoreObjectPrefab)).AsSingle();
            Container.BindInstance(new ParticlesPoolManager(10, particleSystemPrefab)).AsSingle();
        }
    }
}