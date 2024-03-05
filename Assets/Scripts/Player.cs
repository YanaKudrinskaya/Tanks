using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ShootableTank
{
    private bool _youDead = false;


    protected override void Start()
    {
        base.Start();
        Player = true;
    }

    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _ui.UpdateHp(_currentHealth);
        if( _currentHealth <= 0 )
        {
            _youDead = true;
            Stats.UploadLevel(_youDead);
        }
    }

    protected override void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody.velocity = direction.normalized * _movementSpeed;
    }

    private void Update()
    {
        if(Stats.Score < 500)
        {
            Move();
            SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (_timer <= 0)
            {
                if (Input.GetMouseButton(0))
                    Shoot();
            }
            else
                _timer -= Time.deltaTime;
        }
        else
            Victory();
        if (Debug.isDebugBuild)
            DebugKeys();
    }

    private void Victory()
    {
        //status = Status.NextLevel;
        var m_Tanks = FindObjectsOfType<Tank>();
        foreach (Tank tank in m_Tanks)
        {
            if (tank.tag != "Player")
            Destroy(tank.gameObject);
        }
        //Destroy(FindObjectOfType<TankSpawner>().gameObject);
        _ui.UpdateWin();
        Invoke("UploadLevel", 2f);
    }
    private void UploadLevel()
    {
        Stats.UploadLevel(_youDead);
    }

    private void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
            Victory();
    }
}
