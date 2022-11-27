using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableBase : MonoBehaviour
{
    public string collectorTag;
    public float timeToDestroy;
    protected bool isPowerUp = false;

    [Header("Particle")]
    public ParticleSystem systemParticle;

    [Header("Animations")]
    public Animator animator;
    //public string setTrigger;

    [Header("Sounds")]
    public AudioSource audioClip;

    [Header("BounceSettings")]
    public float bounceSize;
    public float bounceTime;
    public Ease bounceEase;

    /*private void Awake()
    {
        if(systemParticle != null) systemParticle.transform.SetParent(null);
    }*/

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
        //animator.SetTrigger(setTrigger);
    }

    public void DestroyCollectable()
    {
        Destroy(gameObject, timeToDestroy);
    }

    protected virtual void OnCollect()
    {
        BouncePlayer.instance.Bounce(bounceSize, bounceTime, bounceEase);

        if (systemParticle != null)
        {
            systemParticle.transform.SetParent(null);
            systemParticle.Play();
        }
        if (audioClip != null) audioClip.Play();
    }
}
