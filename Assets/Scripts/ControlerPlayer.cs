using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jupmForce;
    [SerializeField] private float _maxHightJump;
    [SerializeField] private float _maxHight;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private int _direction;
    private bool _isJump = false;
    private string MoverTrigger = "Mover";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction = 0;

        if (Input.GetKey(KeyCode.D))
            _direction = 1;
        else if (Input.GetKey(KeyCode.A))
            _direction = -1;

        if (Input.GetKey(KeyCode.W) && _isJump == false)
            _isJump = true;
    }

    private void FixedUpdate()
    {
        if (_direction == 1)
        {
            if (transform.rotation.y != 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetTrigger(MoverTrigger);
        }
        else if (_direction == -1)
        {
            if (transform.rotation.y != 180)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetTrigger(MoverTrigger);
        }

        if (_isJump)
            StartJamp();

    }

    private IEnumerator Jamp()
    {
        float endCoordinatY = _maxHightJump + transform.position.y;

        while (_isJump)
        {
            _rigidbody2D.AddForce(Vector2.up * _jupmForce);
            if (transform.position.y >= endCoordinatY || transform.position.y >= _maxHight)
                _isJump = false;
            yield return new WaitForEndOfFrame();
        }
    }

    private void StartJamp()
    {
        _isJump = true;
        StartCoroutine(Jamp());
    }
}
