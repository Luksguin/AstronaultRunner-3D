using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    private int _index;

    [Header("Levels")]
    public List<GameObject> levels;

    private GameObject _currentLevel;

    [Header("Pieces")]
    public Transform container;
    public List<LevelSetup> pieceSetup;

    [Header("SpawnAnimtion")]
    public float sizePiece;
    public float spawnTime;
    public float spawnDelay;
    public Ease ease;

    private List<PieceManager> _spawnedPieces = new List<PieceManager>();
    private LevelSetup _currentSetup;

    private void Awake()
    {
        //SpawnLevel();
        //SpawnPieces();
    }

    public void SpawnLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if(_index >= levels.Count)
            {
                _index = 0;
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    public void SpawnPieces()
    {
        BuildPieces();

        //StartCoroutine(SpawnPiecesCoroutine());
    }

    public void CreatePieces(List<PieceManager> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.instance.GetSetupByType(_currentSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    public void BuildPieces()
    {
        if (_currentSetup != null)
        {
            Destroy(_currentSetup);
            _index++;

            if (_index >= pieceSetup.Count)
            {
                _index = 0;
            }
        }

        _currentSetup = pieceSetup[_index];

        for (int i = 0; i < _currentSetup.amountStartPieces; i++)
        {
            CreatePieces(_currentSetup.startPieces);
        }

        for (int i = 0; i < _currentSetup.amountPieces; i++)
        {
            CreatePieces(_currentSetup.pieces);
        }

        for (int i = 0; i < _currentSetup.amountEndPieces; i++)
        {
            CreatePieces(_currentSetup.endPieces);
        }

        ColorManager.instance.GetColorByType(_currentSetup.artType);

        StartCoroutine(ScaleSceneCoroutine());
    }

    IEnumerator SpawnPiecesCoroutine()
    {
        if (_currentSetup != null)
        {
            Destroy(_currentSetup);
            _index++;

            if (_index >= pieceSetup.Count)
            {
                _index = 0;
            }
        }

        _currentSetup = pieceSetup[_index];

        for (int i = 0; i < _currentSetup.amountStartPieces; i++)
        {
            CreatePieces(_currentSetup.startPieces);
            yield return new WaitForSeconds(_currentSetup.timeBetweenPieces);
        }

        for (int i = 0; i < _currentSetup.amountPieces; i++)
        {
            CreatePieces(_currentSetup.pieces);
            yield return new WaitForSeconds(_currentSetup.timeBetweenPieces);
        }

        for (int i = 0; i < _currentSetup.amountEndPieces; i++)
        {
            CreatePieces(_currentSetup.endPieces);
            yield return new WaitForSeconds(_currentSetup.timeBetweenPieces);
        }

        StartCoroutine(ScaleSceneCoroutine());
    }

    IEnumerator ScaleSceneCoroutine()
    {
        foreach( var p in _spawnedPieces)
        {
            p.transform.localScale = Vector3.zero;
        }

            yield return null;

        for(int i = 0; i < _spawnedPieces.Count; i++)
        {
            _spawnedPieces[i].transform.DOScale(sizePiece, spawnTime).SetEase(ease);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void CleanPieces()
    {
        for(int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CleanPieces();
            SpawnPieces();
        }
    }
}
