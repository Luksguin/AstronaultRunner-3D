using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : PowerUpBase
{
    public MeshRenderer meshRenderer;
    public float amount;
    public float animationDuration;
    public DG.Tweening.Ease ease;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PowerUpManager.instance.InitPowerUpFly(amount, duration, animationDuration, ease);

        Destroy(meshRenderer);
        Destroy(gameObject, duration);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PowerUpManager.instance.EndPowerUpFly(animationDuration, ease);
    }
}
