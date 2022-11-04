using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class AnimationManager : Singleton<AnimationManager>
{
    public Animator animator;
    public List<AnimationSetup> animationSetup;

    private AnimationsType _currentAnimationType;

    public enum AnimationsType
    {
        IDLE,
        RUN,
        DEATH
    }

    public void Play(AnimationsType type, float currentSpeed = 1f)
    {
        if (_currentAnimationType == type) return;

        foreach(var animation in animationSetup)
        {
            if(animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeed;
                _currentAnimationType = type;
                break;
            }
        }
    }
}

[System.Serializable]
public class AnimationSetup
{
    public AnimationManager.AnimationsType type;
    public float speed;
    public string trigger;
}