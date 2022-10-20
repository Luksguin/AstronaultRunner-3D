using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : PowerUpBase
{
    public float amount;
    public float animationDuration;
    public DG.Tweening.Ease ease;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PowerUpManager.instance.InitPowerUpFly(amount, duration, animationDuration, ease);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PowerUpManager.instance.EndPowerUpFly(animationDuration, ease);
    }
}
