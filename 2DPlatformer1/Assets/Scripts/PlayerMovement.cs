using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _startPoint;
    private bool _isGround = false;
    private bool _isWater = false;
    private bool _isFacingRight = true;
    private bool _isDead = false;
    private Player _player;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _startPoint = transform.position;
    }

    private void Update()
    {
        TakeAction();        
    }

    private void TakeAction()
    {
        JumpOnGround();
        MoveXOnGround();
        ChangeJumpAnimationOnAir();
        ChangeAnimationAtTimeDeath(); 
        MakeAnimationAtTimeAttack();       
    }

    private void JumpOnGround()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround && !_isWater)
        Jump();
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up*_player.JumpForce, ForceMode2D.Impulse);
    }

    private void MoveXOnGround()
    {
        if (Input.GetKey(KeyCode.D) && !_isWater)
        {
            transform.Translate(_player.Speed*Time.deltaTime, 0, 0);
            TurnRight();                     
        }

        if (Input.GetKey(KeyCode.A) && !_isWater)
        {
            transform.Translate(-_player.Speed*Time.deltaTime, 0, 0);
            TurnLeft();            
        }   

        ChangeRunningAnimation();
    }

    private void ChangeRunningAnimation()
    {
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) || !_isGround)
        _animator.SetBool(AnimatorPlayerController.Params.Run, false);

        if(_isGround && Input.GetKey(KeyCode.A) || _isGround && Input.GetKey(KeyCode.D))
        _animator.SetBool(AnimatorPlayerController.Params.Run, true);
    }

    private void ChangeJumpAnimationOnAir()
    {
        if (_isGround)
        _animator.SetBool(AnimatorPlayerController.Params.Jump, false);
        else
        _animator.SetBool(AnimatorPlayerController.Params.Jump, true);
    }

    private void ChangeAnimationAtTimeDeath()
    {
        if (_isDead)
        {
        _animator.SetBool(AnimatorPlayerController.Params.Dead, true);  
        Invoke(nameof(Teleport), 2);
        }
    }

    private void Teleport()
    {
        transform.position = _startPoint;
        _isDead = false;
        _animator.SetBool(AnimatorPlayerController.Params.Dead, false);
    }

    private void MakeAnimationAtTimeAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger(AnimatorPlayerController.Params.Attack);
        }
    }

    private void TurnLeft ()
    {
        if (_isFacingRight)
        Flip();
    }

    private void TurnRight ()
    {
        if (!_isFacingRight)
        Flip();
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Ground>(out Ground ground) || collider.gameObject.TryGetComponent<Platform>(out Platform platform))
        _isGround = true;

        if(collider.gameObject.TryGetComponent<Water>(out Water water))
        _isWater = true;

        if(collider.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        _isDead = true;
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if(collider.gameObject.TryGetComponent<Ground>(out Ground ground) || collider.gameObject.TryGetComponent<Platform>(out Platform platform))
        _isGround = false;

        if(collider.gameObject.TryGetComponent<Water>(out Water water))
        _isWater = false;
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}