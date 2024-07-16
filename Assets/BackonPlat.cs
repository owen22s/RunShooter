using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BackonPlat : MonoBehaviour
{
    [SerializeField]
    private GameObject _MPlat;
    [SerializeField]
    private float damageAmount = 5.0f;

    [System.Serializable]
    public class DamageEvent : UnityEvent<float> { }

    public DamageEvent onPlayerDamaged;

    private void OnTriggerEnter(Collider other)
    {
        if (_MPlat == null)
        {
            Debug.LogError("Platform (_MPlat) is not assigned.");
            return;
        }

        if (other.CompareTag("Player"))
        {
            Debug.LogWarning("playerhit");
            StartCoroutine(MoveToPlatform(other.gameObject));
            
            onPlayerDamaged.Invoke(5);
        }
    }

    private IEnumerator MoveToPlatform(GameObject player)
    {
        CharacterController controller = player.GetComponent<CharacterController>();
        Collider playerCollider = player.GetComponent<Collider>();
        MeshRenderer playerRenderer = player.GetComponent<MeshRenderer>();

        if (playerCollider != null)
        {
            playerCollider.enabled = false; // Temporarily disable the player's collider
        }

        if (playerRenderer != null)
        {
            playerRenderer.enabled = false; // Temporarily disable the player's renderer
        }

        if (controller != null)
        {
            controller.enabled = false; // Temporarily disable the CharacterController
            player.transform.position = _MPlat.transform.position;
            yield return null; // Wait for a frame to ensure position update
            controller.enabled = true; // Re-enable the CharacterController
        }
        else
        {
            player.transform.position = _MPlat.transform.position;
            yield return null; // Wait for a frame to ensure position update
        }

        if (playerCollider != null)
        {
            playerCollider.enabled = true; // Re-enable the player's collider
        }

        if (playerRenderer != null)
        {
            playerRenderer.enabled = true; // Re-enable the player's renderer
        }

        // Invoke the damage event
        onPlayerDamaged.Invoke(damageAmount);

        Debug.Log("Platform position: " + _MPlat.transform.position);
        Debug.Log("Player object: " + player.name);
    }
}