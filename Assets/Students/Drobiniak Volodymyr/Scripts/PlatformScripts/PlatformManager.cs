using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Students.Drobiniak_Volodymyr.Scripts.PlatformScripts
{
    public class PlatformManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> platformPrefabs;
        private List<GameObject> _spawnedPlatforms = new List<GameObject>();
        private Vector3 _spawnPosition;
        private int _spawnYInterval = 2;
        private readonly int _numberOfPlatforms = 20;    
        private readonly int _spawnPositionX = 20;
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            // Стартово додаємо 20 платформ на різних рівнях по осі Y
            for (int i = 0; i < _numberOfPlatforms; i++)
            {
                CreatePlatform();
            }
        }

        private void Update()
        {
            PlatformGeneration();
        }

        /// <summary>
        /// Generates platforms depending on the number on the stage
        /// </summary>
        private void PlatformGeneration()
        {
            if (_spawnedPlatforms.Count < _numberOfPlatforms)
            {
                for (int i = 0; i < _numberOfPlatforms; i++)
                {
                    CreatePlatform();
                }
            }
            else
            {
                DeletePlatform();
            }
        }

        private void CreatePlatform()
        {
            // Обираємо випадкову платформу зі списку префабів
            GameObject platformFromPrefabs = platformPrefabs[Random.Range(0, platformPrefabs.Count)];
        
            // Створюємо платформу у випадковому положенні по осі Х та стартової У. Наприклад, платформа
            // може з'явитися випадково від -20 до 20 по осі Х.
            int randomX = Random.Range(-_spawnPositionX, _spawnPositionX); 
            
            // Створюю координати випадкових позицій з кроком по осі Y
            Vector3 spawnPosition = new Vector3(randomX,this._spawnPosition.y + _spawnYInterval, 0f);
            
            //Інстанціюю платформу та додаю її до списку 
            GameObject newPlatform =  Instantiate(platformFromPrefabs, spawnPosition, Quaternion.identity);
            _spawnedPlatforms.Add(newPlatform);
            _spawnYInterval += 2;
        }

        private void DeletePlatform()
        {
         // Перевіряємо відстань між гравцем і найнижчою платформою
         GameObject lowestPlatform = _spawnedPlatforms[0];
         float distanceToLowestPlatform = _player.transform.position.y - lowestPlatform.transform.position.y;
         float platformRemovalDistance = 30f;
                // Якщо відстань більша ніж 30 одиниць по осі У, видаляємо платформи внизу
                if (distanceToLowestPlatform > platformRemovalDistance)
                {
                    Destroy(lowestPlatform);
                    _spawnedPlatforms.RemoveAt(0);
                }       
        }
    }
}

