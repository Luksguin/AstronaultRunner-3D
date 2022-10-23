using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
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
    public bool _inGame = false;

    #region PRIVATES VARIABLES
    private Vector3 _pos;
    private float _baseSpeed;
    #endregion

    private void Awake()
    {
        currentVelocity = playerVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == enemyTag && invencible == false)
        {
            MoveBack();
            LoseGame();
            AnimationManager.instance.Play(AnimationManager.AnimationsType.DEATH, _baseSpeed);
        }

        if (collision.transform.tag == finishLineTag)
        {
            WinGame();
            AnimationManager.instance.Play(AnimationManager.AnimationsType.IDLE, _baseSpeed);
        }
    }

    public void MoveBack()
    {
        transform.DOMoveZ(- distanceMoveBack, timeMoveBack).SetRelative();
    }

    public void WinGame()
    {
        _inGame = false;
        if (winMenu != null) winMenu.SetActive(true);
    }

    public void LoseGame()
    {
        _inGame = false;
        if (restartMenu != null) restartMenu.SetActive(true);
    }

    void Update()
    {
        _baseSpeed = playerVelocity;

        if (_inGame != true) return;

        _pos = lerper.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpTime * Time.deltaTime);
        transform.Translate(transform.forward * currentVelocity * Time.deltaTime);

        AnimationManager.instance.Play(AnimationManager.AnimationsType.RUN, currentVelocity / _baseSpeed);
    }
}
