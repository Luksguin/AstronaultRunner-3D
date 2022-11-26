using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ebac.Core.Singleton;

public class BouncePlayer : Singleton<BouncePlayer>
{
    public GameObject player;

    public void Bounce(float size, float time, Ease ease)
    {
        player.transform.DOScale(size, time).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
