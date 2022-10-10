using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using Ebac.Core.Singleton;

public class CollectableManager : Singleton<CollectableManager>
{
    /*[Header("Coins")]
    public SOInt currentCoins;
    public SOInt specialCoins;
    public TextMeshProUGUI coinAmount;*/

    [Header("PowerUp Velocity")]
    public PlayerController playerController;
    public PowerUpVelocity powerUpVelocity;
    private float _power;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        //currentCoins.value = 0;
        _power = powerUpVelocity.forcePowerUp;
    }

    public void AddCoins(int amount = 1)
    {
        //coinAmount.text = currentCoins.value.ToString();
        //currentCoins.value += amount;
    }

    public void MultiplyVelocity()
    {
        playerController.currentVelocity *= _power;
    }
}
