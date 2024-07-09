using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletlifespan : MonoBehaviour
{
    public float timeAlive;
    public float MaxTime;

    private void Start()
    {
        
        timeAlive = 0f;
    }

    private void Update()
    {
        // Accumulate the elapsed time
        timeAlive += Time.deltaTime;

        // Check if the turret has been alive for more than or equal to 10 seconds
        if (timeAlive >= MaxTime)
        {
            Destroy(gameObject);
        }
    }
}
