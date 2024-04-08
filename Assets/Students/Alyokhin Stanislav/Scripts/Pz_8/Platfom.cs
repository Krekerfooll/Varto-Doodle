using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alokhin.Stanislav.Platform
{
    public class Platfom : MonoBehaviour
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
                //Color randomColor = Random.Color();
                //objectRender.material.color = randomColor;
            }

        }
    }
}

