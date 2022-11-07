using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Levels")]
    public List<GameObject> levels;

    private int _index;
    private GameObject _currentLevel;

    [Header("Pieces")]
    public int amountStartPieces;
    public int amountPieces;
    public int amountEndPieces;

    public float timeBetweenPieces;
    public Transform container;

    public List<PieceManager> startPieces;
    public List<PieceManager> pieces;
    public List<PieceManager> endPieces;

    private List<PieceManager> _spawnedPieces;

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

        for (int i = 0; i < amountStartPieces; i++)
        {
            CreatePieces(startPieces);
            yield return new WaitForSeconds(timeBetweenPieces);
        }

        for (int i = 0; i < amountPieces; i++)
        {
            CreatePieces(pieces);
            yield return new WaitForSeconds(timeBetweenPieces);
        }

        for (int i = 0; i < amountEndPieces; i++)
        {
            CreatePieces(endPieces);
            yield return new WaitForSeconds(timeBetweenPieces);
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
