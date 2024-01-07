using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treatment : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _life = 10;

    public void OnButtonClick()
    {
        _health.TakeTreatment(_life);
    }
}
