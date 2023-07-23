using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour, IController
{
    public Transform Target;

    [Space(10)]

    [Header("Objects generation settings:")]
    public GameObject ObjectPrefab;
    public float GeneratingStep = 15.0f;
    public float OffsetSpawning = 3.5f;

    private int currentGeneration;

    public void Initialize()
    {
        if (!Target)
        {
            Target = Camera.main.transform;
        }

        currentGeneration = 0;

        StartCoroutine(GeneratingObstacles());
    }

    private IEnumerator GeneratingObstacles()
    {
        while (true)
        {
            if (currentGeneration < (int)Target.position.x / 15)
            {
                currentGeneration++;
                GenerateObjects(1);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    protected void GenerateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float xOffset = Random.Range(-OffsetSpawning, OffsetSpawning);
            float yOffset = Random.Range(-OffsetSpawning, OffsetSpawning);
            Vector3 spawnPosition = new Vector3(Target.position.x + GeneratingStep + xOffset,
                                                Target.position.y + yOffset,
                                                ObjectPrefab.transform.position.z);
            Instantiate(ObjectPrefab, spawnPosition, ObjectPrefab.transform.rotation);
        }
    }
}
