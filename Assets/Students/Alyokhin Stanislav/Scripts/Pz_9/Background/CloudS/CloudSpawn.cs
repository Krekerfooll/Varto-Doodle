using Alokhin.Stanislav.CloudMoves;
using UnityEngine;

namespace Alokhin.Stanislav.CloudSpawn
{
    public class CloudSpawn : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] GameObject[] clouds;
        [SerializeField] float intervalSpawn;
        [SerializeField] float horizontalRange;
        [SerializeField] float verticalRange;

        [SerializeField] float nextSpawnY;

       // private Vector3 startPos;
       // private float timeSinceLastSpawn;
        void Start ()
        {
            nextSpawnY = _target.position.y + verticalRange;
            SpawnCloud();
            // startPos = transform.position - _target.position;
            // timeSinceLastSpawn = intervalSpawn;

        }
        void Update()
        {
            if (_target.position.y + verticalRange > nextSpawnY)
            {
                nextSpawnY += intervalSpawn;
                SpawnCloud();
            }

          //  timeSinceLastSpawn += Time.deltaTime; 
          //
          //  if (timeSinceLastSpawn >= intervalSpawn)
          //  {
          //      timeSinceLastSpawn = 0f; 
          //      SpawnCloud();
          //  }
          //  FollowPlayer();
        }
        //  void LateUpdate ()
        //  {
        //      Invoke("AttemptSpawn", intervalSpawn);
        //  }
        void SpawnCloud()
        {
            float randomX = Random.Range(-horizontalRange, horizontalRange);
            Vector3 spawnPosition = new Vector3(randomX, nextSpawnY, 0.0f);

            // Вибір випадкової хмарки з масиву
            GameObject cloudPrefab = clouds[Random.Range(0, clouds.Length)];
            Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
            //  int randomIndex = Random.Range(0,clouds.Length);
            //  GameObject cloud = Instantiate( clouds [randomIndex]);
            //
            //  Vector3 spawnPos = startPos;
            //  startPos.y = Random.Range(startPos.y -1f,startPos.y+1f);
            //  spawnPos.x = transform.position.x;
            //  cloud.transform.position = startPos;
            //  float speed = Random.Range(0.5f, 1.5f);
        }
      //  void AttemptSpawn()
      //  {
      //      SpawnCloud();
      //
      //      Invoke("AttemptSpawn", intervalSpawn);
      //  }
      //
      //  void FollowPlayer()
      //  {
      //      startPos = transform.position - _target.position;
      //      //transform.position = new Vector3(_target.position.x + startPos.x, transform.position.y,transform.position.z);
      //  }
    }
 
}
