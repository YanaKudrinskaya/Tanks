using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : ShootableTank
{

    //private float _timer;
    protected override void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody.velocity = direction.normalized * _movementSpeed;
    }

    private void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (_timer <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                //_timer = _reloadTime;
            }
                
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
