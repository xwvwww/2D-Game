using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    private int _restoreHP;

    private void Start()
    {
        _restoreHP = Random.Range(10, 40);
    }

    public override void Use()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health hp = collision.gameObject.GetComponent<Health>();

        if (hp != null )
        {
            hp.AddHealth(_restoreHP);
            Destroy(gameObject);
        }
    }


}
