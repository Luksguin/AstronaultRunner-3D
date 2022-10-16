using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVelocity : PowerUpBase
{
    [Header("PowerUp Velocity")]
    public PlayerController playerController;
    public MeshRenderer meshRenderer;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PowerUpManager.instance.InitPowerUpVelocity();

        Destroy(meshRenderer);
        Destroy(gameObject, duration);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PowerUpManager.instance.EndPowerUpVelocity();
    }
}
