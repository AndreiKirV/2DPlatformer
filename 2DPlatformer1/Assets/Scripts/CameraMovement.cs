using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 2f;
    private Vector3 _target;
    private int _minCameraY = 0;
    private float _targetY;

    private void Update() 
    {
        if (_player)
        {
            Vector3 currentPosition = Vector3.Lerp(transform.position, _target, _speed * Time.deltaTime);
            transform.position = currentPosition;
            _target = new Vector3(_player.position.x, CheckCameraMinimum(ref _targetY), transform.position.z);
        }
    }

    private float CheckCameraMinimum(ref float targetY)
    {
        if (_player.transform.position.y < _minCameraY)
        {
            targetY = 0;
        }
        else
        {
            targetY =_player.transform.position.y;
        }
        
        return targetY;
    }
}