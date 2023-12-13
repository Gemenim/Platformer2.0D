using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] private float _damage = 5;

    private void Update()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _health -= player.Damage;
            player.GetDamage(_damage);
        }
    }
}
