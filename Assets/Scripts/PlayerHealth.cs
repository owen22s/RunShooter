using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision object has the "Bullet" tag
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            Debug.Log("Hit by bullet");
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player is dead");
            // Here you can add code to handle player death, like triggering a game over event, etc.
        }
    }
}
