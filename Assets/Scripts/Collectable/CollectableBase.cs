using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        if(systemParticle != null) systemParticle.transform.SetParent(null);
    }

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

    protected virtual void DestroyCollectable()
    {
        Destroy(gameObject, timeToDestroy);
    }

    protected virtual void OnCollect()
    {
        if (systemParticle != null) systemParticle.Play();
        if (audioClip != null) audioClip.Play();

        if(isPowerUp == false) DestroyCollectable();
    }
}
