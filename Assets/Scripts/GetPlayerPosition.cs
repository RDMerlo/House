using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerPosition : MonoBehaviour
{
    //Используем паттерн Синглтон
    public static GetPlayerPosition Instance {get; private set;}

    [HideInInspector]
    public Vector3 playerPosition;

    private void Awake()
    {
        Instance = this;
        playerPosition = transform.position;
    }


    void Update()
    {
        playerPosition = transform.position;
    }
}
