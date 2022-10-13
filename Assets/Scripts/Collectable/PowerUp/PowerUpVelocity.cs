using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVelocity : PowerUpBase
{
    [Header("PowerUp Velocity")]
    public PlayerController playerController;
    public MeshRenderer meshRenderer;
    public float forcePowerUp;

    protected override void StartPowerUp()
    {
        PowerUpManager.instance.InitPOwerUpVelocity();

        Invoke(nameof(EndPowerUp), duration);

        Destroy(meshRenderer);
        Destroy(gameObject, duration);
    }

    protected override void EndPowerUp()
    {
        PowerUpManager.instance.EndPowerUpVelocity();
    }
}
