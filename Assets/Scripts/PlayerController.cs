using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public event Action PointCollision;
    public event Action ObstacleCollision;

    public float Gravity = 9.8f;
    public string PointTagName = "Point";
    public string ObstacleTagName = "Obstacle";

    private Vector3 movementDirection = Vector3.zero;
    private bool isStarted = false;

    public void Initialize()
    {
        isStarted = true;        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            Vector3 movementStep = Vector3.up * Gravity;

            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                movementDirection += movementStep;
            }
            else
            {
                movementDirection -= movementStep;
            }

            transform.Translate(movementDirection * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PointTagName && 
            collision.transform.parent && 
            collision.transform.parent.TryGetComponent<PointController>(out var point))
        {
            point.StartMoving(transform);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == PointTagName)
        {
            Destroy(collision.gameObject);
            PointCollision?.Invoke();
        }
        else if (collision.transform.tag == ObstacleTagName)
        {
            ObstacleCollision?.Invoke();
        }
    }
}
