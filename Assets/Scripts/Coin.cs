using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    public event Action PickedUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & _playerLayer) != 0)
        {
            PickedUp?.Invoke();
        }
    }
}
