using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tank, IShootable
{
    [Header("Стрельба")]
    [SerializeField] private string _projectileTag;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] protected float _reloadTime = 0.5f;

    protected float _timer;
    private ObjectPooler _objectPooler;

    protected override void Start()
    {
        base.Start();
        _objectPooler = ObjectPooler.Instance;
    }
   
    public void Shoot()
    {
        _objectPooler.SpawnFromPool(_projectileTag, _shootPoint.position, transform.rotation);
        _timer = _reloadTime;
    }
}