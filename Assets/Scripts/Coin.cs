using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinGenerator _generator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Wallet>(out Wallet wallet))
        {
            wallet.GetCoin(this);
            _generator.RemoveCoin(this);
            Destroy(gameObject);
        }
    }

    public void GetCoinGenerator(CoinGenerator coinGenerator)
    {
        _generator = coinGenerator;
    }
}
