using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _damage;

    protected int _currentHealth;

    protected virtual void Start()
    {
        _currentHealth = _health;
    }

    protected abstract void TakeDamage(int damage);
    protected abstract void Attack();
}
