using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlatformChangeColor : MonoBehaviour
{
    private Renderer _platformRenderer;
    private Color _baseColor = Color.green; 
    
    private void Start()
    {
        _platformRenderer = GetComponent<Renderer>();
        _platformRenderer.material.color = _baseColor;        
        }


    /// <summary>
    /// Color change to random when in contact with another object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
        {
        _platformRenderer.material.color = Random.ColorHSV();  
        }

    void OnCollisionExit2D(Collision2D collision)
        {
        _platformRenderer.material.color = _baseColor;
        }
}
