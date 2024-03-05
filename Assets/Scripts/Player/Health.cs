using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;
    private event UnityAction<int> _onChangeHealth;
    private event UnityAction _onDeath;

    public int HP => _health;

    public event UnityAction<int> OnHealthChange
    {
        add { _onChangeHealth += value; }
        remove { _onChangeHealth -= value; }
    }

    public event UnityAction OnDeath
    {
        add { _onDeath += value; }
        remove { _onDeath -= value; }
    }

    private void Start()
    {
        _currentHealth = _health;
    }

    public void Damage(int dmg)
    {
        _currentHealth -= dmg;
        _onChangeHealth.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            _onDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    public void AddHealth(int dmg)
    {
        _currentHealth += dmg;

        if (_currentHealth >= _health)
            _currentHealth = _health;

        _onChangeHealth?.Invoke(_currentHealth);
    }
}
