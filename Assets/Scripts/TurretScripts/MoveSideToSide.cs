using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideToSide : MonoBehaviour
{
    // The speed of the movement
    public float speed = 5f;
    // The distance the object will move from side to side
    public float distance = 5f;


    [SerializeField]private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position
        float newX = startPosition.x + Mathf.PingPong(Time.time * speed, distance) - (distance / 2);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
