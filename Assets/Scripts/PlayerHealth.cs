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
        if (collision.gameObject.name == "Bullet")
        {
            health--;
        }
        Debug.Log("hit");
    }
    // Update is called once per frame
    void Update()
    {
        if (health < 0) 
        {
            Debug.Log("dead");

        }
    }
}
