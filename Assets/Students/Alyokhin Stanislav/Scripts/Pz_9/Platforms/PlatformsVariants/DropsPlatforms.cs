using Alokhin.Stanislav.PlatformGround;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alokhin.Stanislav.PlatformGenerator
{
    public class DropsPlatforms : Platforms
    {
        [SerializeField] private Rigidbody2D _rb;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ( collision.gameObject.CompareTag("Player"))
            {
                Invoke("DropPlatform", 0.5f);
                Destroy(gameObject, 2f);
            }
        }

        private void DropPlatform()
        {
            _rb.isKinematic = false;
        }
    }
}

