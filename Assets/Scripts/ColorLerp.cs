using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColorLerp : MonoBehaviour
{
    private float duration = 1.2f;
    public Color startColor = Color.white;
    public MeshRenderer meshRenderer;

    private Color _newColor;

    private void OnValidate()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _newColor = meshRenderer.materials[0].GetColor("_Color");
        LerpColor();
    }

    public void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_Color", startColor);
        meshRenderer.materials[0].DOColor(_newColor, duration).SetDelay(.6f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            LerpColor();
        }
    }
}
