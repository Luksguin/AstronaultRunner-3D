using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Velocity")]
    public float startVelocity;
    public float currentVelocity;

    [Header("Menus")]
    public GameObject restartMenu;
    public GameObject winMenu;

    [Header("Tags")]
    public string enemyTag;
    public string finishLineTag;
    //public string powerUpTag;

    [Header("Lerp")]
    public Transform lerper;
    public float lerpTime;

    #region PRIVATES VARIABLES
    private Vector3 _pos;
    private bool _inGame = true;
    #endregion

    private void Awake()
    {
        currentVelocity = startVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == enemyTag)
        {
            LoseGame();
        }

        if (collision.transform.tag == finishLineTag)
        {
            WinGame();
        }

        /*if (collision.transform.tag == powerUpTag)
        {
            PowerUp();
        }*/
    }

    /*public void PowerUp()
    {
        velocity = velocity * 2;
    }*/

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
        if (_inGame != true) return;

        _pos = lerper.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpTime * Time.deltaTime);
        transform.Translate(transform.forward * currentVelocity * Time.deltaTime);
    }
}
