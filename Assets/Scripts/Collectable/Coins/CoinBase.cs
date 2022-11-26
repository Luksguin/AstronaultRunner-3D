using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBase : CollectableBase
{
    [Header("Coin Settings")]
    public float minDistance;
    public float lerpCoin;
    public float bounceSize;
    public float bounceTime;

    private bool _collected = false;

    private void Start()
    {
        CoinAnimationManager.instance.RegisterCoin(this);
    }

    private void OnDestroy()
    {
        CoinAnimationManager.instance.UnRegisterCoin(this);
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        //CoinManager.instance.AddCoins();
        BouncePlayer.instance.Bounce(bounceSize, bounceTime);
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
