using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tank, IShootable
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] protected float _reloadTime = 0.5f;
    [SerializeField] private Transform _projectilies;
    protected float _timer;
    public bool Player { get; protected set; } = false;

    public void Shoot()
    {
        if (Player)
            Instantiate(_projectile, _shootPoint.position, transform.rotation, _projectilies.transform);
        else
            Instantiate(_projectile, _shootPoint.position, transform.rotation);
        _timer = _reloadTime;
    }
}