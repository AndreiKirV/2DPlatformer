using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 7;
    [SerializeField] private float _distance = 10;
    [SerializeField] private Transform _grounDetector;
    
    private bool _isRightEdgeReached = true;
    private RaycastHit2D _groundInfo;
    private int _rotationY = -180;

    private void Update() 
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        _groundInfo = Physics2D.Raycast(_grounDetector.position, Vector2.down, _distance);

        if (_groundInfo.collider == false)
        {
            transform.eulerAngles = new Vector3(0,_rotationY,0);
            _isRightEdgeReached = !_isRightEdgeReached;
            _rotationY += 180;
        }
    }
}