using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tank
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] protected float _reloadTime = 0.5f;
    protected float _timer;
    protected void Shoot()
    {
        Instantiate(_projectile, _shootPoint.position, transform.rotation);
        _timer = _reloadTime;
    }
}
