using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _protectCoin = 3f;

    private Health _health;
    private Wallet _wallet;

    public Action HitEnemy;
    public Action Treatment;

    public float Damage => _damage;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
    }

    public void GetDamage(float damage)
    {
        if (_wallet.Coins.Count > 0)
        {
            _wallet.DropCoin();
            damage -= _protectCoin;
            _health.TakeDamage(damage);
        }
        else
        {
            _health.TakeDamage(damage);
        }
    }

    public void GetTreatment(float treatment)
    {
        if (_health.HealthPoint < _health.MaxHealth)
            _health.TakeTreatment(treatment);
    }
}
