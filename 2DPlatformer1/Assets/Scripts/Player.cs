using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private UnityEvent _healthChanged;

    private int _coins  = 0;
    private float _health = 100; 
    private float _maxHealth = 100; 

    public int Coins => _coins;
    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
        _coins ++;
        }
    }

    public void TakeDamage(float value = 10)
    {
        _health = Mathf.Clamp(_health - value, 0, _maxHealth);
        _healthChanged?.Invoke();
    }

    public void TakeHealth(float value = 10)
    {
        _health = Mathf.Clamp(_health + value, 0, _maxHealth);
        _healthChanged?.Invoke();
    }
}