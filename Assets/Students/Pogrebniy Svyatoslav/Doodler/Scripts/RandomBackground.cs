using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackground : MonoBehaviour
{
    [SerializeField] public Camera myCamera;
    [SerializeField] private float _saturation;
    [SerializeField] private float _value;

    public void ChangeColor()
    {
    myCamera.backgroundColor = Random.ColorHSV(0f, 1f, _saturation, _saturation, _value, _value);  
    }
}
