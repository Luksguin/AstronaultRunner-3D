using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ebac.Core.Singleton;

public class BouncePlayer : Singleton<BouncePlayer>
{
    public GameObject player;
    public Ease ease;

    public void Bounce()
    {
        player.transform.DOScale(1.1f, .05f).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
