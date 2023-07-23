using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour, IController
{
    public float Speed = 1.0f;
    private bool isInitialized = false;

    public void Initialize()
    {
        isInitialized = true;
    }

    void Update()
    {
        if (isInitialized)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
    }
}
