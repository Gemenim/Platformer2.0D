using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private List<Coin> _coins;

    public List<Coin> Coins => _coins;

    private void Start()
    {
        _coins = new List<Coin>();
    }

    public void GetCoin(Coin coin)
    {
        _coins.Add(coin);
    }

    public void DropCoin()
    {
        if (_coins.Count > 0)
            _coins.RemoveAt(_coins.Count - 1);
    }
}
