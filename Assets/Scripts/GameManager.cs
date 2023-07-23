using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public event Action CounterWasUpdated;
    public UnityEvent GameWasStarted;

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
            player.Initialize();
        }

        for(int i = 0; i < controllers.Length; i++)
        {
            controllers[i].Initialize();
        }
    }

    private void Player_PointCollision()
    {
        Count++;
        CounterWasUpdated?.Invoke();
    }

    private void Player_ObstacleCollision()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
