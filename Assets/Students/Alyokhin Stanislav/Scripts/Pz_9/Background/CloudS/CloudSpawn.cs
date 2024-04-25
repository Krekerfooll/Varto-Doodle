using Alokhin.Stanislav.CloudMoves;
using UnityEngine;

namespace Alokhin.Stanislav.CloudSpawn
{
    public class CloudSpawn : MonoBehaviour
    {
        [SerializeField] GameObject[] clouds;
        [SerializeField] float intervalSpawn;

        private Vector3 startPos;

        void Start ()
        {
            startPos = transform.position;

            Invoke("AttemptSpawn", intervalSpawn);
        }

        void SpawnCloud()
        {
            int randomIndex = Random.Range(0,clouds.Length);
            GameObject cloud = Instantiate( clouds [randomIndex]);

            startPos.y = Random.Range(startPos.y -1f,startPos.y+1f);
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
