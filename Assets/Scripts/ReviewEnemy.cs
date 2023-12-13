using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewEnemy : MonoBehaviour
{
    [SerializeField] MoverEnemy _moverEnemy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _moverEnemy.TakeTarget(player.transform.position);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _moverEnemy.BackPatrolling();
        }
    }
}
