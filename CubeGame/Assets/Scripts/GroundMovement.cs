using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float destroyPos;
    public Vector3 instantiatePos;
    void Update()
    {
        if(transform.position.z <= destroyPos)
        {
            Instantiate(gameObject, instantiatePos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
