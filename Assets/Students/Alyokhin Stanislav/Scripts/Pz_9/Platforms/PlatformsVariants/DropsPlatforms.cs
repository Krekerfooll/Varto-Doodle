using Alokhin.Stanislav.PlatformGround;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alokhin.Stanislav.DropPlat
{
    public class DropsPlatforms : Platforms
    {
        [SerializeField] private float _ffallPlatf = 1f;
        [SerializeField] private float _destroyPlatf = 2f;
        [Space]
        [SerializeField] private Rigidbody2D _rb;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ( collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Fall());
            }
        }

        private IEnumerator Fall()
        {
            yield return new WaitForSeconds(_ffallPlatf);
            _rb.bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject,_destroyPlatf);
        }
    }
}

