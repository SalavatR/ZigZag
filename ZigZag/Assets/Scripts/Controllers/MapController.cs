using Pool;
using Tile;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace Controllers
{
    public class MapController : MonoBehaviour
    {
        [Inject] private TilesPoolManager tilesPoolManager;
        [Inject] private ScoreObjectsPoolManager scoreObjectsPoolManager;

        [Inject] private GameConfig gameConfig;

        private Vector3 startForw = new Vector3(3, 0, 6);
        private Vector3 startRight = new Vector3(6, 0, 3);

        private Vector3 Forw = new Vector3(0, 0, 3);
        private Vector3 Left = new Vector3(3, 0, 0);


        private Vector3 CrystalPosition = new Vector3(0, 4.5f, 0);

        Random rand = new Random();

        private Vector3 lastPosition;


        private Vector3 nextPosition
        {
            get { return rand.Next(0, 2) == 0 ? Forw : Left; }
        }

        private Vector3 startPosition
        {
            get { return rand.Next(0, 2) == 0 ? startForw : startRight; }
        }

        private bool hasCrystal
        {
            get { return rand.Next(0, 100) < gameConfig.ScoreObjectChance; }
        }

        private void Start()
        {
            Generate(gameConfig.startTilesCount);
        }

        public void Generate(int startTiles)
        {
            lastPosition = startPosition;
            for (var i = 0; i < startTiles; i++)
            {
                CreateTile();
            }
        }

        public void CreateTile()
        {
            var pos = lastPosition;
            CreateTl(pos);
            lastPosition += nextPosition;
        }

        void CreateTl(Vector3 position)
        {
            TileBase tile = tilesPoolManager.GetObject();
            tile.transform.position = position;

            if (hasCrystal)
            {
                var scoreObject = scoreObjectsPoolManager.GetObject();
                scoreObject.transform.position = position + CrystalPosition;
                scoreObject.transform.SetParent(tile.transform);
            }
        }
    }
}