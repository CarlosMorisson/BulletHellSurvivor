using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnarInimigos : MonoBehaviour
{

        public GameObject enemy;
        public float spawnRate;
        private float nextSpawn = 0f;
        void Update()
        {
            Spawner();
            if (spawnRate <= 0)
            {
                spawnRate += 0.2f;

            }

        }
        public void Spawner()
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                Instantiate(enemy, transform.position, enemy.transform.rotation);
            }
        }
    
}
