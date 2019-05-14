using UnityEngine;
using Zenject;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        [Inject] private Player player;

        [SerializeField] private float xOffset;
        [SerializeField] private float zOffset;
        [SerializeField] private float yPosition;

        [Inject] private GameController gameController;

        private void OnValidate()
        {
            var position = transform.position;
            xOffset = position.x;
            zOffset = position.z;
            yPosition = position.y;
        }

        private void Update()
        {
            if (!gameController.IsPlaing) return;
            var playerPos = player.transform.position;
            transform.position = new Vector3(playerPos.x + xOffset, yPosition, playerPos.z + zOffset);
        }
    }
}