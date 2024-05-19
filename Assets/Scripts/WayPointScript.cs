using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WayPointScript : MonoBehaviour
{
    public List<Transform> wayPointTr;
     void Awake()
    {
        foreach(Transform tr in this.gameObject.GetComponentInChildren<Transform>())
        {
            wayPointTr.Add(tr);
        }

    }
}
