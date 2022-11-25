using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBase : CollectableBase
{
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
        base.OnCollect();
        //CoinManager.instance.AddCoins();
        BouncePlayer.instance.Bounce();
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
