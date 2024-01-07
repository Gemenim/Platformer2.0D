using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar3 : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speedChange;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.value = _health.HealthPoint / _health.MaxHealth;
    }

    private void OnEnable()
    {
        _health.AlteredHealth += StartChangeHealth;
    }

    private void OnDisable()
    {
        _health.AlteredHealth -= StartChangeHealth;
    }

    private void StartChangeHealth()
    {
        StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        while (_health.HealthPoint / _health.MaxHealth != _slider.value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.HealthPoint / _health.MaxHealth, Time.deltaTime * _speedChange);
            yield return null;
        }
    }
}