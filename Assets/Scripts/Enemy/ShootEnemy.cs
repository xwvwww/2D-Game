using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : Enemy
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;

    private Collider2D _trigger;
    private float _shootTime;
    private int _playerLayer;

    private void Awake()
    {
        _trigger = GetComponentInChildren<Collider2D>();
        
    }

    protected override void Start()
    {
        base.Start();
        _playerLayer = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        if (_trigger.IsTouchingLayers(_playerLayer))
        {
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        }
    }
}
