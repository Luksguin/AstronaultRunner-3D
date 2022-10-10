using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVelocity : PowerUpBase
{
    [Header("PowerUp Velocity")]
    public PlayerController playerController;
    public MeshRenderer meshRenderer;
    public float forcePowerUp;

    protected override void OnCollect()
    {
        base.OnCollect();
        CollectableManager.instance.MultiplyVelocity();

        Destroy(meshRenderer);
        Destroy(gameObject, duration);
    }

    /*protected override void StartPowerUp()
    {

    }*/

    protected override void EndPowerUp()
    {
        playerController.currentVelocity = playerController.startVelocity;
    }
}
