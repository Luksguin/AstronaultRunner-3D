using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBase : CollectableBase
{
    //public PlayerController playerController;
    //private Transform _playerCollision;

    [Header("Coin Settings")]
    public float minDistance;
    public float lerpCoin;
    private bool _collected = false;

    private void Start()
    {
        CoinAnimationManager.instance.RegisterCoin(this);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        _playerCollision.position = other.transform.position;
    }*/

    protected override void OnCollect()
    {
        base.OnCollect();
        //CoinManager.instance.AddCoins();
        _collected = true;
    }

    private void Update()
    {
        if (_collected)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.instance.transform.position, lerpCoin * Time.deltaTime);

            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < minDistance)
            {
                DestroyCollectable();
            }
        }
    }
}
