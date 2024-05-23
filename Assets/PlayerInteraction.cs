using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private float _moveSpeed = 5f;
    private float _jumpForce = 10.0f;

    private Vector2 _movement;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private const string _horizontal = "Horizontal";
    private const string _lastHorizontal = "lastHorizontal";
    private const string _isGrounded = "isGrounded";
    private const string _isRunning2 = "isRunning";
    private const string _isShifting2 = "isShifting";
    public bool _isGrounded2;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator.SetBool(_isGrounded, true);
        _isGrounded2 = true;
        _animator.SetBool(_isRunning2, false);
    }

    private void Update()
    {

        if (_rb.velocity.x != 0.0)
        {
            _animator.SetFloat(_lastHorizontal, _rb.velocity.x);
        }

        if (InputManager._isShifting == false || InputManager._isShifting == true && _isGrounded2 == false)
        {
            _rb.velocity = new Vector2(InputManager.Movement.x * _moveSpeed, _rb.velocity.y);

            _animator.SetFloat(_horizontal, _rb.velocity.x);
        }

        /*if(InputManager._isShifting == true && _isGrounded2 == true)
        {
            _rb.velocity = new Vector2(0, 0);
        }*/

        if(InputManager._isRunning == true)
        {
            _animator.SetBool(_isRunning2, true);
            _moveSpeed = 7.5f;
        }
        if (InputManager._isRunning == false)
        {
            _animator.SetBool(_isRunning2, false);
            _moveSpeed = 5f;
        }

        if(InputManager._isJumping == true)
        {
            if(_isGrounded2 == true)
            {
                _rb.AddForce(new Vector2(_rb.velocity.x, _jumpForce), ForceMode2D.Impulse);
                _animator.SetBool(_isGrounded, false);
                _isGrounded2 = false;
            }
        }
        if(InputManager._isShifting == true)
        {
            _animator.SetBool(_isShifting2, true);
        }
        if (InputManager._isShifting == false)
        {
            _animator.SetBool(_isShifting2, false);
            _spriteRenderer.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            _animator.SetBool(_isGrounded, true);
            _isGrounded2 = true;
        }
    }

    public void Shift()
    {
        _spriteRenderer.enabled = false;
    }
}
