using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public string tagToCheck;
    private bool _alive;
    private Vector3 _pos;

    [Header("Lerp")]
    public Transform lerper;
    public float lerpTime;

    private void Start()
    {
        _alive = true;
    }

    void Update()
    {
        if (_alive != true) return;

        _pos = lerper.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpTime * Time.deltaTime);
        transform.Translate(transform.forward * velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheck)
        {
            _alive = false;
        }
    }
}
