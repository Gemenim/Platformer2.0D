using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstAidKitGenerator : MonoBehaviour
{
    [SerializeField] private FirstAidKit _firstAidKit;
    [SerializeField] private float _cooldown;

    private List<FirstAidKit> _firstAidKits = new List<FirstAidKit>();
    private float _maxPositionX = 7.0f;
    private float _maxPositionY = 4.0f;
    private float _minPositionX = -7.0f;
    private float _minPositionY = -2.4f;
    private bool _isCooldown = true;

    private void Update()
    {
        if (_firstAidKits.Count == 0 && _isCooldown)
        {
            float randomPositionX = Random.Range(_minPositionX, _maxPositionX);
            float randomPositionY = Random.Range(_minPositionY, _maxPositionY);
            Vector3 position = new Vector3(randomPositionX, randomPositionY, 0);
            FirstAidKit firstAidKit = Instantiate(_firstAidKit, position, Quaternion.identity);
            firstAidKit.GetFirstAidKitGenerator(this);
            _firstAidKits.Add(firstAidKit);
            _isCooldown = false;
        }
    }

    private IEnumerator CountDownCooldown()
    {
        var cooldown = new WaitForSeconds(1);

        for (int i = 0; i <= _cooldown; i ++)
        {
            if(i >= _cooldown)
                _isCooldown = true;

            yield return cooldown;
        }
    }

    public void RemoveFirstAidKit(FirstAidKit firstAidKit)
    {
        _firstAidKits.Remove(firstAidKit);
        var coroutine = StartCoroutine(CountDownCooldown());
    }
}
