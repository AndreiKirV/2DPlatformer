using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 5;

    private int _coins = 0;

    public int Coins => _coins;
    public float Speed => _speed;
    public float JumpForce => _jumpForce;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
        _coins ++;
        }
    }
}