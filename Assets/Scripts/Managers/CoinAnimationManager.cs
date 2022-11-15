using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class CoinAnimationManager : Singleton<CoinAnimationManager>
{
    public List<CoinBase> coins;

    public float sizePiece;
    public float spawnTime;
    public float timeBetweenCoins;
    public Ease ease;

    private void Start()
    {
        coins = new List<CoinBase>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartAnimation();
        }
    }

    public void RegisterCoin(CoinBase c)
    {
        if (!coins.Contains(c))
        {
            coins.Add(c);
            c.transform.localScale = Vector3.zero;
        }
    }

    public void StartAnimation()
    {
        CleanCoins();
        StartCoroutine(ScaleCoinsCoroutine());
    }

    IEnumerator ScaleCoinsCoroutine()
    {
        foreach (var c in coins)
        {
            c.transform.localScale = Vector3.zero;
        }

        yield return null;

        for (int i = 0; i < coins.Count; i++)
        {
            coins[i].transform.DOScale(sizePiece, spawnTime).SetEase(ease);
            yield return new WaitForSeconds(timeBetweenCoins);
        }
    }

    public void CleanCoins()
    {
        for (int i = coins.Count - 1; i >= 0; i--)
        {
            Destroy(coins[i].gameObject);
        }

        coins.Clear();
    }
}
