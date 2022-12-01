using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableBase : MonoBehaviour
{
    public string collectorTag;
    protected bool isPowerUp = false;

    [Header("BounceSettings")]
    public float bounceSize;
    public float bounceTime;
    public Ease bounceEase;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == collectorTag)
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        BouncePlayer.instance.Bounce(bounceSize, bounceTime, bounceEase);
    }
}
