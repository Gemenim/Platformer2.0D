using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthText : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
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
        _text.text = $"{Mathf.Ceil(_health.HealthPoint)}/{Mathf.Ceil(_health.MaxHealth)}";
    }
}
