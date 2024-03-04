using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : Enemy
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;

    private Trigger _trigger;
    private Animator _animator;
    private float _shootTime;
    private int _playerLayer;

    private void Awake()
    {
        _trigger = GetComponentInChildren<Trigger>();
        _animator = GetComponent<Animator>();

    }

    protected override void Start()
    {
        base.Start();
        _playerLayer = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        if (_trigger.IsTarget)
        {
            if (Time.time - _shootTime < _shootDelay)
            {
                return;
            }
            _shootTime = Time.time;
            _animator.SetTrigger("Shoot");
            Shoot();
        }

        
    }

    public void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, transform.localRotation);
    }
}
