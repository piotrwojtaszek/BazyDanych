using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float m_speed = 1f;

    Vector3 rotationEuler;
    void Update()
    {
        rotationEuler += Vector3.forward * m_speed * Time.deltaTime; //increment 30 degrees every second
        transform.rotation = Quaternion.Euler(rotationEuler);

        //To conver
    }
}
