using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class PowerUpManager : Singleton<PowerUpManager>
{
    public PlayerController playerController;
    public PowerUpVelocity powerUpVelocity;
    private float _power;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        _power = powerUpVelocity.forcePowerUp;
    }
    public void InitPOwerUpVelocity()
    {
        playerController.currentVelocity *= _power;
    }

    public void EndPowerUpVelocity()
    {
        playerController.currentVelocity = playerController.startVelocity;
    }
}
