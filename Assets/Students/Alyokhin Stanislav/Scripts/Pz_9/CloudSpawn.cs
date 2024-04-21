using UnityEngine;

namespace Alokhin.Stanislav.CloudSpawn
{
    public class CloudSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _cloudOne;
        [SerializeField] private GameObject _cloudTwo;
        [SerializeField] private GameObject _cloudThree;
        //[SerializeField] float _speed;
        //[SerializeField] Vector2 _resetPosition;
        private void Start()
        {
            float randomX = Random.Range(-10f, 10f);
            int randomY = Random.Range(5, 20);

            Vector2 spawnPosition = new Vector2(randomX, randomY);

            Instantiate(_cloudThree, spawnPosition, Quaternion.identity);
            Instantiate(_cloudTwo, spawnPosition, Quaternion.identity);
            Instantiate(_cloudOne, spawnPosition, Quaternion.identity);
        }
        void Update()
        {
            // transform.Translate(Vector2.right * _speed * Time.deltaTime);
            //  if (transform.position.x > _resetPosition.x)
            //  {
            //      transform.position = new Vector3(_resetPosition.x, _resetPosition.y);
            //  }
        }
    }
}
