using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCoin : CollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        CoinManager.instance.AddCoins(2);
    }
}
