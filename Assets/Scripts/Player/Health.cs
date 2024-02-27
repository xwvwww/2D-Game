using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;
    private event UnityAction<int> _onChangeHealth;

    public int HP => _health;

    public event UnityAction<int> OnHealthChange
    {
        add { _onChangeHealth += value; }
        remove { _onChangeHealth -= value; }
    }

    public void Damage(int dmg)
    {
        _currentHealth -= dmg;
        _onChangeHealth.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
