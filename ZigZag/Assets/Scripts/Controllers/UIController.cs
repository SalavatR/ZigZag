using System;
using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Tiles;
    [SerializeField] private TextMeshProUGUI Cristals;
    [SerializeField] private Button bt_restart;


    [Inject] private GameController gameController;
    private uint crystals;
    private uint tiles;

    private void Start()
    {
        ActivateRestartButton(false);
        bt_restart.onClick.AddListener(gameController.RestartGame);
    }

    public void AddTile()
    {
        tiles++;
        Tiles.text = tiles.ToString();
    }

    public void AddCristal()
    {
        crystals++;
        Cristals.text = crystals.ToString();
    }

    public void ActivateRestartButton(bool val)
    {
        bt_restart.gameObject.SetActive(val);
    }
}