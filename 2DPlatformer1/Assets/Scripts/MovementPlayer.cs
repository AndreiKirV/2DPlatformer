using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private bool _isGround = false;
    private bool _isWater = false;
    private bool _isFacingRight = true;
    private Player _player;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

     private void Update()
    {
        TakeAction();
        MakeAttackAnimation();
    }

    private void TakeAction()
    {
        Jump();
        MoveX();
        ChangeJumpAnimation();        
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround && !_isWater)
        _rigidbody.AddForce(Vector2.up*_player.JumpForce, ForceMode2D.Impulse);
    }

    private void MoveX()
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
        _animator.SetBool("Run", false);

        if(_isGround && Input.GetKey(KeyCode.A) || _isGround && Input.GetKey(KeyCode.D))
        _animator.SetBool("Run", true);
    }

    private void ChangeJumpAnimation()
    {
        if (_isGround)
        _animator.SetBool("Jump", false);
        else
        _animator.SetBool("Jump", true);
    }

    private void MakeAttackAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger("Attack");
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
        if(collider.tag == "Ground" || collider.tag == "Platform")
        _isGround = true;

        if(collider.tag == "Water")
        _isWater = true;
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if(collider.tag == "Ground" || collider.tag == "Platform")
        _isGround = false;

        if(collider.tag == "Water")
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