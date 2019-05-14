using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.zero;
    
    [Inject] private MapController mapController;
    [Inject] private GameController gameController;
    [Inject] private GameConfig gameconfig;
    
    private float speed
    {
        get { return gameconfig.ballSpeed; }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            direction = direction == Vector3.forward ? Vector3.right : Vector3.forward;
        }
        
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < 0)
        {
            gameController.EndGame();
        }
    }
}
