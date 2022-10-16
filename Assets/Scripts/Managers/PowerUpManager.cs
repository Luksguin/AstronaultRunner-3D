using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class PowerUpManager : Singleton<PowerUpManager>
{
    public PlayerController playerController;

    [Header("PowerUpVelocity")]
    //public PowerUpVelocity powerUpVelocity;
    //public float powerUpVelocityDuration;
    public float forcePowerUpVelocity;

    #region PROTOTYPE 
    /*[Header("PowerUpInvencible")]
    public PowerUpInvencible powerUpInvencible;
    public float powerUpInvencibleDuration;*/
    #endregion

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        #region PROTOTYPE 2
        //powerUpInvencible.duration = powerUpInvencibleDuration;
        //powerUpVelocity.duration = powerUpVelocityDuration;
        #endregion
    }

    public void InitPowerUpVelocity()
    {
        playerController.currentVelocity *= forcePowerUpVelocity;
    }

    public void EndPowerUpVelocity()
    {
        playerController.currentVelocity = playerController.startVelocity;
    }

    public void InitPowerUpInvencible()
    {
        playerController.invencible = true;
    }

    public void EndPowerUpInvencible()
    {
        playerController.invencible = false;
    }
}
