using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float RotationSpeed1;
    public float RotationSpeed2;
    public float RotationSpeed3;


    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(RotationSpeed1 * Time.deltaTime, RotationSpeed2 * Time.deltaTime, RotationSpeed3 * Time.deltaTime, Space.World);
    }

}
