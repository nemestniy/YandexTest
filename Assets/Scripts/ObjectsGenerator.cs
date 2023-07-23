using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectsGenerator : MonoBehaviour, IController
{
    public event Action UpdatedGeneration;

    public Transform Target;

    [Space(10)]

    [Header("Objects generation settings:")]
    public GameObject ObjectPrefab;
    public float GeneratingStep = 15.0f;
    public float OffsetSpawning = 3.5f;

    private int currentGeneration;
    protected int objectsCountForGenerating = 1;

    public virtual void Initialize()
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
            if (currentGeneration < (int)Target.position.x / (int)GeneratingStep)
            {
                currentGeneration++;
                UpdatedGeneration?.Invoke();
                GenerateObjects(objectsCountForGenerating);
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
