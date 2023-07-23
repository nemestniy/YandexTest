using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public float Speed = 5.0f;
    public string TagTarget = "Player";
    public float LifeTime = 5.0f;

    private Coroutine currentRoutine;

    private void Update()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0.0f)
        {
            Destroy(gameObject);                       
        }
    }

    private IEnumerator MoveToPlayer(Transform target)
    {
        while (this)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * Speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public void StartMoving(Transform target)
    {
        if (currentRoutine == null)
        {
            currentRoutine = StartCoroutine(MoveToPlayer(target));
        }
    }
}
