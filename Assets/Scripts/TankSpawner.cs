using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private List<string> _tags;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float spawnTime = 4f;

    private ObjectPooler _objectPooler;
    private void Start()
    {
        _objectPooler = ObjectPooler.Instance;
        StartCoroutine(SpawnTank());
    }

    IEnumerator SpawnTank()
    {
        while (true)
        {
            int limit;
            
            if (Stats.Level < _tags.Count)
                limit = Stats.Level;
            else 
                limit = _tags.Count;
            _objectPooler.SpawnFromPool(_tags[Random.Range(0, limit)], _spawnPoints[Random.Range(0, _spawnPoints.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
