using System.Collections;
using Controllers;
using Pool;
using ScoreObjects;
using UnityEngine;
using Zenject;

namespace Tile
{
    public class TileBase : MonoBehaviour, IPoolObject
    {
        [Inject] private MapController mapController;
        [Inject] public UIController uiController;
        [Inject] private TilesPoolManager poolManager;
        [Inject] private ScoreObjectsPoolManager scoreObjectsPoolManager;
    
        [SerializeField] private Rigidbody rigidbody;
        ScoreObjectBase scoreObject;

    
    
        private void OnValidate()
        {
            if (!rigidbody) rigidbody = GetComponent<Rigidbody>();
        }

        void Init(ScoreObjectBase scoreObject)
        {
            this.scoreObject = scoreObject;
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                uiController.AddTile();
                mapController.CreateTile();
                StartCoroutine(fall());
            }
        }

        private IEnumerator fall()
        {
            rigidbody.isKinematic = false;
            yield return new WaitForSeconds(1.5f);
            poolManager.DestroyObject(this);
        }

        public void ResetToDefault()
        {
            rigidbody.isKinematic = true;
        }

        public void DisableObject()
        {
            gameObject.SetActive(false);
            if(scoreObject) scoreObjectsPoolManager.DestroyObject(scoreObject);
        }
    }
}