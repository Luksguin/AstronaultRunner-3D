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

    private List<PieceManager> _spawnedPieces;
    private LevelSetup _currSetup;

    private void Awake()
    {
        //SpawnLevel();
        SpawnPieces();
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

        _spawnedPieces.Add(spawnedPiece);
    }

    IEnumerator SpawnPiecesCoroutine()
    {
        _spawnedPieces = new List<PieceManager>();

        if (_currSetup != null)
        {
            Destroy(_currSetup);
            _index++;

            if (_index >= pieceSetup.Count)
            {
                _index = 0;
            }
        }

        _currSetup = pieceSetup[_index];

        for (int i = 0; i < _currSetup.amountStartPieces; i++)
        {
            CreatePieces(_currSetup.startPieces);
            yield return new WaitForSeconds(_currSetup.timeBetweenPieces);
        }

        for (int i = 0; i < _currSetup.amountPieces; i++)
        {
            CreatePieces(_currSetup.pieces);
            yield return new WaitForSeconds(_currSetup.timeBetweenPieces);
        }

        for (int i = 0; i < _currSetup.amountEndPieces; i++)
        {
            CreatePieces(_currSetup.endPieces);
            yield return new WaitForSeconds(_currSetup.timeBetweenPieces);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnLevel();
        }
    }
}
