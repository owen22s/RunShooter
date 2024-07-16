using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject Deathloc;
    public Slider healthSlider;
    public Text healthText;
    private MeshRenderer meshRenderer;
    private Collider playerCollider;

    private void Start()
    {
        healthText.text = maxHealth.ToString();
        health = maxHealth;
        healthSlider.value = health;
        meshRenderer = GetComponent<MeshRenderer>();
        playerCollider = GetComponent<Collider>();

        // Find all bullets and subscribe to their events
        Bullet[] bullets = FindObjectsOfType<Bullet>();
        foreach (var bullet in bullets)
        {
            bullet.onBulletHit.AddListener(() => TakeDamage(1)); // Assuming each bullet does 1 damage
        }

        // Find all BackonPlat instances in the scene and subscribe to their events
        BackonPlat[] backonPlats = FindObjectsOfType<BackonPlat>();
        foreach (var backonPlat in backonPlats)
        {
            backonPlat.onPlayerDamaged.AddListener(TakeDamage);
        }
    }

    private void OnEnable()
    {
        // Subscribe to new bullets when they are created
        Bullet.OnBulletSpawned += OnBulletSpawned;
    }

    private void OnDisable()
    {
        // Unsubscribe from bullet spawn event
        Bullet.OnBulletSpawned -= OnBulletSpawned;
    }

    private void OnBulletSpawned(Bullet bullet)
    {
        // Subscribe to the new bullet's onBulletHit event
        bullet.onBulletHit.AddListener(() => TakeDamage(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Player is dead");
            StartCoroutine(HandleDeath());
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthText.text = health.ToString();
        healthSlider.value = health / maxHealth;
        Debug.Log("Player received " + amount + " damage. Current health: " + health);
        if (health <= 0)
        {
            health = 0;
            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {
        // Temporarily disable the player's components
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }

        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }

        // Move player to the death location
        transform.position = Deathloc.transform.position;

        // Wait for a frame to ensure position update
        yield return null;

        // Re-enable the player's components
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }

        if (meshRenderer != null)
        {
            meshRenderer.enabled = true;
        }

        // Here you can add additional logic, like triggering a game over event
    }
}
