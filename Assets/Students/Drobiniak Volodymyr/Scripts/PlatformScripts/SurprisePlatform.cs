using System.Collections;
using UnityEngine;

namespace Students.Drobiniak_Volodymyr.Scripts.PlatformScripts
{
    public class SurprisePlatform : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float platformSpeed = 2f;
        [SerializeField] private int positionRestrictionX = 20;
        [SerializeField, Range(1, 10)] private float effectDelayTime = 2f;
        [SerializeField] private float blinkInterval = 0.1f; 

        private GameObject _player;
        private bool _isPlatformMoving = true;
        private float _initialPlatformPositionX;
        private bool _isPlayerOnPlatform = false;
        private bool _isEventActive;
        private float _eventTimer;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _initialPlatformPositionX = transform.position.x;
        }

        private void FixedUpdate()
        {
            MovePlatform();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && !_isPlayerOnPlatform)
            {
                _isPlayerOnPlatform = true;
                _isPlatformMoving = false;
                StartCoroutine(PlatformDisappearCountdown());
            }
        }

        private void MovePlatform()
        {
            if (_isPlatformMoving)
            {
                float direction = (_initialPlatformPositionX < 0) ? 1f : -1f; // Визначення напрямку руху
                float newPositionX = Mathf.Clamp(transform.position.x + direction * platformSpeed * Time.fixedDeltaTime,
                    -positionRestrictionX, positionRestrictionX);
                transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

                // Зміна напрямку руху при досягненні меж
                if (newPositionX >= positionRestrictionX || newPositionX <= -positionRestrictionX)
                {
                    _initialPlatformPositionX *= -1;
                }
            }
        }
        private IEnumerator PlatformDisappearCountdown()
        {
            yield return new WaitForSeconds(effectDelayTime);
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(blinkInterval);

            // Видалення платформи
            Destroy(gameObject);
        }
    }
}
        
        
        
