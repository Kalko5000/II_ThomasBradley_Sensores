using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSamurai : MonoBehaviour
{
    private Transform samuraiTransform;
    private Vector3 initialForward;
    private float smoothing = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        if(SystemInfo.supportsGyroscope) {
            Input.gyro.enabled = true;
            Input.compass.enabled = true;
        }
        Input.location.Start();
        samuraiTransform = GetComponent<Transform>();
        initialForward = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        // // transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
        // Quaternion attitude = Input.gyro.attitude;

        // var rotator = attitude;
        // rotator *= Quaternion.Euler(0f, 0f, 180f);
        // rotator *= Quaternion.Euler(90f, 180f, 0f);

        // transform.rotation = Quaternion.Slerp(transform.rotation, rotator, smoothing);

        // Rotación
        if (Input.compass.enabled)
        {
            float magneticNorth = Input.compass.magneticHeading;
            transform.rotation = Quaternion.Euler(0, -magneticNorth, 0);
        }

        // Movimiento
        Vector3 acceleration = Input.acceleration;
        Vector3 movement = new (acceleration.x, 0, acceleration.y);
        transform.Translate(movement * Time.deltaTime, Space.World);
    }
}
