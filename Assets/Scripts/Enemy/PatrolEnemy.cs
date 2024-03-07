using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy
{
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _attackPoint;

    private bool _isRight;
    private bool _canMove;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void Start()
    {
        base.Start();
        _canMove = true;
    }

    private void Update()
    {

        Move();
    }

    private void Move()
    {
        if (!_isRight && _canMove)
        {
            _animator.SetTrigger("IsWalking");
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position = Vector3.MoveTowards(transform.position,
                                                     _rightPoint.position,
                                                     _speed * Time.deltaTime);


            if (Vector3.Distance(transform.position, _rightPoint.position) < 0.4f)
            {
                StartCoroutine(DelayMove());
                _isRight = true;


            }
        }
        else if (_canMove && _isRight)
        {
            _animator.SetTrigger("IsWalking");
            transform.localScale = new Vector3(1, 1, 1);
            transform.position = Vector3.MoveTowards(transform.position,
                                                     _leftPoint.position,
                                                     _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _leftPoint.position) < 0.4f)
            {
                StartCoroutine(DelayMove());
                _isRight = false;
                _animator.SetTrigger("IsWalking");
            }
        }
    }


    private void Attack()
    {
        _animator.SetTrigger("IsAttack");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPoint.position, 0.3f, 1);


        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Player")
            {
                Destroy(collider.gameObject);
            }
        }
    }

    private IEnumerator DelayMove()
    {
        _canMove = false;
        yield return new WaitForSeconds(2f);
        _canMove = true;
    }
}
