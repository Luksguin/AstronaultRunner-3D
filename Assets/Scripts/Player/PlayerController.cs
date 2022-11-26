using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ebac.Core.Singleton;

public class PlayerController : Singleton<PlayerController>
{
    [Header("PowerUp")]
    public MeshRenderer playerRenderer;

    public float playerVelocity;
    public float currentVelocity;

    public bool invencible = false;

    [Header("Menus")]
    public GameObject restartMenu;
    public GameObject winMenu;

    [Header("Tags")]
    public string enemyTag;
    public string playerTag;
    public string finishLineTag;

    [Header("Lerp")]
    public Transform lerper;
    public float lerpTime;

    [Header("Animation")]
    public float distanceMoveBack;
    public float timeMoveBack;

    [Header("Bools")]
    public bool _inGame = false;
    public bool _canCreateLevel = true;

    #region PRIVATES VARIABLES
    private Vector3 _pos;
    private float _baseSpeed;
    #endregion

    new private void Awake()
    {
        base.Awake();
        currentVelocity = playerVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == enemyTag && invencible == false)
        {
            MoveBack();
            LoseGame();
        }

        if (collision.transform.tag == finishLineTag)
        {
            WinGame();
        }
    }

    public void MoveBack()
    {
        transform.DOMoveZ(- distanceMoveBack, timeMoveBack).SetRelative();
    }

    public void WinGame()
    {
        _canCreateLevel = false;
        _inGame = false;
        AnimationManager.instance.Play(AnimationManager.AnimationsType.IDLE, currentVelocity / _baseSpeed);
        if (winMenu != null) winMenu.SetActive(true);
    }

    public void LoseGame()
    {
        _canCreateLevel = false;
        _inGame = false;
        AnimationManager.instance.Play(AnimationManager.AnimationsType.DEATH, _baseSpeed);
        if (restartMenu != null) restartMenu.SetActive(true);
    }

    void Update()
    {
        _baseSpeed = playerVelocity;

        if (_inGame != true) return;

        _canCreateLevel = false;
        _pos = lerper.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpTime * Time.deltaTime);
        transform.Translate(transform.forward * currentVelocity * Time.deltaTime);

        AnimationManager.instance.Play(AnimationManager.AnimationsType.RUN, currentVelocity / _baseSpeed);
    }
}
