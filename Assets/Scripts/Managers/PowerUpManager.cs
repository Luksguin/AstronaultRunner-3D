using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

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

    [Header("PowerUpFly")]
    public Transform playerTransform;
    private Vector3 _startHeigth;

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

    #region VELOCITY
    public void InitPowerUpVelocity()
    {
        playerController.currentVelocity *= forcePowerUpVelocity;
    }

    public void EndPowerUpVelocity()
    {
        playerController.currentVelocity = playerController.startVelocity;
    }
    #endregion

    #region INVENCIBLE
    public void InitPowerUpInvencible()
    {
        playerController.invencible = true;
    }

    public void EndPowerUpInvencible()
    {
        playerController.invencible = false;
    }
    #endregion

    public void InitPowerUpFly(float amount, float duration, float animationDuration, Ease ease)
    {
        playerTransform.transform.DOMoveY(_startHeigth.y + amount, animationDuration).SetEase(ease);
    }

    public void EndPowerUpFly(float animationDuration, Ease ease)
    {
        playerTransform.transform.DOMoveY(_startHeigth.y, animationDuration).SetEase(ease);
    }
}
