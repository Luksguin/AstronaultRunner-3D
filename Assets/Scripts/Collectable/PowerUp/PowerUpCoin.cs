using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoin : PowerUpBase
{
    public float forcePowerUp;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PowerUpManager.instance.ChangeSizeCoinCollector(forcePowerUp);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PowerUpManager.instance.ChangeSizeCoinCollector(1);
    }
}
