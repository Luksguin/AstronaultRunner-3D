using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class AnimationManager : Singleton<AnimationManager>
{
    public Animator animator;
    public List<AnimationSetup> animationSetup;

    public enum AnimationsType
    {
        IDLE,
        RUN,
        DEATH
    }

    public void Play(AnimationsType type)
    {
        foreach(var animation in animationSetup)
        {
            if(animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                break;
            }
        }
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Play(AnimationsType.IDLE);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Play(AnimationsType.RUN);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Play(AnimationsType.DEATH);
        }
    }*/
}

[System.Serializable]
public class AnimationSetup
{
    public AnimationManager.AnimationsType type;
    public string trigger;
}