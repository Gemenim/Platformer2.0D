using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar2 : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        ChangeHealth();
    }

    private void OnEnable()
    {
        _health.AlteredHealth += ChangeHealth;
    }

    private void OnDisable()
    {
        _health.AlteredHealth -= ChangeHealth;
    }

    private void ChangeHealth()
    {  
        _slider.value = _health.HealthPoint / _health.MaxHealth;
    }
}
