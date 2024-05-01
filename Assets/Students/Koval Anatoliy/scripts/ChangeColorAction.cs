using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorAction : MonoBehaviour
{
    [System.Serializable]
public struct ChangeColorPair
{
public SpriteRenderer _renderer;
public Color _color;

public void ChangeColor()
{
_renderer.color = _color;
}
}
}
