using UnityEngine;

public class BackonPlat : MonoBehaviour
{
    [SerializeField]
    private GameObject _MPlat;

    private void OnTriggerEnter(Collider other)
    {
        if (_MPlat == null)
        {
            Debug.LogError("Platform (_MPlat) is not assigned.");
            return;
        }

        if (other.CompareTag("Player")) // Assuming the collider should belong to a GameObject tagged "Player"
        {
            MoveToPlatform(other.gameObject);
        }
    }

    private void MoveToPlatform(GameObject player)
    {
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
        {
            // Temporarily disable the CharacterController to move the player
            controller.enabled = false;
            player.transform.position = _MPlat.transform.position;
            controller.enabled = true;
        }
        else
        {
            player.transform.position = _MPlat.transform.position;
        }
        Debug.Log("Platform position: " + _MPlat.transform.position);
        Debug.Log("Player object: " + player.name); // Logging the name of the player object
    }
}
