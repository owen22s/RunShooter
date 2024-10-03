using UnityEngine;

public class TurretMoving : MonoBehaviour
{
    private bool MoveRight;
    public GameObject Turret;

    // Start is called before the first frame update
    void Start()
    {
        Turret = GameObject.FindWithTag("TurretTag");
        while (MoveRight == true)
        {
            Vector3 newPosition = Turret.transform.position;
            newPosition.z += 1f;
            Turret.transform.position = newPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
