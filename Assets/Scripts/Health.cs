using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth = 0;

    public event Action Died;
    public event Action<float> Changed;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Max(_currentHealth - damage, 0);
        Changed?.Invoke(_currentHealth);
        
        Debug.Log("Урон получен");

        if (_currentHealth <= 0)
        {
            Died?.Invoke();
        }
    }

    public void Heal(float amount)
    {
        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
        Changed?.Invoke(_currentHealth);
    }
}
