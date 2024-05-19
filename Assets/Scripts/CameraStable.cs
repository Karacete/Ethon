using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    [SerializeField]
    private GameObject car;
    private float carX;
    private float carY;
    private float carZ;
    void Update()
    {
        carX = car.transform.eulerAngles.x;
        carY = car.transform.eulerAngles.y;
        carZ = car.transform.eulerAngles.z;
        this.gameObject.transform.eulerAngles = new Vector3(carX - carX, carY, carZ - carZ);
    }
}
