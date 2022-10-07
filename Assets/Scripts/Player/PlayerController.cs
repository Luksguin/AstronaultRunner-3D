using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject restartMenu;
    public float velocity;
    public string tagToCheck;

    private Vector3 _pos;
    private bool _alive = true;

    [Header("Lerp")]
    public Transform lerper;
    public float lerpTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheck)
        {
            EndGame();
        }
    }

    private void Reset()
    {
        
    }

    public void EndGame()
    {
        _alive = false;
        restartMenu.SetActive(true);
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
}
