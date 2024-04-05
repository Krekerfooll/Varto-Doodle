using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Renderer objectRenderer;    
    private void Start()
        {
        objectRenderer = GetComponent<Renderer>();
        }


        /// <summary>
        /// Color change to random when in contact with another object
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
        Color randomColor = Random.ColorHSV(); 
        objectRenderer.material.color = randomColor;        
        }
    }
