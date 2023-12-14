using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private int _maxCountCoins;
    [SerializeField] private int _minCountCoins = 1;

    private List<Coin> _coins = new List<Coin>();
    private float _maxPositionX = 7.0f;
    private float _maxPositionY = 4.0f;
    private float _minPositionX = -7.0f;
    private float _minPositionY = -2.4f;

    private void OnValidate()
    {
        if (_minCountCoins < 1)
            _minCountCoins = 1;
    }

    private void Update()
    {
        if (_coins.Count == 0)
        {
            int randomCountCoin = Random.Range(_minCountCoins, _maxCountCoins);

            for (int i = 0; i < randomCountCoin; i++)
            {
                float randomPositionX = Random.Range(_minPositionX, _maxPositionX);
                float randomPositionY = Random.Range(_minPositionY, _maxPositionY);
                Vector3 position = new Vector3(randomPositionX, randomPositionY, 0);
                Coin coin = Instantiate(_coin, position, Quaternion.identity);
                coin.GetCoinGenerator(this);
                _coins.Add(coin);
            }
        }
    }

    public void RemoveCoin(Coin coin)
    {
        _coins.Remove(coin);
    }
}
