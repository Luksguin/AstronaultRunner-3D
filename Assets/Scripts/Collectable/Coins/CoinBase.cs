using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBase : CollectableBase
{
    public PlayerController playerController;

    [Header("Coin Settings")]
    public float minDistance;
    public float lerpCoin;
    private bool _collected = false;

    private void Start()
    {
        CoinAnimationManager.instance.RegisterCoin(this);
    }

    protected override void OnCollect()
    {
        //CoinManager.instance.AddCoins();
        _collected = true;
    }

    private void Update()
    {
        if (_collected)
        {
            transform.position = Vector3.Lerp(transform.position, playerController.transform.position, lerpCoin * Time.deltaTime);

            if (Vector3.Distance(transform.position, playerController.transform.position) < minDistance)
            {
                DestroyCollectable();
            }
        }
    }
}
