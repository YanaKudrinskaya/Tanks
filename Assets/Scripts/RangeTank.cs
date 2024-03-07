using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTank : ShootableTank
{
    [SerializeField] private float _distanceToPlayer = 5f;
    private Transform _target;

    protected override void Start()
    {
        base.Start();
        _target = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, _target.position) > _distanceToPlayer)
            Move();
        SetAngle(_target.position);
        if (_timer <= 0)
        {
            Shoot();

        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
