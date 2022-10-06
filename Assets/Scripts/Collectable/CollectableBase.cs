using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string playerTag;
    public ParticleSystem systemParticle;

    [Header("Animations")]
    public Animator animator;
    public string setTrigger;

    [Header("Sounds")]
    public AudioSource audioClip;

    private void Awake()
    {
        if(systemParticle != null) systemParticle.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(playerTag != null)
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        //animator.SetTrigger(setTrigger);
        Destroy(gameObject);
    }

    protected virtual void OnCollect()
    {
        if (systemParticle != null) systemParticle.Play();
        if (audioClip != null) audioClip.Play();
    }
}
