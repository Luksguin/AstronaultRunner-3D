using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    public float playerSize;
    public float spawnTime;
    public Ease ease;

    private void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        player.transform.DOScale(playerSize, spawnTime).SetEase(ease);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Spawn();
        }
    }
}
