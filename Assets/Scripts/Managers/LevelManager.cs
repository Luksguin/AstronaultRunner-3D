using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;

    public List<PieceManager> pieces;
    public int amountPieces;

    private List<PieceManager> _spawnedPieces;
    
    public Transform container;
    public float timeBetweenPieces;

    private GameObject _currentLevel;
    private int _index;

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

    public void SpawnPiece()
    {
        var piece = pieces[Random.Range(0, pieces.Count)];
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

        for (int i = 0; i < amountPieces; i++)
        {
            SpawnPiece();
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
