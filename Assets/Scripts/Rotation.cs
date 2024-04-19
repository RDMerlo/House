using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("Скорость вращения вокруг оси Х")]
    [Range(-30, 30)]
    public float angleSpeedX = 0f;

    [Header("Скорость вращения вокруг оси Y")]
    [Range(-30, 30)]
    public float angleSpeedY = 5f;

    [Header("Скорость вращения вокруг оси Z")]
    [Range(-30, 30)]
    public float angleSpeedZ = 0f;

    [Header("Время стабилизации, сек.")]
    [Range(0, 10)]
    public float timeS = 3f;

    [HideInInspector]
    public bool activate = false;

    [HideInInspector]
    public bool speedIsMax = false;

    private float x, y, z, t;


    void DeltaSpeed()
    {
        if (timeS != 0)
        {
            x = angleSpeedX * (t / timeS);
            y = angleSpeedY * (t / timeS);
            z = angleSpeedZ * (t / timeS);
        }
    }
    

    void Start()
    {
        x = angleSpeedX;
        y = angleSpeedY;
        z = angleSpeedZ;
    }


    void FixedUpdate()
    {
        if (activate)
        {
            t += Time.deltaTime;
            if (t > timeS)
            {
                t = timeS;
                speedIsMax = true;
            }
        }
        else
        {
            t -= Time.deltaTime;
            if (t < 0) t = 0;
            speedIsMax = false;
        }

        DeltaSpeed();
        transform.rotation *= Quaternion.Euler(x, y, z);
    }
}
