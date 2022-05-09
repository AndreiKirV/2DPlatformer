using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 5;

    private int _coins = 0;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public int Coins => _coins;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.GetComponent<Coin>())
        {
        _coins ++;
        }
    }
}