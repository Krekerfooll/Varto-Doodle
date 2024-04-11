using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Students.Drobiniak_Volodymyr.Scripts.PlatformScripts
{
    public class PlatformGenerator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> platformPrefabs;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private int spawnYInterval = 2;

        private const int SpawnPositionX = 20;


        private void Update()
        {
            if (Input.GetKeyDown( KeyCode.F))
            {
                for (int i = 0; i < 10; i++)
                {
                    SpawnPlatform();
                }
            }
        }

        internal void SpawnPlatform()
        {
            // Обираємо випадкову платформу зі списку префабів
            GameObject platformFromPrefabs = platformPrefabs[Random.Range(0, platformPrefabs.Count)];
        
            // Створюємо платформу у випадковому положенні по осі Х та стартової У. Наприклад, платформа може з'явитися випадково від -20 до 20 по ос
            int randomX = Random.Range(-SpawnPositionX, SpawnPositionX); 
            
            Vector3 spawnPosition = new Vector3(randomX,this.spawnPosition.y + spawnYInterval, 0f);
            
                Instantiate(platformFromPrefabs, spawnPosition, Quaternion.identity);
                spawnYInterval += 2;
        }
        }
    }

