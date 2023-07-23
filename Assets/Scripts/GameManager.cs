using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public event Action CounterUpdated;
    public event Action GameWasStarted;

    public int Count = 0;

    private PlayerController player;
    private IController[] controllers;

    private bool isGameStarted = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        controllers = FindObjectsOfType<MonoBehaviour>().OfType<IController>().ToArray();
    }

    private void Update()
    {
        if(!isGameStarted && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))) 
        {
            StartGameplay();
            isGameStarted= true;
            GameWasStarted?.Invoke();
        }
    }

    public void StartGameplay()
    {
        if (player)
        {
            player.PointCollision += Player_PointCollision;
            player.ObstacleCollision += Player_ObstacleCollision;
            player.Start();
        }

        for(int i = 0; i < controllers.Length; i++)
        {
            controllers[i].Initialize();
        }
    }

    private void Player_ObstacleCollision()
    {
        Count++;
        CounterUpdated?.Invoke();
    }

    private void Player_PointCollision()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
