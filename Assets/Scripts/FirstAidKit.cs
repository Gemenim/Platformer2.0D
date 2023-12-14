using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float _minHealth = 1.0f;
    [SerializeField] private float _maxHealth = 10.0f;

    private FirstAidKitGenerator _generator;
    private float _health;

    public float MaxHealth => _maxHealth;

    private void OnValidate()
    {
        if (_minHealth < 1)
            _minHealth = 1.0f;

        if (_maxHealth <= _minHealth)
            _maxHealth = _minHealth + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.GetTreatment(_health);
            _generator.RemoveFirstAidKit(this);
            Destroy(gameObject);
        }
    }

    public void GetFirstAidKitGenerator(FirstAidKitGenerator firstAidKitGenerator)
    {
        _generator = firstAidKitGenerator;
    }

    public void IncreaseVolumeHealth(float health)
    {
        _health += health;
    }
}
