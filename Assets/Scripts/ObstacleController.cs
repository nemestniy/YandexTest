using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float LifeTime = 5.0f;
    public float MaxGlobalOffset = 3.0f;

    public float startHeight;

    private void Awake()
    {
        startHeight = Random.Range(-MaxGlobalOffset, MaxGlobalOffset);
    }

    private void Update()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }

        float height = Mathf.Sin(startHeight) * MaxGlobalOffset;

        transform.position = new Vector3(transform.position.x, 
                                         height, 
                                         transform.position.z);
        startHeight += Time.deltaTime;
    }
}
