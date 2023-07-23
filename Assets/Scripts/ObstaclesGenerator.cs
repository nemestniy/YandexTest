using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    public Transform Target;

    [Space(10)]

    [Header("Obstacles generation settings:")]
    public GameObject ObstaclePrefab;
    public float GeneratingStep = 15.0f;
    public float OffsetSpawning = 3.5f;

    private int currentGeneration;

    private void Start()
    {
        Initialization();
        StartCoroutine(GeneratingObstacles());
    }

    private void Initialization()
    {
        if (!Target)
        {
            Target = Camera.main.transform;
        }

        currentGeneration = 0;
    }

    private IEnumerator GeneratingObstacles()
    {
        while (true)
        {
            if (currentGeneration < (int)Target.position.x / 15)
            {
                currentGeneration++;
                GenerateObstacles(1);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void GenerateObstacles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float xOffset = Random.Range(-OffsetSpawning, OffsetSpawning);
            Vector3 spawnPosition = new Vector3(Target.position.x + GeneratingStep + xOffset, 
                                                Target.position.y, 
                                                ObstaclePrefab.transform.position.z);
            Instantiate(ObstaclePrefab, spawnPosition, ObstaclePrefab.transform.rotation);
        }
    }
}
