using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(DestroyDelay());
    }

    private void Update()
    {
        _rb.velocity = transform.right * -_speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health h = collision.gameObject.GetComponent<Health>();
            if (h != null)
            {
                h.Damage(25);
                Destroy(gameObject);
            }
        }

        Destroy(gameObject);
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
