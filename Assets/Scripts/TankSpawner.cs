using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tanks;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float spawnTime = 4f;

    private GameObject _player;

    private void Start()
    {

            StartCoroutine(SpawnTank());
    }

    IEnumerator SpawnTank()
    {
        while (true)
        {
            int limit;
            
            if (Stats.Level < _tanks.Count)
                limit = Stats.Level;
            else 
                limit = _tanks.Count;
            Instantiate(_tanks[Random.Range(0, limit)], _spawnPoints[Random.Range(0, _spawnPoints.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
