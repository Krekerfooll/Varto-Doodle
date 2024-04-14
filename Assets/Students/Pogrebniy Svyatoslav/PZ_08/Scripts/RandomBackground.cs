using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackground : MonoBehaviour
{
    [SerializeField] public Camera myCamera;


    public void ChangeColor()
    {
    myCamera.backgroundColor = Random.ColorHSV(0f, 1f, 0.25f, 0.25f, 0.9f, 0.9f);  
    }
}
