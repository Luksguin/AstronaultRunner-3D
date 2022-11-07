using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHelper : MonoBehaviour
{
    public Transform lerper;
    public float lerpTime;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, lerper.position, lerpTime * Time.deltaTime);
    }
}
