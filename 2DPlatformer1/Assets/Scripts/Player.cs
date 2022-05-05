using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 5;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
}