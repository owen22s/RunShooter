using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
   public Transform Getwaypoint (int waypointIndex) 
    {
        return transform.GetChild(waypointIndex);
    }



    public int GetNextWaypointIndex(int CurrentwaypointIndex) 
    {
        int nextWaypointIndex = CurrentwaypointIndex = 1;

        if (nextWaypointIndex ==transform.childCount) 
        {
        nextWaypointIndex = 0;
        }

        return nextWaypointIndex;
    }
}
