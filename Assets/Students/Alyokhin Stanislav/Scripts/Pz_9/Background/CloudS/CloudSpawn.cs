using Alokhin.Stanislav.CloudMoves;
using UnityEngine;

namespace Alokhin.Stanislav.CloudSpawn
{
    public class CloudSpawn : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] GameObject[] clouds;
        [SerializeField] float intervalSpawn;

        private Vector3 startPos;
        private float timeSinceLastSpawn;
        void Start ()
        {
            startPos = transform.position - _target.position;
            timeSinceLastSpawn = intervalSpawn;

        }
        void Update()
        {
            timeSinceLastSpawn += Time.deltaTime; 

            if (timeSinceLastSpawn >= intervalSpawn)
            {
                timeSinceLastSpawn = 0f; 
                SpawnCloud();
            }
        }
        //  void LateUpdate ()
        //  {
        //      Invoke("AttemptSpawn", intervalSpawn);
        //  }
        void SpawnCloud()
        {
            int randomIndex = Random.Range(0,clouds.Length);
            GameObject cloud = Instantiate( clouds [randomIndex]);

            Vector3 spawnPos = startPos;
            startPos.y = Random.Range(startPos.y -1f,startPos.y+1f);
            spawnPos.x = _target.position.x;
            cloud.transform.position = startPos;
            float speed = Random.Range(0.5f, 1.5f);
        }
        void AttemptSpawn()
        {
            SpawnCloud();

            Invoke("AttemptSpawn", intervalSpawn);
        }
    }
 
}
