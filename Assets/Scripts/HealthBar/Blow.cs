using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damage = 10;

    public void OnButtonClick()
    {
        _health.TakeDamage(_damage);
    }
}
