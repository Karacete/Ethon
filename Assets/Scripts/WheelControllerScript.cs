using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControllerScript : MonoBehaviour
{
    [Header("MoveProcess")]
    private float acceleration;
    private float breakingForce;
    private float currentAcceleration;
    private float currentBreakingForce;
    private float maxTurningAngle;
    private float currentTurningAngle;

    [Header("Collider")]
    [SerializeField]
    private WheelCollider frontRightCol;
    [SerializeField]
    private WheelCollider frontLeftCol;
    [SerializeField]
    private WheelCollider backRightCol;
    [SerializeField]
    private WheelCollider backLeftCol;

    [Header("Transform")]
    [SerializeField]
    private Transform frontRightTr;
    [SerializeField]
    private Transform frontLeftTr;
    [SerializeField]
    private Transform backRightTr;
    [SerializeField]
    private Transform backLeftTr;
    void Start()
    {
        acceleration = 500f;
        breakingForce = 500f;
        maxTurningAngle = 15f;
        currentAcceleration = 0f;
        currentBreakingForce = 0f;
        currentTurningAngle = 0f;
    }
    private void FixedUpdate()
    {
        VerticalMove();

        DontMove();

        HorizontalMove();

        RotateWhell(frontRightCol, frontRightTr);
        RotateWhell(frontLeftCol, frontLeftTr);
        RotateWhell(backRightCol, backRightTr);
        RotateWhell(backLeftCol, backLeftTr);

    }
    private void VerticalMove()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        frontRightCol.motorTorque = currentAcceleration;
        frontLeftCol.motorTorque = currentAcceleration;
    }
    private void DontMove()
    {
        if (Input.GetKey(KeyCode.Space))
            currentBreakingForce = breakingForce;
        else
            currentBreakingForce = 0;

        frontRightCol.brakeTorque = currentBreakingForce;
        frontLeftCol.brakeTorque = currentBreakingForce;
        backRightCol.brakeTorque = currentBreakingForce;
        backLeftCol.brakeTorque = currentBreakingForce;
    }
    private void HorizontalMove()
    {
        currentTurningAngle = maxTurningAngle * Input.GetAxis("Horizontal");
        frontLeftCol.steerAngle = currentTurningAngle;
        frontRightCol.steerAngle = currentTurningAngle;
    }
    private void RotateWhell(WheelCollider col, Transform tr)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);
        tr.position = position;
        tr.rotation = rotation;
    }
}
