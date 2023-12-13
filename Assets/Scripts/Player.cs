using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _damage = 10;

    private Wallet _wallet;
    private float _health;
    private float _protectionCoin = 3.0f;

    public float Damage => _damage;

    private void Awake()
    {
        if (_maxHealth < 50)
            _maxHealth = 50;
        if (_damage < 1)
            _damage = 1;

        _health = _maxHealth;
    }

    private void Start()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void Update()
    {
        if (_health > _maxHealth)
            _health = _maxHealth;

        if (_health <= 0)
            Destroy(gameObject);
    }

    public void GetDamage(float damage)
    {
        if (_wallet.Coins.Count > 0)
        {
            _wallet.DropCoin();
            _health -= damage - _protectionCoin;
        }
        else
            _health -= damage;
    }

    public void GetTreatment(float health)
    {
        if (_health < _maxHealth)
            _health += health;
    }
}