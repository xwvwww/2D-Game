using System.Collections;
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
            _animator.SetBool("IsWalking", true);
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
            _animator.SetBool("IsWalking", true);
            transform.localScale = new Vector3(1, 1, 1);
            transform.position = Vector3.MoveTowards(transform.position,
                                                     _leftPoint.position,
                                                     _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _leftPoint.position) < 0.4f)
            {
                StartCoroutine(DelayMove());
                _isRight = false;
            }
        }
    }


    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPoint.position, 0.3f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "Player")
            {
                Health h = collider.gameObject.GetComponent<Health>();
                if (h != null)
                {
                    h.Damage(25);
                }
            }
        }
    }

    private IEnumerator DelayMove()
    {
        _canMove = false;
        _animator.SetBool("IsWalking", false);
        yield return new WaitForSeconds(2f);
        _canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger("IsAttack");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger("IsAttack");
        }
    }
}
