using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{

    [SerializeField] private List<ColorInfo> spriteColors = new List<ColorInfo>();
    private bool colorChangerActive = true;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && colorChangerActive) 
        {
            foreach (ColorInfo sr in spriteColors)
            {
                sr.SpriteRenderer.color = sr.activeColor;
                colorChangerActive = false;
            }
            
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && colorChangerActive == false) 
        {
            foreach (ColorInfo sr in spriteColors)
            {
                sr.SpriteRenderer.color = sr.startColor;
                colorChangerActive = true;
            }
            
        }
    }
    
}


[System.Serializable]
public struct ColorInfo 
{
    public SpriteRenderer SpriteRenderer;
    public Color startColor;
    public Color activeColor;
    
}
