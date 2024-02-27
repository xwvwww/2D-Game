using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _climbingSpeed;

    private Rigidbody2D _rb;
    private Animator _animator;
    private Collider2D _collider;

    private float _inputX;
    private int _groundLayer;
    private int _ladderMask;
    private float _startGravityScale;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _groundLayer = LayerMask.GetMask("Ground");
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _ladderMask = LayerMask.GetMask("Ladder");
        _startGravityScale = _rb.gravityScale;
    }

    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");

        Move();
        Climbing();
        Jump();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_inputX * _speed, _rb.velocity.y); 

        if (_inputX != 0)
            transform.localScale = new Vector3(Mathf.Sign(_inputX), 1, 1);

        _animator.SetFloat("Speed", Mathf.Abs(_rb.velocity.x));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround(new Vector2(transform.position.x, transform.position.y - 0.5f), 0.2f))
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Climbing()
    {
        if (!_collider.IsTouchingLayers(_ladderMask))
        {
            _animator.SetBool("StartClimb", false);
            _rb.gravityScale = _startGravityScale;
            return;
        }

        _animator.SetBool("StartClimb", true);
        _rb.gravityScale = 0f;

        if (!CheckGround(transform.position, 0.2f, _ladderMask))
            return;

        _rb.gravityScale = 0f;
        float y = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector2(_rb.velocity.x, y * _climbingSpeed);

        _animator.SetFloat("Climbing", Mathf.Abs(y));

    }

    private bool CheckGround(Vector2 position, float radius, int layer = 1)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius, layer);

        return colliders.Length > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, 0), 0.2f);
    }
}
