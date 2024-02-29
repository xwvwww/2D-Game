using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : Enemy
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;

    private Trigger _trigger;
    private float _shootTime;
    private int _playerLayer;

    private void Awake()
    {
        _trigger = GetComponentInChildren<Trigger>();
        
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
            Instantiate(_bullet, _shootPoint.position, transform.localRotation);
        }
    }
}
