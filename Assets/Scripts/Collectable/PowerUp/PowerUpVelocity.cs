using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVelocity : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PowerUpManager.instance.InitPowerUpVelocity();
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PowerUpManager.instance.EndPowerUpVelocity();
    }
}
