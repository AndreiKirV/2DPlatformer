using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 5;

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

    public void TakeDamage(float damage = 10)
    {
        _health -= damage;
    }

    public void TakeHealth(float value = 10)
    {
        _health += value;
    }
}