using UnityEngine;

public class ObstaclesGenerator : ObjectsGenerator
{
    [Range(0.0f, 1.0f)]
    public float MaxObstaclesProbability = 0.1f;

    public int MaxObstacles = 5;

    private int maxObstaclesCount;
    public float coeef;

    public override void Initialize()
    {
        base.Initialize();
        maxObstaclesCount = objectsCountForGenerating;
        GameManager.Instance.CounterWasUpdated += Instance_CounterWasUpdated;
        UpdatedGeneration += ObstaclesGenerator_UpdatedGeneration;
    }

    private void ObstaclesGenerator_UpdatedGeneration()
    {
        float probability = Random.Range(0.0f, 1.0f);
        float countCoefficient = Mathf.Min(1.0f, MaxObstaclesProbability / probability);
        coeef = countCoefficient;
        objectsCountForGenerating = Mathf.Min(5, Mathf.Max(1, (int)(maxObstaclesCount * countCoefficient)));
    }

    private void Instance_CounterWasUpdated()
    {
        maxObstaclesCount++;
    }
}
