using Alokhin.Stanislav.CloudMoves;
using UnityEngine;

namespace Alokhin.Stanislav.CloudSpawn
{
    public class CloudSpawn : MonoBehaviour
    {
        [SerializeField] GameObject[] clouds;

        [SerializeField] float intervalSpawn;

        Vector3 startPos;

        void Start ()
        {
            startPos = transform.position;

            Invoke("AttemptSpawn", intervalSpawn);
        }
        void SpawnCloud()
        {
            int randomIndex = Random.Range(0,clouds.Length);
            GameObject cloud = Instantiate( clouds [randomIndex]);

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
