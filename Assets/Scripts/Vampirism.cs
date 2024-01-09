using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _radius;
    [SerializeField] private float _powerAbility = 5;
    [SerializeField] private int _duration = 6;

    private MoverPlayer _moverPlayer;
    private CircleCollider2D _collider2D;
    private float _timeOut = 1;
    private int _counter;
    private bool _abilityActiv = false;
    private bool _hasPurpose = false;

    private void Awake()
    {
        _moverPlayer = _player.GetComponent<MoverPlayer>();
        _collider2D = GetComponent<CircleCollider2D>();
        _counter = _duration;
        _collider2D.radius = _radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_abilityActiv && collision.TryGetComponent(out Enemy enemy))
        {
            _hasPurpose = true;
            var jobDrainHealth = StartCoroutine(DrainHealth(enemy.GetComponent<Health>(), _counter));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _hasPurpose = false;
    }

    private void OnEnable()
    {
        _moverPlayer.UsingAbility += OnActivateAbility;
    }

    private void OnDisable()
    {
        _moverPlayer.UsingAbility -= OnActivateAbility;
    }

    private void OnActivateAbility()
    {
        StartCoroutine(ActivateAbility());
    }

    private IEnumerator ActivateAbility()
    {
        var timeOut = new WaitForSecondsRealtime(_timeOut);
        _abilityActiv = true;
        _counter = _duration;

        while (_counter != 0)
        {
            _counter --;

            if (_counter == 0)
            {
                _abilityActiv = false;
            }

            yield return timeOut;
        }
    }

    private IEnumerator DrainHealth(Health health, int duration)
    {
        var timeOut = new WaitForSecondsRealtime(_timeOut);
        int counter = 0;

        while (_hasPurpose && counter < duration)
        {
            counter++;
            health.TakeDamage(_powerAbility);
            _player.Health.TakeTreatment(_powerAbility);
            yield return timeOut;
        }
    }
}
