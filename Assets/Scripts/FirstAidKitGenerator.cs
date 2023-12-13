using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKitGenerator : MonoBehaviour
{
    [SerializeField] private FirstAidKit _firstAidKit;
    [SerializeField] private float _cooldown;

    private FirstAidKit[] _firstAidKits;
    private float _maxPositionX = 7.0f;
    private float _maxPositionY = 4.0f;
    private float _minPositionX = -7.0f;
    private float _minPositionY = -2.4f;

    private void Start()
    {
        StartCoroutine(CreatFirstAidKit());
    }

    private IEnumerator CreatFirstAidKit()
    {
        while(true)
        {
            _firstAidKits = GameObject.FindObjectsOfType<FirstAidKit>();

            if (_firstAidKits.Length == 0)
            {
                float randomPositionX = Random.Range(_minPositionX, _maxPositionX);
                float randomPositionY = Random.Range(_minPositionY, _maxPositionY);
                Vector3 position = new Vector3(randomPositionX, randomPositionY, 0);
                Instantiate(_firstAidKit, position, Quaternion.identity);
            }

            var cooldown = new WaitForSeconds(_cooldown);
            yield return cooldown;
        }
    }
}
