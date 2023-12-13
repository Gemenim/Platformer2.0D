using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxPositionX;

    private Vector3 _target;
    private Vector3 _endPoint;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _endPoint = new Vector3(_maxPositionX, transform.position.y, 0);
        _target = _endPoint;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position.x == _endPoint.x)
        {
            Vector3 temporaryVector = _endPoint;
            _endPoint = _startPosition;
            _startPosition = temporaryVector;
            _target = _endPoint;
            transform.Rotate(0, 180, 0);
        }
    }

    public void BackPatrolling()
    {
        _target = _endPoint;
    }

    public void TakeTarget(Vector3 target)
    {
        _target = target;
    }
}
