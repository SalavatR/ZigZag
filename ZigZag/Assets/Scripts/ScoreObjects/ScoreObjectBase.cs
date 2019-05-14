using Controllers;
using Pool;
using UnityEngine;
using Zenject;

namespace ScoreObjects
{
    public class ScoreObjectBase : MonoBehaviour,IPoolObject
    {
        // Start is called before the first frame update
        [Inject] protected MapController MapGenerator;
        [Inject] protected UIController uiController;

        [Inject] private ScoreObjectsPoolManager poolManager;
        [Inject] private ParticlesPoolManager particlesPoolManager;

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(string.Intern("Player"))) return;

        
            uiController.AddCristal();
            var particles = particlesPoolManager.GetObject();
            particles.transform.position = transform.position;
            poolManager.DestroyObject(this);
        }


        public void ResetToDefault()
        {
        
        }

        public void DisableObject()
        {
            transform.parent = null;
            gameObject.SetActive(false);
        }
    }
}
