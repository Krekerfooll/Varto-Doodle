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
        [SerializeField] private int _spawnPositionYInterval = 3;
        [SerializeField] private int _spawnPositionX = 8;
        private readonly int _numberOfPlatforms = 20;  
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
            Vector3 spawnPosition = new Vector3(randomX,this._spawnPosition.y + _spawnPositionYInterval, 0f);
            
            //Інстанціюю платформу та додаю її до списку 
            GameObject newPlatform =  Instantiate(platformFromPrefabs, spawnPosition, Quaternion.identity);
            _spawnedPlatforms.Add(newPlatform);
            _spawnPositionYInterval += 2;
        }
        
        private void DeletePlatform()
        {
            // Перевіряємо, чи є у списку платформи для видалення
            if (_spawnedPlatforms.Count > 0)
            {
                // Отримуємо найнижчу платформу
                var lowestPlatform = _spawnedPlatforms[0];
        
                // Перевіряємо, чи платформа існує
                if (lowestPlatform != null)
                {
                    // Перевіряємо відстань між гравцем і найнижчою платформою
                    float distanceToLowestPlatform = _player.transform.position.y - lowestPlatform.transform.position.y;
                    float platformRemovalDistance = 20f;

                    // Якщо відстань більша ніж 20 одиниць по осі Y, видаляємо платформи знизу
                    if (distanceToLowestPlatform > platformRemovalDistance)
                    {
                        _spawnedPlatforms.RemoveAt(0);
                        Destroy(lowestPlatform);
                    }
                }
                else
                {
                    // Якщо платформа була видалена і вже не існує, видаляємо її зі списку
                    _spawnedPlatforms.RemoveAt(0);
                }
            }
        }

    }
}

