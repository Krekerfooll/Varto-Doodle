using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlatformManager : MonoBehaviour
{
    [SerializeField] Renderer platformRenderer;
    [SerializeField] Color baseColor = Color.white; 
    private void Start()
        {        
        platformRenderer.material.color = baseColor;        
        }


    /// <summary>
    /// Color change to random when in contact with another object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
        {
        Color randomColor = Random.ColorHSV(); 
        platformRenderer.material.color = randomColor;        
        }

    void OnCollisionExit2D(Collision2D collision)
        {
        platformRenderer.material.color = baseColor;
        }
}
