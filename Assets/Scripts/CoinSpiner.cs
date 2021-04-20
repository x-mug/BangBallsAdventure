using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpiner : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(Vector3.up, 180*Time.deltaTime, Space.World);
    }
}
