using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int _index;

    [Header("Levels")]
    public List<GameObject> levels;

    private GameObject _currentLevel;

    [Header("Pieces")]
    public Transform container;

    public List<LevelSetup> pieceSetup;

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
        StartCoroutine(SpawnPiecesCoroutine());
        ColorManager.instance.GetColorByType(_currentSetup.artType);
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

        //ColorManager.instance.GetColorByType(_currentSetup.artType);
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
