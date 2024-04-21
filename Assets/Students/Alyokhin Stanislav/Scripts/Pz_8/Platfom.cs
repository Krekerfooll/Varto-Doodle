using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alokhin.Stanislav.PlatformGround
{
    public class Platforms : MonoBehaviour
    {
        [SerializeField] Renderer objectRender;

        void Start()
        {
            objectRender = GetComponentInChildren<Renderer>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {

            if (other.gameObject.CompareTag("Player"))
            {
                Color randomColor = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                objectRender.material.color = randomColor;
            }

        }
    }
}

