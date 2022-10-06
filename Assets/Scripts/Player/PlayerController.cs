using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    void Update()
    {
        transform.Translate(transform.forward * velocity * Time.deltaTime);
    }
}
