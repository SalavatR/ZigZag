using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        [Inject] private UIController uiController;
        public bool IsPlaing = true;
        public void EndGame()
        {
            IsPlaing = false;
            uiController.ActivateRestartButton(true);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}