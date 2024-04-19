using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    private Rotation temp;

    private void Start()
    {
        temp = GetComponent<Rotation>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, GetPlayerPosition.Instance.playerPosition) < 5)
        {
            temp.activate = true;
        }
        else
        {
            temp.activate = false;
        }
    }
}
