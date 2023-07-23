using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Gravity = 9.8f;

    private Vector3 movementDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
