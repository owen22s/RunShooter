using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [System.Serializable]
    public class BulletHitEvent : UnityEvent { }

    public BulletHitEvent onBulletHit;

    public static event System.Action<Bullet> OnBulletSpawned;

    private void Awake()
    {
        OnBulletSpawned?.Invoke(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bullet hit the player.");
            onBulletHit.Invoke();

            // Optionally, disable the bullet renderer or destroy the bullet
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject);
        }
    }
}
