using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _maxHealth = 100;

    private float _health;

    public Action AlteredHealth;

    public float MaxHealth => _maxHealth;
    public float HealthPoint => _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        AlteredHealth?.Invoke();

        if (_health <= 0)
            Destroy(this.gameObject);
    }

    public void TakeTreatment(float treatment)
    {
        if (_health < _maxHealth)
            _health += treatment;

        if (_health >= _maxHealth)
            _health = _maxHealth;

        AlteredHealth?.Invoke();
    }
}
