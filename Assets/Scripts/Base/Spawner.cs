using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Base
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _spawnItem;
        [SerializeField] private float _spawnRate;
        [SerializeField] private float _spawnRange;

        private float timer;
        private bool IsOver = false;

        private void Start()
        {
            SpawnObject();
        }

        private void Update()
        {
            if (IsOver)
            {
                return;
            }
            if (timer < _spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnObject();
                timer = 0;
            }
        }

        public void SpawnObject()
        {
            float leftPoint = transform.position.x - _spawnRange;
            float rightPoint = transform.position.x + _spawnRange;
            Vector3 spawnPosition = new Vector3(Random.Range(leftPoint, rightPoint), transform.position.y, transform.position.z);

            Instantiate(_spawnItem, spawnPosition, transform.rotation);
        }
        public void StopSpawn()
        {
            IsOver = true;
        }
    }

   
}