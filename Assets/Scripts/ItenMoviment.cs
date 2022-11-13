using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenMoviment : MonoBehaviour
{
    public float duration;

    public List<Transform> positions;
    private int _index = 0;

    private void Start()
    {
        StartCoroutine(StartMoviment());
        NextIndex();
    }

    public void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }

    IEnumerator StartMoviment()
    {
        float time = 0;

        while (true)
        {
            var currentPosition = transform.position;

            while(time< duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, time / duration);

                time += Time.deltaTime;

                yield return null;
            }

            NextIndex();
            time = 0;
            
            yield return null;
        }
    }
}
