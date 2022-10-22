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

    [Header("PowerUpInvencible")]
    public Color startColor;
    public Color newColor;

    #region PROTOTYPE 
    /*[Header("PowerUpInvencible")]
    public PowerUpInvencible powerUpInvencible;
    public float powerUpInvencibleDuration;*/
    #endregion

    [Header("PowerUpFly")]
    public Transform playerTransform;
    private Vector3 _startHeigth;

    [Header("PowerUpCoin")]
    public GameObject coinCollector;

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
        playerController.currentVelocity = playerController.playerVelocity;
    }
    #endregion

    #region INVENCIBLE
    private void ChangeColor(Color newColor)
    {
        playerController.playerRenderer.material.SetColor("_Color", newColor);
    }

    public void InitPowerUpInvencible()
    {
        playerController.invencible = true;
        ChangeColor(newColor);
    }

    public void EndPowerUpInvencible()
    {
        playerController.invencible = false;
        ChangeColor(startColor);
    }
    #endregion

    #region FLY
    public void InitPowerUpFly(float amount, float duration, float animationDuration, Ease ease)
    {
        playerTransform.transform.DOMoveY(_startHeigth.y + amount, animationDuration).SetEase(ease);
    }

    public void EndPowerUpFly(float animationDuration, Ease ease)
    {
        playerTransform.transform.DOMoveY(_startHeigth.y, animationDuration).SetEase(ease);
    }
    #endregion

    #region COIN
    public void ChangeSizeCoinCollector(float amount)
    {
        //coinCollector.transform.localScale = Vector3.one * amount;
        coinCollector.transform.DOScaleX(amount, .1f);
    }
    #endregion
}
