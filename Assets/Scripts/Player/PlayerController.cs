using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;

    [Header("Lerp")]
    public Transform lerper;
    public float lerpTime;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, lerper.position, lerpTime * Time.deltaTime);
        transform.Translate(transform.forward * velocity * Time.deltaTime);
    }
}
