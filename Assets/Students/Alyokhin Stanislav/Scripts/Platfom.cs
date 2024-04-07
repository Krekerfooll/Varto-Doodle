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
            objectRender = GetComponent<Renderer>();
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("hi nub");

            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("hello world");
                Color randomColor = Random.ColorHSV();
                objectRender.material.color = randomColor;
            }

        }
    }
}

