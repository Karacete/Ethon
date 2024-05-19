using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AICarControllerScript))]
public class AICarControllerScript : MonoBehaviour
{
    [SerializeField]
    private WayPointScript wayPointScript;
    private List<Transform> wayPointsTr;
    private int currentWayPoint;
    private CarController carController;
    private float wayPointRange;
    private float currentAngle;
    void Start()
    {
        carController = GetComponent<CarController>();
        wayPointsTr = wayPointScript.wayPointTr;
        currentWayPoint = 0;
        wayPointRange = 30;
    }
    void Update()
    {
        if (Vector3.Distance(wayPointsTr[currentWayPoint].position,transform.position)<wayPointRange)
        {
            currentWayPoint += 1;
            Debug.Log(currentWayPoint);
            if (currentWayPoint == wayPointsTr.Count)
                currentWayPoint = 0;
        }
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        currentAngle = Vector3.SignedAngle(fwd, wayPointsTr[currentWayPoint].position - transform.position, Vector3.up);
        carController.SetInput(1, currentAngle, 0, 0);
        Debug.DrawRay(transform.position, wayPointsTr[currentWayPoint].position-transform.position, Color.yellow);
    }
}
