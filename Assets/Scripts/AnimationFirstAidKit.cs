using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(FirstAidKit))]
public class AnimationFirstAidKit : MonoBehaviour
{
    [SerializeField] private float _minRateChange = 1.0f;
    [SerializeField] private float _maxRateChange = 5.0f;

    private FirstAidKit _firstAidKit;
    private SpriteRenderer _renderer;
    private Vector3 _endSize = new Vector3(1, 1, 1);
    private Color _color = Color.red;

    private void Awake()
    {
        if (_minRateChange < 1)
            _minRateChange = 1.0f;

        if (_maxRateChange <= _minRateChange)
            _maxRateChange = _minRateChange + 1;
    }

    private void Start()
    {
        _firstAidKit = GetComponent<FirstAidKit>();
        _renderer = GetComponent<SpriteRenderer>();

        float rateChange = Random.Range(_minRateChange, _maxRateChange);
        StartCoroutine(Animate(rateChange));
    }

    private IEnumerator Animate(float rateChenge)
    {
        while (transform.localScale.x < _endSize.x)
        {
            Vector3 newSize = new Vector3((_endSize.x - transform.localScale.x) * Time.deltaTime * rateChenge + transform.localScale.x,
                                          (_endSize.y - transform.localScale.y) * Time.deltaTime * rateChenge + transform.localScale.y, 1);
            transform.localScale = newSize;
            Color newColor = ((_color - _renderer.color) * rateChenge *Time.deltaTime) + _renderer.color;
            _renderer.color = newColor;
            float health = _firstAidKit.MaxHealth * Time.deltaTime * rateChenge;
            _firstAidKit.IncreaseVolumeHealth(health);
            yield return null;
        }
    }
}
