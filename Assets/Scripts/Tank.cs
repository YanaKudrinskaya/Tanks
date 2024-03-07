using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //атрибут дл€ проверки наличи€ компонента, защита от удалени€ и автоматического добавлени€
public abstract class Tank : MonoBehaviour
{
    [Header("ќбщие характеристики")]
    [SerializeField][Tooltip("ћаксимальное здоровье")] private int _maxHealth = 30;
    [SerializeField][Range(0f, 5f)] protected float _movementSpeed = 3f;
    [SerializeField] protected float _angleOffset = 90f;
    [SerializeField] protected float _rotationSpeed = 7f;
    [Space(10)]
    [SerializeField] private int _points = 0;

    protected UI _ui;
    protected Rigidbody2D _rigidbody;
    protected int _currentHealth;


    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        _rigidbody = GetComponent<Rigidbody2D>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();

    }

    public virtual void TakeDamage (int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Stats.Score += _points;
            _ui.UpdateScoreAndLevel();
            _currentHealth = _maxHealth;
            gameObject.SetActive(false);
        }
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.down * _movementSpeed * Time.deltaTime);
    }

    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0f, 0f, angleZ + _angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * _rotationSpeed);
    }
}
