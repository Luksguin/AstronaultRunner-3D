using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollectableBase
{
    [Header("PowerUp")]
    public float duration;
    public MeshRenderer meshRenderer;

    private void Awake()
    {
        isPowerUp = true;
    }

    protected override void OnCollect()
    {
        base.OnCollect();

        StartPowerUp();
        Destroy(meshRenderer);
        Destroy(gameObject, duration);
    }

    protected virtual void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp()
    {

    }
}
