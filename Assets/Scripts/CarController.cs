using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider[] wheelsCol;
    public Transform[] wheelsMesh;

    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float maxBreakTorque;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < wheelsCol.Length; i++)
        {
            wheelsCol[i].transform.position = wheelsMesh[i].position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float brake = maxBreakTorque * 5;

        wheelsCol[0].steerAngle = steering;
        wheelsCol[1].steerAngle = steering;

        if (Input.GetKey("space"))
        {
            wheelsCol[0].motorTorque = 0;
            wheelsCol[1].motorTorque = 0;
            wheelsCol[0].brakeTorque = brake;
            wheelsCol[1].brakeTorque = brake;
        }
        else
        {
            wheelsCol[0].motorTorque = motor;
            wheelsCol[1].motorTorque = motor;
            wheelsCol[0].brakeTorque = 0;
            wheelsCol[1].brakeTorque = 0;
        }

        for (int i = 0; i < wheelsMesh.Length; i++)
        {
            Vector3 p;
            Quaternion q;
            wheelsCol[i].GetWorldPose(out p, out q);

            wheelsMesh[i].position = p;
            wheelsMesh[i].rotation = q;
        }
    }
}
