using System.Collections;
using UnityEngine;

namespace RPG.Combat
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] GameObject enemyPrefab;
        [SerializeField] int minEnemyiesSpawn = 3;
        [SerializeField] int maxEnemiesSpawn = 6;
        [SerializeField] float minSpawnInterval = 6f;
        [SerializeField] float maxSpawnInterval = 30f;
        [SerializeField] float spawnRadius = 2f;

        void Start()
        {
            SpawnFirstGroup();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                StartCoroutine(SpawnEnemies());
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                StopAllCoroutines();
            }
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(interval);

                int enemiesBatchSize = Random.Range(minEnemyiesSpawn, maxEnemiesSpawn);
                for (int i = 0; i < enemiesBatchSize; i++)
                {
                    Vector2 spawnOffset = Random.insideUnitCircle * spawnRadius;
                    Vector2 spawnPosition = (Vector2)gameObject.transform.position + spawnOffset;

                    Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                }

            }
        }

        private void SpawnFirstGroup()
        {
            int enemiesBatchSize = Random.Range(minEnemyiesSpawn, maxEnemiesSpawn);
            for (int i = 0; i < enemiesBatchSize; i++)
            {
                Vector2 spawnOffset = Random.insideUnitCircle * spawnRadius;
                Vector2 spawnPosition = (Vector2)gameObject.transform.position + spawnOffset;

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}

