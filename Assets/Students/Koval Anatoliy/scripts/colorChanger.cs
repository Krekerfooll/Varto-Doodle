using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spRender0;
    [SerializeField] private SpriteRenderer spRender1;
    [SerializeField] private SpriteRenderer spRender2;
    [SerializeField] private SpriteRenderer spRender3;
    private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    private bool colorChangerActive = true;

    void Start()
    {
        spriteRenderers.Add(spRender0);
        spriteRenderers.Add(spRender1);
        spriteRenderers.Add(spRender2);
        spriteRenderers.Add(spRender3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && colorChangerActive) 
        {
            foreach (SpriteRenderer sr in spriteRenderers)
            {
                Color currentColor = sr.color;
                Color newColor = new Color(currentColor.r + 0.4f, currentColor.g + 0.4f, currentColor.b + 0.4f, currentColor.a);
                sr.color = newColor;
                colorChangerActive = false;
            }
            
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && colorChangerActive == false) 
        {
            foreach (SpriteRenderer sr in spriteRenderers)
            {
                Color currentColor = sr.color;
                Color newColor = new Color(currentColor.r - 0.4f, currentColor.g - 0.4f, currentColor.b - 0.4f, currentColor.a);
                sr.color = newColor;
                colorChangerActive = true;
            }
            
        }
    }
}
