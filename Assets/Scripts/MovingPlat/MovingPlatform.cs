using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField ]private WaypointPath _waypointPath;
    [SerializeField] 
    private float _speed;

    private int _targetWaypointIndex;
    private Transform _perviousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;

        float elaspedPercentage = _elapsedTime / _timeToWaypoint;
        //elaspedPercentage = Mathf.SmoothStep(0,1,elaspedPercentage);
        transform.position = Vector3.Lerp( _perviousWaypoint.position, _targetWaypoint.position, elaspedPercentage);
        transform.rotation = Quaternion.Lerp(_perviousWaypoint.rotation, _targetWaypoint.rotation, elaspedPercentage);

        if (elaspedPercentage >= 1 ) 
        {
            TargetNextWaypoint();
        }
    }


    private void TargetNextWaypoint()
    {
        _perviousWaypoint = _waypointPath.Getwaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.Getwaypoint(_targetWaypointIndex);
        _elapsedTime = 0f;    

        float distanceToWaypoint = Vector3.Distance(_perviousWaypoint.position,_targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
        other.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }

    }
}
