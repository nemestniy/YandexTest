using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour
    where T : MonoBehaviour
{
    public static T Instance => instance;
    private static T instance;

    private void OnEnable()
    {
        if (!instance)
        {
            instance = GetComponent<T>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
